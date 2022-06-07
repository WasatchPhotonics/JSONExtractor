using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Amazon.S3;
using Amazon.S3.Model;
using System.Threading;
using System.ComponentModel;
using System.Windows.Forms;
using System;
using System.Linq;

namespace JSONExtractor
{
    /// <summary>
    /// Encapsulates access to AWS S3.
    /// </summary>
    class Cloud
    {
        public string accessKey;
        public string secretKey;
        public string bucket;
        public string cacheDir;

        int keysToDownload;
        int keysDownloaded;

        public BackgroundWorker worker = new() { WorkerReportsProgress = true, WorkerSupportsCancellation = true };
        public bool running;

        Amazon.RegionEndpoint region = Amazon.RegionEndpoint.USEast2;
        AmazonS3Client client;

        ProgressBar progressBar;
        Button buttonStart;
        ToolTip toolTip;

        List<double> recentCompletionTimesSec = new List<double>();
        const int COMPLETION_TIMES_WINDOW = 10;

        Logger logger = Logger.getInstance();

        public Cloud(Button button, ProgressBar pb, ToolTip toolTip)
        {
            this.buttonStart = button;
            this.progressBar = pb;
            this.toolTip = toolTip;

            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        public void start(string accessKey, string secretKey, string bucket, string cacheDir)
        {
            this.accessKey = accessKey;
            this.secretKey = secretKey;
            this.bucket = bucket;
            this.cacheDir = cacheDir;

            logger.debug("creating AWS client");
            client = new AmazonS3Client(accessKey, secretKey, region);

            worker.RunWorkerAsync();
        }

        public void stop()
        {
            worker.CancelAsync();
        }

        void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            running = true;

            logger.debug("counting cached files");
            var existingCount = Directory.EnumerateFiles(cacheDir).Count();

            logger.info("downloading keys");
            List<string> keys = new();
            ListObjectsV2Response listResponse = null;
            var listRequest = new ListObjectsV2Request { BucketName = bucket };
            do
            {
                try
                {
                    if (client is null)
                    {
                        logger.error("AWS client is null?!");
                        return;
                    }
                    listResponse = client.ListObjectsV2Async(listRequest).Result;
                }
                catch(Exception ex)
                {
                    logger.error($"caught exception when listing keys: {ex}");
                    return;
                }
                if (listResponse == null)
                {
                    logger.error("missing ListObjectsV2Response from S3");
                    return;
                }
                else if (worker.CancellationPending)
                {
                    logger.info("sync cancelled");
                    return;
                }
                foreach (var s3Obj in listResponse.S3Objects)
                    keys.Add(s3Obj.Key);
                logger.debug($"now have {keys.Count} keys");
                listRequest.ContinuationToken = listResponse.NextContinuationToken;
            } while (listResponse.IsTruncated);
            logger.info($"received {keys.Count} keys");

            keysToDownload = keys.Count - existingCount; 
            keysDownloaded = 0;
            worker.ReportProgress(keysDownloaded);
            keys.Sort();
            keys.Reverse();

            logger.info("syncing files");
            DateTime lastStart = DateTime.Now;
            foreach (var key in keys)
            { 
                var elapsedSec = (DateTime.Now - lastStart).TotalSeconds;
                while (recentCompletionTimesSec.Count >= COMPLETION_TIMES_WINDOW)
                    recentCompletionTimesSec.RemoveAt(0);
                recentCompletionTimesSec.Add(elapsedSec);
                lastStart = DateTime.Now;

                string pathnameJson = Path.Join(cacheDir, key + ".json");
                string pathnameJsonGz = pathnameJson + ".gz";
                if (File.Exists(pathnameJsonGz))
                    continue;

                logger.info($"downloading {key}");
                var objRequest = new GetObjectRequest() { BucketName = bucket, Key = key };
                var objResponse = client.GetObjectAsync(objRequest).Result;

                using (FileStream writer = File.OpenWrite(pathnameJsonGz))
                using (GZipStream zip = new GZipStream(writer, CompressionMode.Compress))
                using (StreamWriter zipper = new StreamWriter(zip))
                    objResponse.ResponseStream.CopyTo(zip);

                Thread.Sleep(2000); 
                keysDownloaded++;
                worker.ReportProgress(keysDownloaded);

                if (worker.CancellationPending)
                {
                    logger.info("sync cancelled");
                    break;
                }
            }
            logger.info("sync complete");
        }

        void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Maximum = keysToDownload;
            progressBar.Value = keysDownloaded;

            string tt = "unknown time remaining";
            if (recentCompletionTimesSec.Count > 0)
            {
                var secPerRec = recentCompletionTimesSec.Average();
                var secRemaining = (keysToDownload - keysDownloaded) * secPerRec;
                tt = Util.timeRemainingLabel(secRemaining);
            }
            toolTip.SetToolTip(progressBar, tt);
        }

        void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            logger.info("sync worker stopped");
            progressBar.Value = 0;
            buttonStart.Text = "Start Sync";
            client = null;
            running = false;
        }
    }
}

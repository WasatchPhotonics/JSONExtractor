using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Amazon.S3;
using Amazon.S3.Model;

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
        List<string> keys = new();

        Amazon.RegionEndpoint region = Amazon.RegionEndpoint.USEast2;
        AmazonS3Client client;

        Logger logger = Logger.getInstance();

        public Cloud()
        {
            client = new AmazonS3Client(accessKey, secretKey, region);
        }

        async public void syncKeys()
        {

            logger.info("fetching list of S3 keys...");
            ListObjectsV2Response response;
            var request = new ListObjectsV2Request { BucketName = bucket };
            do
            {
                response = await client.ListObjectsV2Async(request);
                logger.debug($"received {response.KeyCount} keys");
                foreach (var s3Obj in response.S3Objects)
                    keys.Add(s3Obj.Key);
                request.ContinuationToken = response.NextContinuationToken;
            } while (response.IsTruncated);
            logger.info($"{keys.Count} keys found");
        }

        async public void syncFiles()
        {
            keys.Sort();
            keys.Reverse();
            foreach (var k in keys)
            {
                string pathnameJson = Path.Join(cacheDir, k + ".json");
                string pathnameJsonGz = pathnameJson + ".gz";
                if (File.Exists(pathnameJsonGz))
                {
                    logger.debug($"already sync'd: {pathnameJsonGz}");
                    continue;
                }

                logger.debug($"downloading ${k}");
                var request = new GetObjectRequest() { BucketName = bucket, Key = k };
                var response = await client.GetObjectAsync(request);

                logger.debug($"saving ${pathnameJsonGz}");
                using (FileStream writer = File.OpenWrite(pathnameJsonGz))
                using (GZipStream zip = new GZipStream(writer, CompressionMode.Compress))
                using (StreamWriter zipper = new StreamWriter(zip))
                    zipper.Write(response.ResponseStream);
            }
        }
    }
}

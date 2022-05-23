using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Amazon.S3;
using Amazon.S3.Model;
using System.Threading.Tasks;

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

        Amazon.RegionEndpoint region = Amazon.RegionEndpoint.USEast2;
        AmazonS3Client client;

        Logger logger = Logger.getInstance();

        public Cloud(string accessKey, string secretKey, string bucket, string cacheDir)
        {
            this.accessKey = accessKey;
            this.secretKey = secretKey;
            this.bucket = bucket;
            this.cacheDir = cacheDir;

            client = new AmazonS3Client(accessKey, secretKey, region);
        }

        async public Task<List<string>> syncKeys()
        {
            List<string> keys = new();
            ListObjectsV2Response response;
            var request = new ListObjectsV2Request { BucketName = bucket };
            do
            {
                response = await client.ListObjectsV2Async(request);
                foreach (var s3Obj in response.S3Objects)
                    keys.Add(s3Obj.Key);
                request.ContinuationToken = response.NextContinuationToken;
            } while (response.IsTruncated);
            return keys;
        }

        async public Task<bool> syncKey(string key)
        {
            string pathnameJson = Path.Join(cacheDir, key + ".json");
            string pathnameJsonGz = pathnameJson + ".gz";
            if (File.Exists(pathnameJsonGz))
                return false;

            logger.info($"downloading {key}");
            var request = new GetObjectRequest() { BucketName = bucket, Key = key };
            var response = await client.GetObjectAsync(request);

            using (FileStream writer = File.OpenWrite(pathnameJsonGz))
            using (GZipStream zip = new GZipStream(writer, CompressionMode.Compress))
            using (StreamWriter zipper = new StreamWriter(zip))
                response.ResponseStream.CopyTo(zip);

            await Task.Delay(2000); 

            return true;
        }
    }
}

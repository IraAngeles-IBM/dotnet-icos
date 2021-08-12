using System;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;

namespace dotnet_icos
{
    public class Program
    {
        private const string bucketName = "ocelot-ira-test-8d9fbed7-a7a7-4f11-9c55-80ad592f30a4-dest";

        static string accessKeyId;
         static string secretAccessKey;
        public static IAamzonS3 client;
        public static void Main(string[] args)
        {

            AmazonS3Config S3Config = new AmazonS3Config
            {
                ServiceURL = "https://control.cloud-object-storage.cloud.ibm.com/v2/endpoints"
            };
            accessKeyId = "6ee60a98c029434cb810d67ce727a21f";
            secretAccessKey = "eea94fd947fafde16f03a6e984477b0e25cf274f43fcb62f";
        

            using client = new AmazonS3Client(accessKeyId , secretAccessKey ,S3Config);

            Console.WriteLine("Hello World!");


            ListObjectsRequest request = new ListObjectsRequest
            {
                // BucketName = "ocelot-ira-test-8d9fbed7-a7a7-4f11-9c55-80ad592f30a4-dest",
                BucketName = bucketName,
            };

            ListObjectsResponse response = client.ListObjects(request);
            foreach (S3Object entry in response.S3Objects)
            {
                Console.WriteLine("key = {0} size = {1}", entry.Key, entry.Size);
            }

        }
    }
}

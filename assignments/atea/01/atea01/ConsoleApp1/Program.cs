using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using System.Text;

namespace AzStorage
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var getData = new GetData();
            Task<HttpResponseMessage> responseMessageTask = getData.GetResponseMessage();
            HttpResponseMessage responseMessage = await responseMessageTask;

            string payloadContent = await responseMessage.Content.ReadAsStringAsync(); //get a string payload response
            dynamic deSerializedPayloadContent = JsonConvert.DeserializeObject(payloadContent); //deserializes  a string payload response
            var stream = await responseMessage.Content.ReadAsStreamAsync(); // get stream 

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("UseDevelopmentStorage=true");

            //todo create blob first version
            //BlobContainerClient blobContainerClient = new BlobContainerClient("UseDevelopmentStorage=true", "test2");
            //blobContainerClient.CreateIfNotExists();

            //Create Blob Container
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference("testblob");
            await blobContainer.CreateIfNotExistsAsync();

            //get Blob reference  
            CloudBlockBlob cloudBlockBlob = blobContainer.GetBlockBlobReference("testing");
            await cloudBlockBlob.UploadFromStreamAsync(stream);

            //todo create blob second version
            // Create a BlobServiceClient object which will be used to create a container client
            BlobServiceClient blobServiceClient = new BlobServiceClient("UseDevelopmentStorage=true");

            //Create a unique name for the container
            string containerName = "quickstartblobs";

            // Create the container and return a container client object
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync();

            // Get a reference to a blob
            BlobClient blobClient2 = containerClient.GetBlobClient("testingname2");

            // Upload data from the local file
            //await blobClient2.UploadAsync(stream, true);//todo sobrid nonemu jo radas exception


            //todo Get blob from blob storage
            // Get reference to blob (binary content)  
            var blockBlob = blobContainer.GetBlockBlobReference("testing");
            //download to stream
            var ms = new MemoryStream();
            await blockBlob.DownloadToStreamAsync(ms);
            //encode to string
            Console.WriteLine(Encoding.Default.GetString(ms.ToArray()));
            //deserialize json
            dynamic json = JsonConvert.DeserializeObject(Encoding.Default.GetString(ms.ToArray()));
            

            //todo create azure table
            //Create Azure Table
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable logInTable = tableClient.GetTableReference("testtable");
            await logInTable.CreateIfNotExistsAsync();

            //Insert entities
            string statusCode = responseMessage.StatusCode.ToString();
            int statusCodeInt = (int)responseMessage.StatusCode;
            Console.WriteLine(statusCodeInt);
            await logInTable.ExecuteAsync(TableOperation.InsertOrReplace(new LogInEntity(statusCode, statusCodeInt)));

            // Create a retrieve operation that takes a LogInEntity entity.
            TableOperation retrieveOperation = TableOperation.Retrieve<LogInEntity>(new DateTime(2021,08,27,12,45,00).ToString(), "OK");

            // Execute the retrieve operation.
            TableResult retrievedResult = await logInTable.ExecuteAsync(retrieveOperation);

            var sResult = "";
            try
            {
                // Print the time of LogInEntity of the result.
                if (retrievedResult.Result != null)
                    sResult = (((LogInEntity)retrievedResult.Result).Time) + (((LogInEntity)retrievedResult.Result).GuidKey);
                else
                    sResult = "";


            }
            catch (InvalidCastException e)
            {
                sResult = "";
            }

            Console.WriteLine(sResult);

            //try
            //{
            //    var filename = "xxx.PNG";
            //    var storageAccount = CloudStorageAccount.Parse("{connection_string}");
            //    var blobClient = storageAccount.CreateCloudBlobClient();

            //    CloudBlobContainer container = blobClient.GetContainerReference("mycontainer");
            //    CloudBlockBlob blob = container.GetBlockBlobReference(filename);

            //    Stream blobStream = blob.OpenRead();

            //    return File(blobStream, blob.Properties.ContentType, filename);

            //}
            //catch (Exception)
            //{
            //    //download failed 
            //    //handle exception
            //    throw;
            //}
        }
    }
}

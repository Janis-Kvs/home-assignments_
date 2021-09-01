using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System.IO;

namespace StorageApp
{
    public class StorageService
    {
        public static async Task InsertTableEntity(HttpResponseMessage responseMessage, string tableName)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("UseDevelopmentStorage=true");

            //Create Azure Table
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable logInTable = tableClient.GetTableReference(tableName);
            await logInTable.CreateIfNotExistsAsync();

            //Insert entities
            string statusCode = responseMessage.StatusCode.ToString();
            int statusCodeInt = (int)responseMessage.StatusCode;
            await logInTable.ExecuteAsync(TableOperation.InsertOrReplace(new LogInEntity(statusCode, statusCodeInt)));
        }
        public static async Task InsertBlob(HttpResponseMessage responseMessage, string containerName)
        {
            // get stream from uri
            var stream = await responseMessage.Content.ReadAsStreamAsync();

            // Create a BlobServiceClient object which will be used to create a container client
            BlobServiceClient blobServiceClient = new BlobServiceClient("UseDevelopmentStorage=true");

            // Create the container and return a container client object
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            await containerClient.CreateIfNotExistsAsync();

            // Get a reference to a blob
            BlobClient blobClient2 = containerClient.GetBlobClient(DateTime.Now.ToString());

            // Upload data from the local file
            await blobClient2.UploadAsync(stream, true);
        }

        public static async Task<List<LogInEntity>> GetTableEntities(DateTime dateTimeFrom, DateTime dateTimeTo, string tableName)
        {
            //Create requested LogInEntity List
            List<LogInEntity> logInList = new List<LogInEntity>();

            //Create Storage Account
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("UseDevelopmentStorage=true");

            //Get Table reference from Azure Table
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            CloudTable logInTable = tableClient.GetTableReference(tableName);

            //Create filter for Table query
            string lowerFilter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.GreaterThanOrEqual, dateTimeFrom.ToString());
            string upperFilter = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.LessThanOrEqual, dateTimeTo.ToString());
            string combinedFilter = TableQuery.CombineFilters(lowerFilter, TableOperators.And, upperFilter);

            // Construct the query operation for all LogIn entities where PartitionKey is between DateTimeFrom to DateTimeTo.
            TableQuery<LogInEntity> query2 = new TableQuery<LogInEntity>().Where(combinedFilter);

            // Add to list each LogIn entity
            TableContinuationToken token = null;
            do
            {
                TableQuerySegment<LogInEntity> resultSegment = await logInTable.ExecuteQuerySegmentedAsync(query2, token);
                token = resultSegment.ContinuationToken;

                foreach (var entity in resultSegment.Results)
                {
                    logInList.Add(entity);
                }
            } while (token != null);

            return logInList;
        }

        public static async Task<object> GetBlob(string blobName, string containerName)
        {
            //Create Storage Account
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse("UseDevelopmentStorage=true");

            //Reference to Blob Container
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(containerName);

            // Get reference to blob  
            var blockBlob = blobContainer.GetBlockBlobReference(blobName);

            //download to stream
            var ms = new MemoryStream();
            await blockBlob.DownloadToStreamAsync(ms);

            //encode to string
            Console.WriteLine(Encoding.Default.GetString(ms.ToArray()));

            //deserialize json
            object json = JsonConvert.DeserializeObject(Encoding.Default.GetString(ms.ToArray()));

            return json;
        }
    }
}


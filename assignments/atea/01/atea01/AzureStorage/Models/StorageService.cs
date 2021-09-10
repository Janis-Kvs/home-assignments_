using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System.IO;
using Refit;

namespace StorageApp
{
    public class StorageService
    {
        private readonly string _connectionString;
        private readonly CloudStorageAccount _storageAccount;

        public StorageService(string connectionName)
        {
            _connectionString = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
            _storageAccount = CloudStorageAccount.Parse(_connectionString);
        }

        public async Task InsertTableEntity(ApiResponse<ApiItem> response)
        {
            //Create Azure Table
            CloudTableClient tableClient = _storageAccount.CreateCloudTableClient();
            var tableName = ConfigurationManager.AppSettings["azureTableName"];
            CloudTable logInTable = tableClient.GetTableReference(tableName);
            await logInTable.CreateIfNotExistsAsync();

            //Insert entities
            string statusCode = response.StatusCode.ToString();
            int statusCodeInt = (int)response.StatusCode;
            await logInTable.ExecuteAsync(TableOperation.InsertOrReplace(new LogInEntity(statusCode, statusCodeInt)));
        }
        public async Task InsertBlob(ApiResponse<ApiItem> response)
        {
            // retrieving the content in the response body as a strongly-typed object
            ApiItem contentObject = response.Content;
            
            // Create a BlobServiceClient object which will be used to create a container client
            BlobServiceClient blobServiceClient = new BlobServiceClient(_connectionString);

            // Create the container and return a container client object
            var blobContainerName = ConfigurationManager.AppSettings["azureBlobContainerName"];
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(blobContainerName);
            await containerClient.CreateIfNotExistsAsync();

            // Get a reference to a blob
            BlobClient blobClient = containerClient.GetBlobClient(DateTime.Now.ToString());

            // Upload data from the serialized object
            var jsonString = JsonConvert.SerializeObject(contentObject);
            await blobClient.UploadAsync(jsonString, true);
        }

        public async Task<List<LogInEntity>> GetTableEntities(DateTime dateTimeFrom, DateTime dateTimeTo, string tableName)
        {
            //Create requested LogInEntity List
            List<LogInEntity> logInList = new List<LogInEntity>();

            //Get Table reference from Azure Table
            CloudTableClient tableClient = _storageAccount.CreateCloudTableClient();
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

        public async Task<object> GetBlob(string blobName, string containerName)
        {
            //Reference to Blob Container
            CloudBlobClient blobClient = _storageAccount.CreateCloudBlobClient();
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


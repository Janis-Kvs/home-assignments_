using System;
using System.Net.Http;
using System.Threading.Tasks;
using AzStorage;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Azure.Storage.Blobs;
using System.IO;

namespace FunctionApp
{
    public static class DataService
    {
        [FunctionName("DataService")]
        public static async Task Run([TimerTrigger("0/15 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var getData = new AzStorage.GetData();

            try
            {
                Task<HttpResponseMessage> responseMessageTask = getData.GetResponseMessage();
                HttpResponseMessage responseMessage = await responseMessageTask;

                await StorageService.InsertTableEntity(responseMessage, "table");
                await StorageService.InsertBlob(responseMessage, "blob-container");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

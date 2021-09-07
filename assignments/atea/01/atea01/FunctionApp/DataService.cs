using System;
using System.Net.Http;
using System.Threading.Tasks;
using StorageApp;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace FunctionApp
{
    public class DataService
    {
        [FunctionName("DataService")]
        public static async Task Run([TimerTrigger("* * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var getData = new DataProvider();

            try
            {
                HttpResponseMessage responseMessage = await getData.GetResponseMessage();

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

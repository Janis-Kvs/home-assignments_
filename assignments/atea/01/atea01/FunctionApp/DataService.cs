using System;
using System.Net.Http;
using System.Threading.Tasks;
using StorageApp;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Refit;
using System.Configuration;

namespace FunctionApp
{
    public class DataService
    {
        private readonly StorageService _storageService;

        public DataService(StorageService storageService)
        {
            _storageService = storageService;
        }

        [FunctionName("DataService")]
        public async Task Run([TimerTrigger("* * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            try
            {
                ApiResponse<ApiItem> response = await GetApiItems();
                
                await _storageService.InsertTableEntity(response);
                await _storageService.InsertBlob(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ApiResponse<ApiItem>> GetApiItems()
        {
            var apiEndpoint = ConfigurationManager.AppSettings["apiEndpoint"];
            IApiServer apiServer = RestService.For<IApiServer>(apiEndpoint);
            ApiResponse<ApiItem> response = await apiServer.GetApiItems();

            return response;
        }
    }
}

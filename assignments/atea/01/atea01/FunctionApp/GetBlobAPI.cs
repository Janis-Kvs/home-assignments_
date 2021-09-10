using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StorageApp;
using System.Configuration;

namespace FunctionApp
{
    public class GetBlobAPI
    {
        private readonly StorageService _storageService;

        public GetBlobAPI(StorageService storageService)
        {
            _storageService = storageService;
        }

        [FunctionName("GetBlob")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string blobName = req.Query["blobname"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            blobName = blobName ?? data?.blobName;

            if(string.IsNullOrEmpty(blobName))
            {
                return new OkObjectResult("Please provide a query string for a date in format yyyymmddhhmmss");
            }

            try
            {
                object blob = await _storageService.GetBlob(blobName, ConfigurationManager.AppSettings["azureBlobContainerName"]);
                return new OkObjectResult(blob);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}

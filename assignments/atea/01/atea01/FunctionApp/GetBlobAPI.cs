using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AzStorage;

namespace FunctionApp
{
    public static class GetBlobAPI
    {
        [FunctionName("GetBlob")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["blobname"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            if(string.IsNullOrEmpty(name))
            {
                return new OkObjectResult("Please provide a query string for a date in format yyyymmddhhmmss");
            }

            try
            {
                DateTime dateTime = ConvertDate(name);
                object blob = await StorageService.GetBlob(dateTime, "blob-container");
                return new OkObjectResult(blob);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public static DateTime ConvertDate(string date)
        {
            // process date
            int year = int.Parse(date.Substring(0, 4));
            int month = int.Parse(date.Substring(4, 2));
            int day = int.Parse(date.Substring(6, 2));
            int hour = int.Parse(date.Substring(8, 2));
            int minute = int.Parse(date.Substring(10, 2));
            int second = int.Parse(date.Substring(12, 2));

            DateTime resultDate = new DateTime(year, month, day, hour, minute, second);

            return resultDate;
        }
    }
}

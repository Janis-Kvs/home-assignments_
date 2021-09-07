using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StorageApp;
using System.Globalization;

namespace FunctionApp
{
    public class GetTableAPI
    {
        [FunctionName("GetTable")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string dateFrom = req.Query["dateFrom"];
            string dateTo = req.Query["dateTo"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            dateFrom = dateFrom ?? data?.dateFrom;
            dateTo = dateTo ?? data?.dateTo;

            if (string.IsNullOrEmpty(dateFrom) || string.IsNullOrEmpty(dateTo))
            {
                return new OkObjectResult("Please provide query strings for a date in format yyyymmddhhmmss");
            }
            try
            {
                DateTime dateTimeFrom = DateTime.ParseExact(dateFrom, "yyyyMMddHHmmss", CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
                DateTime dateTimeTo = DateTime.ParseExact(dateTo, "yyyyMMddHHmmss", CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces);
                List<StorageApp.LogInEntity> logInList = await StorageService.GetTableEntities(dateTimeFrom, dateTimeTo, "table");
                return new OkObjectResult(logInList);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}

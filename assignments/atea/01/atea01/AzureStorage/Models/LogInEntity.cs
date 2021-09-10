using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace StorageApp
{
    public class LogInEntity : TableEntity
    {
        public string GuidKey { get; set; }
        public string Status => RowKey;
        public string StatusCode { get; set; }
        public string Time => PartitionKey;

        public LogInEntity(string status, int statusCode)
        {
            PartitionKey = DateTime.Now.ToString();
            GuidKey = Guid.NewGuid().ToString();
            RowKey = status;
            StatusCode = statusCode.ToString();
        }

        public LogInEntity()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Status: {Status} Status code: {StatusCode} Request time: {Time} Guid: {GuidKey}";
        }
    }
}

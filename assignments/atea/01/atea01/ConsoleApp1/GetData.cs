using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AzStorage
{
    public class GetData
    {
        private string _uri = "https://api.publicapis.org/random?auth=null";
        private HttpClient _client;

        public GetData()
        {
            _client = new HttpClient();
        }

        public async Task<HttpResponseMessage> GetResponseMessage()
        {
            HttpResponseMessage responseMessage = await _client.GetAsync(_uri);
            return responseMessage;
        }
    }
}

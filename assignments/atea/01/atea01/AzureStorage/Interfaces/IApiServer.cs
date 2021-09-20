using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Refit;

namespace StorageApp
{
    public interface IApiServer
    {
        [Get("/random?auth=null")]
        Task<ApiResponse<ApiItem>> GetApiItems();
    }
}

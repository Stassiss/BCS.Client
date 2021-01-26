using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BCS.Client.Helpers
{
    public class HttpResponseWraper<T>
    {
        public HttpResponseWraper(T data, bool success, HttpResponseMessage httpResponseMessage)
        {
            Data = data;

            Success = success;
            HttpResponseMessage = httpResponseMessage;
        }
        public T Data { get; set; }

        public bool Success { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }
        public async Task<string> GetBody()
        {
            return await HttpResponseMessage.Content.ReadAsStringAsync();
        }
    }
}

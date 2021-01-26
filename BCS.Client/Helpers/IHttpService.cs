using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCS.Client.Helpers
{
    public interface IHttpService
    {
        Task<HttpResponseWraper<object>> Post<T>(string url, T data);
        Task<HttpResponseWraper<TResponse>> Post<T, TResponse>(string url, T data);
    }
}

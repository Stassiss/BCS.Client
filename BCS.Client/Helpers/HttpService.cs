﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BCS.Client.Helpers
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseWraper<object>> Post<T>(string url, T data)
        {
            var dataJason = JsonSerializer.Serialize(data);

            var stringContent = new StringContent(dataJason, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, stringContent);
            return new HttpResponseWraper<object>(null, response.IsSuccessStatusCode, response);
        }
        public async Task<HttpResponseWraper<TResponse>> Post<T, TResponse>(string url, T data)
        {
            var dataJason = JsonSerializer.Serialize(data);

            var stringContent = new StringContent(dataJason, Encoding.UTF8, "application/json");
            var httpResponse = await _httpClient.PostAsync(url, stringContent);
            if (httpResponse.IsSuccessStatusCode)
            {
                var deserializedResponse = await Deserialize<TResponse>(httpResponse, defaultJsonSerializerOptions);
                return new HttpResponseWraper<TResponse>(deserializedResponse, httpResponse.IsSuccessStatusCode, httpResponse);
            }
            else
            {
                return new HttpResponseWraper<TResponse>(default, false, httpResponse);

            }
        }
        private async Task<T> Deserialize<T>(HttpResponseMessage httpResponseMessage, JsonSerializerOptions options)
        {
            var responseString = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(responseString, defaultJsonSerializerOptions);
        }

        private JsonSerializerOptions defaultJsonSerializerOptions =>
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

    }
}

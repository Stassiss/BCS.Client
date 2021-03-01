using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BCS.Client.Auth.DTOs;
using BCS.Client.Auth.StateProvider;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace BCS.Client.Auth
{
    public class AuthService : IAuthService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationState;

        public AuthService(ILocalStorageService localStorage, HttpClient httpClient, AuthenticationStateProvider authenticationState)
        {
            _localStorage = localStorage;
            _httpClient = httpClient;
            _authenticationState = authenticationState;
        }
        public async Task<AuthResponseDto> Login(UserForAuthDto userForAuthentication)
        {
            var content = JsonSerializer.Serialize(userForAuthentication);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var authResult = await _httpClient.PostAsync("account/login", bodyContent);
            var authContent = await authResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<AuthResponseDto>(authContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (!authResult.IsSuccessStatusCode)
                return result;
            await _localStorage.SetItemAsync("authToken", result.Token);
            await _localStorage.SetItemAsync("refreshToken", result.RefreshToken);
            ((AuthStateProvider)_authenticationState).NotifyUserAuthentication(result.Token);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
            return new AuthResponseDto { IsAuthSuccessful = true };
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            await _localStorage.RemoveItemAsync("refreshToken");
            ((AuthStateProvider)_authenticationState).NotifyUserLogout();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
        public async Task<string> RefreshToken()
        {
            var token = await _localStorage.GetItemAsync<string>("authToken");
            var refreshToken = await _localStorage.GetItemAsync<string>("refreshToken");
            var tokenDto = JsonSerializer.Serialize(new RefreshTokenDto { Token = token, RefreshToken = refreshToken });
            var bodyContent = new StringContent(tokenDto, Encoding.UTF8, "application/json");
            var refreshResult = await _httpClient.PostAsync("token/refresh", bodyContent);
            var refreshContent = await refreshResult.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<AuthResponseDto>(refreshContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (!refreshResult.IsSuccessStatusCode)
                throw new ApplicationException("Something went wrong during the refresh token action");
            await _localStorage.SetItemAsync("authToken", result.Token);
            await _localStorage.SetItemAsync("refreshToken", result.RefreshToken);

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
            return result.Token;
        }
    }
}

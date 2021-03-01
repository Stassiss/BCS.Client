using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BCS.Client.Auth;
using BCS.Client.Auth.StateProvider;
using BCS.Client.Helpers;
using BCS.Client.Repository;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace BCS.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            ConfigureServices(builder.Services);

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }.EnableIntercept(sp));
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001/api/") });

            await builder.Build().RunAsync();
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
            services.AddScoped<RefreshTokenService>();
            services.AddScoped<HttpInterceptorService>();

            services.AddAuthorizationCore();
            services.AddBlazoredLocalStorage();
        }
    }
}

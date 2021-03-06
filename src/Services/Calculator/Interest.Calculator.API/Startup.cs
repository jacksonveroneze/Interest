using System;
using System.Net.Http;
using System.Security.Authentication;
using Interest.Calculator.API.Configuration;
using Interest.Calculator.API.Middlewares;
using Interest.Calculator.Application.Http;
using Interest.Calculator.Application.Interfaces;
using Interest.Calculator.Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;
using Refit;

namespace Interest.Calculator.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            AsyncRetryPolicy<HttpResponseMessage> retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .Or<HttpRequestException>()
                .WaitAndRetryAsync(5, (attempt) => TimeSpan.FromSeconds(2), (outcome, timespan, retryCount, context) =>
                    Console.WriteLine($"Tentando pela {retryCount} vez!")
                );

            services.AddRefitClient<IRateHttpService>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(Configuration["UrlRateAPI"]))
                .ConfigurePrimaryHttpMessageHandler(sp => new HttpClientHandler
                {
                    AllowAutoRedirect = true,
                    ServerCertificateCustomValidationCallback = (message, certificate2, arg3, arg4) => true,
                    SslProtocols = SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12
                })
                .AddPolicyHandler(retryPolicy);

            services.AddScoped<ICalculateService, CalculateService>();
            services.AddScoped<IExecuteService, ExecuteService>();

            services.AddSwaggerConfiguration();

            services.AddHealthChecks();

            services.AddResponseCompression();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwaggerConfiguration();

            app.UseHealthChecks("/health");

            app.UseResponseCompression();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}

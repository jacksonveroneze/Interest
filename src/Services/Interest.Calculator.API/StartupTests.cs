using System;
using System.Net.Http;
using Interest.Calculator.API.Configuration;
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
    public class StartupTests
    {
        public IConfiguration Configuration { get; }

        public StartupTests(Microsoft.Extensions.Hosting.IHostingEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
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
                .AddPolicyHandler(retryPolicy);

            services.AddTransient<ICalculateService, CalculateService>();
            services.AddTransient<IExecuteService, ExecuteService>();

            services.AddSwaggerConfiguration();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwaggerConfiguration();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}

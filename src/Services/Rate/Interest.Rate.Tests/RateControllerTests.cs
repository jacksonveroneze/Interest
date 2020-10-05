using System;
using System.Net.Http;
using System.Threading.Tasks;
using Interest.Rate.API;
using Interest.Rate.API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Xunit;

namespace Interest.Rate.Tests
{
    public class RateControllerTests
    {
        private readonly HttpClient _httpClient;

        public RateControllerTests()
        {
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseTestServer();
                    webHost.UseStartup<Startup>();
                });

            var host = hostBuilder.Start();

            _httpClient = host.GetTestClient();

            _httpClient.BaseAddress = new Uri("http://localhost:5000");
        }

        [Fact(DisplayName = "Deve buscar a taxa de juros corretamente.")]
        [Trait("Categoria", "RateController")]
        public async Task RateController_Index_DeveBuscarATaxaDeJurosCorretamente()
        {
            // Arrange
            HttpResponseMessage response = await _httpClient.GetAsync("taxaJuros");

            // Act
            string responseString = await response.Content.ReadAsStringAsync();

            RateResponse result = JsonConvert.DeserializeObject<RateResponse>(responseString);

            // Assert
            Assert.Equal(0.01, result.Rate);
        }
    }
}

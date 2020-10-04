using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Interest.Calculator.API;
using Interest.Calculator.Application.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Xunit;

namespace Interest.Calculator.Tests.Api
{
    public class CalculatorControllerTests
    {
        private readonly HttpClient _httpClient;

        public CalculatorControllerTests()
        {
            var hostBuilder = new HostBuilder()
                .ConfigureWebHost(webHost =>
                {
                    webHost.UseTestServer();
                    webHost.UseStartup<StartupTests>();
                });

            var host = hostBuilder.Start();

            _httpClient = host.GetTestClient();

            _httpClient.BaseAddress = new Uri("https://localhost:6001");
        }

        [Fact(DisplayName = "Deve calcular corretamente a taxa de juros.")]
        [Trait("Categoria", "CalculatorController")]
        public async Task CalculatorController_Index_DeveEfetuarOCalculoCorretamente()
        {
            // Arrange
            HttpResponseMessage response = await _httpClient.GetAsync("calculajuros?valorInicial=100&meses=5");

            // Act
            string responseString = await response.Content.ReadAsStringAsync();

            CalculationResponse result = JsonConvert.DeserializeObject<CalculationResponse>(responseString);

            // Assert
            Assert.Equal(105.1, result.Result);
        }

        [Fact(DisplayName = "Deve retornar erro quando informar o valor inicial menor que zero.")]
        [Trait("Categoria", "CalculatorController")]
        public async Task CalculatorController_Index_DeveRetornarErroValorInicialIgualAZero()
        {
            // Arrange && Act
            HttpResponseMessage response = await _httpClient.GetAsync("calculajuros?valorInicial=0&meses=5");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact(DisplayName = "Deve retornar erro quando informar os meses menor que zero.")]
        [Trait("Categoria", "CalculatorController")]
        public async Task CalculatorController_Index_DeveRetornarErroMesesIgualAZero()
        {
            // Arrange && Act
            HttpResponseMessage response = await _httpClient.GetAsync("calculajuros?valorInicial=100&meses=0");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}

using System;
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

        [Fact(DisplayName = "Adicionar item em novo pedido")]
        [Trait("Categoria", "Integração Web - Pedido")]
        public async Task AdicionarItem_NovoPedido_DeveAtualizarValorTotal()
        {
            // Arrange
            var response = await _httpClient.GetAsync("calculajuros?valorInicial=0&meses=5");

            // Act
            var responseString = await response.Content.ReadAsStringAsync();

            CalculationResponse result = JsonConvert.DeserializeObject<CalculationResponse>(responseString);

            // Assert
            Assert.Equal(105.1, result.Result);
        }
    }
}

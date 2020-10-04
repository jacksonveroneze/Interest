using System;
using Interest.Calculator.Application.Services;
using Xunit;

namespace Interest.Calculator.Tests.Services
{
    public class CalculateServiceTests
    {
        [Fact(DisplayName = "Deve calcular corretamente a taxa de juros.")]
        [Trait("Categoria", "CalculateService")]
        public void CalculateService_Calc_DeveCalcularCorretamente()
        {
            // Arrange
            CalculateService calculateService = new CalculateService();

            // Act
            double result = calculateService.Calc(100, 5, 0.01);

            // Assert
            Assert.Equal(105.1, result);
        }

        [Fact(DisplayName = "Não deve calcular corretamente a taxa de juros.")]
        [Trait("Categoria", "CalculateService")]
        public void CalculateService_Calc_NaoDeveCalcularCorretamente()
        {
            // Arrange
            CalculateService calculateService = new CalculateService();

            // Act
            double result = calculateService.Calc(100, 5, 0.01);

            // Assert
            Assert.NotEqual(105.2, result);
        }

        [Fact(DisplayName = "Deve retornar erro quando informar o valor inicial menor que zero.")]
        [Trait("Categoria", "CalculateService")]
        public void CalculateService_Calc_DeveRetornarErroValorInicialIgualAZero()
        {
            // Arrange
            CalculateService calculateService = new CalculateService();

            // Act
            Exception exception = Assert.Throws<Exception>(() => calculateService.Calc(0, 5, 0.01));

            // Assert
            Assert.Equal("O valor inicial deve ser maior que zero.", exception.Message);
        }

        [Fact(DisplayName = "Deve retornar erro quando informar os meses menor que zero.")]
        [Trait("Categoria", "CalculateService")]
        public void CalculateService_Calc_DeveRetornarErroMesesIgualAZero()
        {
            // Arrange
            CalculateService calculateService = new CalculateService();

            // Act
            Exception exception = Assert.Throws<Exception>(() => calculateService.Calc(1, 0, 0.01));

            // Assert
            Assert.Equal("O total de meses deve ser maior que zero.", exception.Message);
        }

        [Fact(DisplayName = "Deve retornar erro quando informar a taxa de juros menor que zero.")]
        [Trait("Categoria", "CalculateService")]
        public void CalculateService_Calc_DeveRetornarErroTaxaJurosMenorQueZero()
        {
            // Arrange
            CalculateService calculateService = new CalculateService();

            // Act
            Exception exception = Assert.Throws<Exception>(() => calculateService.Calc(1, 1, -1));

            // Assert
            Assert.Equal("A taxa de juros deve maior ou igual a zero.", exception.Message);
        }
    }
}

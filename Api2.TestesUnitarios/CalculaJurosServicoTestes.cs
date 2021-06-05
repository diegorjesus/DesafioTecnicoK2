using Api2.Aplicacao.Interfaces;
using Api2.Aplicacao.Servico;
using Microsoft.Extensions.Configuration;
using Moq.AutoMock;
using System.Threading.Tasks;
using Xunit;

namespace Api2.TestesUnitarios
{
    public class CalculaJurosServicoTestes
    {
        private readonly AutoMocker _mocker;

        public CalculaJurosServicoTestes()
        {
            _mocker = new AutoMocker();
        }

        [Theory(DisplayName = "Retorna valor final")]
        [InlineData(100, 5, 105.1)]
        [InlineData(100, 8, 108.28)]
        [InlineData(-58, 7, -62.18)]
        [InlineData(0, 7, 0)]
        [InlineData(100, 0, 100)]
        [InlineData(double.MinValue, 1, double.NegativeInfinity)]
        [InlineData(double.MaxValue, 1, double.PositiveInfinity)]
        public async Task CalcularJurosAsync_RetornaValor(double valorInicial, int tempo, double valorFinal)
        {
            //Arrange
            var parametros = new ParametrosConsulta
            {
                ValorInicial = valorInicial,
                Tempo = tempo
            };

            var mockConfig = _mocker.GetMock<IConfiguration>();
            mockConfig.Setup(c => c["Urls:UrlApi1"])
                .Returns(string.Empty);

            var mockTaxaJuros = _mocker.GetMock<ITaxaJuros>();
            mockTaxaJuros.Setup(c => c.BuscarTaxaJurosAsync(string.Empty))
                .Returns(Task.FromResult(0.01));

            var mockServico = new CalculaJurosServico(mockConfig.Object, mockTaxaJuros.Object);

            //Act
            var resultado = await mockServico.CalcularJurosAsync(parametros);

            //Assert
            Assert.Equal(valorFinal, resultado);
        }
    }
}
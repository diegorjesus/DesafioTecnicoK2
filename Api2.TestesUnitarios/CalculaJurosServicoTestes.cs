using Api2.Aplicacao.Servico;
using Api2.TestesUnitarios.Fixtures;
using System.Threading.Tasks;
using Xunit;

namespace Api2.TestesUnitarios
{
    [Collection(nameof(CalculaJurosServicoCollection))]
    public class CalculaJurosServicoTestes
    {
        private readonly CalculaJurosServicoFixture _fixture;
        private readonly CalculaJurosServico _controller;

        public CalculaJurosServicoTestes(CalculaJurosServicoFixture fixture)
        {
            _fixture = fixture;
            _controller = fixture.InstanciarServico();
        }

        [Theory(DisplayName = "Retorna valor final")]
        [InlineData(100, 5, 105.1)]
        public async Task CalcularJurosAsync_RetornaValor(double valorInicial, int tempo, double valorFinal)
        {
            //Arrange
            var parametros = new ParametrosConsulta
            {
                ValorInicial = valorInicial,
                Tempo = tempo
            };

            var taxaJuros = 0.01;

            //Act
            var resultado = await _controller.CalcularJurosAsync(parametros);

            //Assert
            Assert.Equal(valorFinal, resultado);
        }
    }
}
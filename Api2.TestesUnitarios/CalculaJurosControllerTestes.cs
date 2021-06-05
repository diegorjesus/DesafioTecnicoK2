using Api2.Aplicacao.Interfaces;
using Api2.Controllers;
using Api2.TestesUnitarios.Fixtures;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api2.TestesUnitarios
{
    [Collection(nameof(CalculaJurosControllerCollection))]
    public class CalculaJurosControllerTestes
    {
        private readonly CalculaJurosControllerFixture _fixture;
        private readonly CalculaJurosController _controller;

        public CalculaJurosControllerTestes(CalculaJurosControllerFixture fixture)
        {
            _fixture = fixture;
            _controller = fixture.InstanciarController();
        }

        [Fact(DisplayName = "Calcula os Juros e retorna sucesso")]
        public async Task CalculaJurosAsync_DeveRetornarValor()
        {
            //Arrange
            var parametros = new ParametrosConsulta
            {
                ValorInicial = 100,
                Tempo = 5
            };

            _fixture.Mocker.GetMock<ICalculaJurosServico>()
                .Setup(x => x.CalcularJurosAsync(parametros))
                .Returns(Task.FromResult(105.10));

            //Act
            var resultado = await _controller.CalcularJuros(parametros);

            //Assert
            Assert.IsType<OkObjectResult>(resultado);
            Assert.Equal(105.1, (resultado as OkObjectResult).Value);
        }

        [Fact(DisplayName = "Quando servico retornar uma excessão")]
        public async Task CalculaJurosAsync_ServicoRetornaExcessao_DeveRetornarInternalServerError()
        {
            //Arrange
            var parametros = new ParametrosConsulta
            {
                ValorInicial = 100,
                Tempo = 5
            };

            _fixture.Mocker.GetMock<ICalculaJurosServico>()
                .Setup(x => x.CalcularJurosAsync(parametros))
                .Returns(Task.FromException<double>(new Exception()));

            //Act
            var resultado = await _controller.CalcularJuros(parametros);

            //Assert
            Assert.Equal(500, (resultado as ObjectResult).StatusCode);
        }
    }
}
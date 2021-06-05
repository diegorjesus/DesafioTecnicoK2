using Api2.Aplicacao.Interfaces;
using Api2.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq.AutoMock;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api2.TestesUnitarios
{
    public class CalculaJurosControllerTestes
    {
        private readonly AutoMocker _autoMocker;
        private readonly CalculaJurosController _controller;

        public CalculaJurosControllerTestes()
        {
            _autoMocker = new AutoMocker();
            _controller = _autoMocker.CreateInstance<CalculaJurosController>();
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

            _autoMocker.GetMock<ICalculaJurosServico>()
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

            _autoMocker.GetMock<ICalculaJurosServico>()
                .Setup(x => x.CalcularJurosAsync(parametros))
                .Returns(Task.FromException<double>(new Exception()));

            //Act
            var resultado = await _controller.CalcularJuros(parametros);

            //Assert
            Assert.Equal(500, (resultado as ObjectResult).StatusCode);
        }
    }
}
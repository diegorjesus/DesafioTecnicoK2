using Api2.Controllers;
using Api2.TestesUnitarios.Fixtures;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
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

        [Fact(DisplayName = "Calcula os Juros e retorna ok")]
        public async Task CalculaJurosAsync_DeveRetornarSucesso()
        {
            //Act
            var resultado = await _controller.CalcularJuros();

            //Assert
            Assert.IsType<OkObjectResult>(resultado);
        }
    }
}

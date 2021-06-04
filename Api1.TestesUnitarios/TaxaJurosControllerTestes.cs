using Api1.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Api1.TestesUnitarios
{
    public class TaxaJurosControllerTestes
    {
        private readonly TaxaJurosController _controller;

        public TaxaJurosControllerTestes()
        {
            _controller = new TaxaJurosController();
        }
        [Fact(DisplayName = "Buscar Taxa de Juros")]
        public void BuscarTaxaJuros_UmPorcento_DeveRetornarValor()
        {
            //Act
            var resultado = _controller.BuscarTaxaJuros().Result as OkObjectResult;

            //Assert
            Assert.Equal(0.01, resultado.Value);

        }
    }
}
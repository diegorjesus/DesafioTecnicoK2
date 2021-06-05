using Api2.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Api2.TestesUnitarios
{
    public class ShowMeTheCodeControllerTestes
    {
        private readonly ShowMeTheCodeController _controller;

        public ShowMeTheCodeControllerTestes()
        {
            _controller = new ShowMeTheCodeController();
        }

        [Fact(DisplayName = "Buscar Url do git onde o fonte se encontra")]
        public void GetGitHubUrl_DeveRetornarValor()
        {
            //Arrange
            var gitUrlExpected = "https://github.com/diegorjesus/DesafioTecnicoK2.git";

            //Act
            var resultado = _controller.GetGitHubUrl().Result as OkObjectResult;

            //Assert
            Assert.Equal(gitUrlExpected, resultado.Value);
        }
    }
}
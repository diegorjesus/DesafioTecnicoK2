using Api2.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Api2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculaJurosServico service;
        private readonly ILogger<CalculaJurosController> _logger;

        public CalculaJurosController(ICalculaJurosServico service, ILogger<CalculaJurosController> logger)
        {
            this.service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> CalcularJuros([FromQuery] ParametrosConsulta parametros)
        {
            try
            {
                var resultado = await service.CalcularJurosAsync(parametros);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
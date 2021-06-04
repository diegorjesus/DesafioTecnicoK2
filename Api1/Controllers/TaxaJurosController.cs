using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Api1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        /// <summary>
        /// Buscar Taxa de Juros
        /// </summary>
        [HttpGet]
        [SwaggerResponse(200, "Retorna taxa de juros de 0.01")]
        public ActionResult<double> BuscarTaxaJuros()
        {
            return Ok(0.01);
        }
    }
}

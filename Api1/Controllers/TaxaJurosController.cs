using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<double> BuscarTaxaJuros()
        {
            return Ok(0.01);
        }
    }
}

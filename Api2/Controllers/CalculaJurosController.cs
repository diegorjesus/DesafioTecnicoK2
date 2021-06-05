using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> CalcularJuros()
        {
            try
            {
                return Ok(105.10);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
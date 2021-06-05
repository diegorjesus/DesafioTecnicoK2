using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Annotations;

namespace Api2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        private const string _gitUrl = "https://github.com/diegorjesus/DesafioTecnicoK2.git";

        [HttpGet]
        [SwaggerResponse(200, "Retorna Url do gitHub onde o fonte se encontra")]
        public ActionResult<string> GetGitHubUrl()
        {
            return Ok(_gitUrl);
        }
    }
}

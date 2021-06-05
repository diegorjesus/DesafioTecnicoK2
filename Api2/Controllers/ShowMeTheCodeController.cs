using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Annotations;

namespace Api2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        private readonly string _gitUrl;

        public ShowMeTheCodeController(IConfiguration config)
        {
            _gitUrl = config.GetSection("Urls").GetValue<string>("GitUrl");
        }

        [HttpGet]
        [SwaggerResponse(200, "Retorna Url do gitHub onde o fonte se encontra")]
        public ActionResult<string> GetGitHubUrl()
        {
            return Ok(_gitUrl);
        }
    }
}

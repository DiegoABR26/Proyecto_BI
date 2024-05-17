using Microsoft.AspNetCore.Mvc;

namespace Proyect_BI.Controllers
{
     

    [Route("api/[controller]")]
    [ApiController]
    [Route("[controller]")]
    public class BusinessIntelligenceController : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public void Get()
        {
            //Ingresar texto
        }
    }
}
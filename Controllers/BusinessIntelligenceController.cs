using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using Proyect_BI.EL;

namespace Proyect_BI.Controllers
{
    [ApiController]
    [Route("api/BusinessIntelligenceController")]
    public class BusinessIntelligenceController : ControllerBase
    {
        public readonly TrabajadoresBL _trabajadorBL;

        public BusinessIntelligenceController(TrabajadoresBL trabajadoresBL)
        {
            _trabajadorBL = trabajadoresBL;
        }

        //[HttpGet("GetTrabajadores")]
        //public async Task<ActionResult<List<TrabajadorResult>>> GetTrabajadores([FromQuery] string param1, [FromQuery] int param2)
        //{
        //    var results = await _trabajadorBL.GetResultsFromStoredProcedureAsync(param1, param2);
        //    return Ok(results);
        //}

        [HttpPost("GetTipoHorarios")]
        public ResultHorario GetTipoHorarios(RequestTipoHorario requestTipoHorario)
        {

            return _trabajadorBL.GetResultsFromStoredProcedureAsync2(requestTipoHorario);
        }

        [HttpPost("InsertTrabajador")]
        public string InsertTrabajador(Trabajador requestTrabajador)
        {
            return _trabajadorBL.InsertTrabajador(requestTrabajador);
        }


    }
}
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

        #region HORARIOS

        [HttpPost("GetTipoHorarios")] //Obtiene los horarios por tipo
        public ResultHorario GetTipoHorarios()
        {

            return _trabajadorBL.GetTipoHorarios();
        }

        [HttpPost("InsertHorarios")] //Registra los horarios por tipo
        public string[] InsertHorarios(RequestTipoHorario requestTipoHorario)
        {

            return _trabajadorBL.InsertHorarios(requestTipoHorario);
        }

        #endregion

        #region SEDES


        #endregion

        #region TRABAJADORES
        [HttpPost("InsertTrabajador")]
        public string[] InsertTrabajador(Trabajador requestTrabajador)
        {
            return _trabajadorBL.InsertTrabajador(requestTrabajador);
        }

        [HttpPost("ListaTrabajadores")]
        public TrabajadorResult ListaTrabajadores(Trabajador requestTrabajador)
        {
            return _trabajadorBL.ListaTrabajadores(requestTrabajador);
        }
        #endregion
    }
}
using DataLayer;
using Microsoft.Data.SqlClient;
using Proyect_BI.EL;
using System.Data;

namespace BusinessLayer;

public class TrabajadoresBL
{
    private readonly TrabajadoresDL _TrabajadoresDL;

    public TrabajadoresBL(TrabajadoresDL trabajadoresDL)
    {
        _TrabajadoresDL = trabajadoresDL;
    }

    
    public ResultHorario GetTipoHorarios()
    {
        return _TrabajadoresDL.GetTipoHorarios();
    }

    public string[] InsertHorarios(RequestTipoHorario requestTipoHorario)
    {
        return _TrabajadoresDL.InsertHorarios(requestTipoHorario);
    }

    #region SEDES
    public ListSedes GetSedes()
    {
        return _TrabajadoresDL.GetSedes();
    }

    public string[] InsertSedes(Sedes sedes)
    {
        return _TrabajadoresDL.InsertSedes(sedes);
    }
    #endregion

    #region TRABAJADORES
    public string[] InsertTrabajador(Trabajador requestTrabajador)
    {
        return _TrabajadoresDL.InsertTrabajador(requestTrabajador);
    }

    public TrabajadorResult ListaTrabajadores(Trabajador requestTrabajador)
    {
        return _TrabajadoresDL.ListaTrabajadores(requestTrabajador);
    }
    #endregion
}

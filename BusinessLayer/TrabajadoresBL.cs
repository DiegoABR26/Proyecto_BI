using DataLayer;
using Microsoft.Data.SqlClient;
using NuGet.Protocol.Plugins;
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

    public async Task<List<TrabajadorResult>> GetResultsFromStoredProcedureAsync(string param1, int param2)
    {
        var parameters = new[]
        {
            new SqlParameter("@Param1", SqlDbType.VarChar) { Value = param1 },
            new SqlParameter("@Param2", SqlDbType.Int) { Value = param2 }
        };

        return await _TrabajadoresDL.ExecuteStoredProcedureAsync("MyStoredProcedure", parameters);
    }


    public ResultHorario GetResultsFromStoredProcedureAsync2(RequestTipoHorario requestTipoHorario)
    {

        return _TrabajadoresDL.ExecuteStoredProcedureAsync2(requestTipoHorario);

    }
}

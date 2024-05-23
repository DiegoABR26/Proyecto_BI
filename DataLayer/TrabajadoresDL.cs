using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Proyect_BI.EL;

namespace DataLayer;

public class TrabajadoresDL
{
    private readonly string _connectionString;

    public TrabajadoresDL(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<List<TrabajadorResult>> ExecuteStoredProcedureAsync(string storedProcedureName, SqlParameter[] parameters)
    {
        var results = new List<TrabajadorResult>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                await connection.OpenAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var result = new TrabajadorResult
                        {
                            Property1 = reader["Column1"].ToString(),
                            Property2 = Convert.ToInt32(reader["Column2"]),
                            // Map other properties as needed
                        };
                        results.Add(result);
                    }
                }
            }
        }

        return results;
    }

    public ResultHorario ExecuteStoredProcedureAsync2(RequestTipoHorario requestTipoHorario)
    {
        var results = new ResultHorario();

        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_ListarHorarios", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    var parameters = new[]
                    {
                new SqlParameter("@Param1", SqlDbType.Int) { Value = requestTipoHorario.Id_Horario }
            };

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new RequestTipoHorario();
                            {
                                result.Id_Horario = Convert.ToInt32(reader["Column1"]);
                                result.Hora_Inicio = Convert.ToString(reader["Column2"]);
                                result.Hora_Final = Convert.ToString(reader["Column3"]);
                                result.Cant_Horas_Trabaj = Convert.ToInt32(reader["Column4"]);
                            };
                            results.Result.Add(result);
                        }

                        results.ErrorIndicator = 1;
                        results.MessageError = "Se ejecutó correctamente";
                    }

                }
            }
        }
        catch(Exception ex)
        {
            results.ErrorIndicator = 0;
            results.MessageError = "No se ejecutó correctamente el servicio: " + ex.Message;
        }

        return results;
    }
}

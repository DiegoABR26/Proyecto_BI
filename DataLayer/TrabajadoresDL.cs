using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Proyect_BI.EL;
using Microsoft.AspNetCore.Http;

namespace DataLayer;

public class TrabajadoresDL
{
    private readonly string _connectionString;

    public TrabajadoresDL(string connectionString)
    {
        _connectionString = connectionString;
        
    }

    public ResultHorario GetTipoHorarios()
    {
        var results = new ResultHorario();

        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_ListarHorarios", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new RequestTipoHorario();
                            {
                                result.Id_Horario = Convert.ToInt32(reader["Id_Horario"]);
                                result.Hora_Inicio = Convert.ToString(reader["Hora_Inicio"]);
                                result.Hora_Final = Convert.ToString(reader["Hora_Final"]);
                                result.CANT_HORAS_TRABJ = Convert.ToInt32(reader["CANT_HORAS_TRABJ"]);
                                result.Actividad = Convert.ToInt32(reader["ACTIVO"]);
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

    public string[] InsertHorarios(RequestTipoHorario requestTipoHorario)
    {
        var result = new ResultHorario();
        string[] Rspta = new string[2];
        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                using (SqlCommand command = new SqlCommand("usp_InsertHorario", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;

                    var parameters = new[]
                    {
                        new SqlParameter("@HORA_INICIO", SqlDbType.NVarChar) { Value = requestTipoHorario.Hora_Inicio },
                        new SqlParameter("@HORA_FINAL", SqlDbType.NVarChar) { Value = requestTipoHorario.Hora_Final },
                        new SqlParameter("@CANT_HORAS_TRABJ", SqlDbType.Int) { Value = requestTipoHorario.CANT_HORAS_TRABJ},
                    };

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            {
                                result.MessageError = Convert.ToString(reader["message_error"]);
                            };
                        }
                        reader.Close();
                        Rspta[0] = result.MessageError;
                        Rspta[1] = "0";
                    }

                }
            }
        }
        catch (Exception ex)
        {
            Rspta[0] = "No se ejecutó correctamente el servicio: " + ex.Message;
            Rspta[1] = "1";
        }

        return Rspta;
    }



    #region SEDES
    public ListSedes GetSedes()
    {
        var results = new ListSedes();

        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_ListarSedes", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new Sedes();
                            {
                                result.id = Convert.ToInt32(reader["ID_SEDES"]);
                                result.nombre_Sede = Convert.ToString(reader["NOMBRE_SEDE"]);
                                result.actividad = Convert.ToInt32(reader["ACTIVO"]);
                            };
                            results.List.Add(result);
                        }

                        results.errorIndicator = 1;
                        results.message_error = "Se ejecutó correctamente";
                    }

                }
            }
        }
        catch (Exception ex)
        {
            results.errorIndicator = 0;
            results.message_error = "No se ejecutó correctamente el servicio: " + ex.Message;
        }

        return results;
    }

    public string[] InsertSedes(Sedes sedes)
    {
        var result = new ListSedes();
        string[] Rspta = new string[2];
        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                using (SqlCommand command = new SqlCommand("usp_InsertSede", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;

                    var parameters = new[]
                    {
                        new SqlParameter("@NOMBRE_SEDE", SqlDbType.NVarChar) { Value = sedes.nombre_Sede }
                    };

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            {
                                result.message_error = Convert.ToString(reader["message_error"]);
                            };
                        }
                        reader.Close();
                        Rspta[0] = result.message_error;
                        Rspta[1] = "0";
                    }

                }
            }
        }
        catch (Exception ex)
        {
            Rspta[0] = "No se ejecutó correctamente el servicio: " + ex.Message;
            Rspta[1] = "1";
        }

        return Rspta;
    }
    #endregion

    #region TRABAJADORES
    public string[] InsertTrabajador(Trabajador requestTrabajador)
    {
        var result = new TrabajadorResult();
        string[] Rspta = new string[2];
        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                using (SqlCommand command = new SqlCommand("usp_InsertTrabajador", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;

                    var parameters = new[]
                    {
                        new SqlParameter("@DNI", SqlDbType.NVarChar) { Value = requestTrabajador.Dni },
                        new SqlParameter("@NOMBRE", SqlDbType.NVarChar) { Value = requestTrabajador.Nombre },
                        new SqlParameter("@TIPO_HORARIO", SqlDbType.Int) { Value = requestTrabajador.Tipo_Horario },
                        new SqlParameter("@TIPO_CONTRATO", SqlDbType.Int) { Value = requestTrabajador.Tipo_Contrato },
                        new SqlParameter("@SEDE", SqlDbType.Int) { Value = requestTrabajador.Sede },
                        new SqlParameter("@FECHA_INGRESO", SqlDbType.NVarChar) { Value = requestTrabajador.Fecha_Ingreso },
                        new SqlParameter("@FECHA_CESE", SqlDbType.NVarChar) { Value = requestTrabajador.Fecha_Cese },
                        new SqlParameter("@EMAIL", SqlDbType.NVarChar) { Value = requestTrabajador.Email },
                        new SqlParameter("@NUMERO_CONTACT", SqlDbType.NVarChar) { Value = requestTrabajador.Numero_Contact }
                    };

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            {
                                result.message_error = Convert.ToString(reader["message_error"]);
                            };
                        }
                        reader.Close();
                        Rspta[0] = result.message_error;
                        Rspta[1] = "0";
                    }

                }
            }
        }
        catch (Exception ex)
        {
            Rspta[0] = "No se ejecutó correctamente el servicio: " + ex.Message;
            Rspta[1] = "1";
        }

        return Rspta;
    }

    public TrabajadorResult ListaTrabajadores(Trabajador requestTrabajador)
    {
        var results = new TrabajadorResult();
        try
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                using (SqlCommand command = new SqlCommand("usp_ListaTrabajadores", connection))
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;

                    var parameters = new[]
                    {
                        new SqlParameter("@DNI", SqlDbType.NVarChar) { Value = requestTrabajador.Dni },
                        new SqlParameter("@NOMBRE", SqlDbType.NVarChar) { Value = requestTrabajador.Nombre },
                        new SqlParameter("@TIPO_HORARIO", SqlDbType.Int) { Value = requestTrabajador.Tipo_Horario },
                        new SqlParameter("@TIPO_CONTRATO", SqlDbType.Int) { Value = requestTrabajador.Tipo_Contrato },
                        new SqlParameter("@SEDE", SqlDbType.Int) { Value = requestTrabajador.Sede },
                    };

                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var result = new Trabajador();
                            {
                                result.Id = Convert.ToInt32(reader["ID"]);
                                result.Dni = Convert.ToString(reader["DNI"]);
                                result.Nombre = Convert.ToString(reader["NOMBRE"]);
                                result.Horario = Convert.ToString(reader["TIPO_HORARIO"]);
                                result.Tipo_Contrato = Convert.ToInt32(reader["TIPO_CONTRATO"]);
                                result.Fecha_Ingreso = Convert.ToString(reader["FECHA_INGRESO"]);
                                result.Actividad = Convert.ToString(reader["ACTIVO"]);
                                result.Fecha_Cese = Convert.ToString(reader["FECHA_CESE"]);
                                result.Nombre_Sede = Convert.ToString(reader["NOMBRE_SEDE"]);
                                result.Email = Convert.ToString(reader["EMAIL"]);
                                result.Numero_Contact = Convert.ToString(reader["NUMERO_CONTACT"]);
                            };
                            results.Lista.Add(result);
                        }

                        results.ErrorIndicator = 0;
                        results.message_error = "Se ejecutó correctamente";
                    }

                }
            }
        }
        catch (Exception ex)
        {
            results.ErrorIndicator = 0;
            results.message_error = "No se ejecutó correctamente el servicio: " + ex.Message;
        }

        return results;
    }

    #endregion
}

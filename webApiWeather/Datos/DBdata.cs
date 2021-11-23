using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static System.Configuration.ConfigurationManager;

namespace webApiWeather.Datos
{
    public class DBdata
    {
        public static string preconex = ConnectionStrings["stringConexion"].ConnectionString;

        public static ResponseData Ejecutar(string nombreProcedimiento, List<ParameterData> ParametersData, string stringConexion = "")
        {
            ResponseData ResponseData = new ResponseData();
            ResponseData.message = "";
            SqlConnection conexion = new SqlConnection(string.IsNullOrEmpty(stringConexion) ? preconex : stringConexion);
            conexion.Open();

            try
            {
                SqlCommand cmd = new SqlCommand(nombreProcedimiento, conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if (ParametersData != null)
                {
                    foreach (var ParameterData in ParametersData)
                    {
                        if (!ParameterData.Output)
                        { cmd.Parameters.AddWithValue(ParameterData.Name, ParameterData.Value); }
                        else
                        { cmd.Parameters.Add(ParameterData.Name, SqlDbType.VarChar, 100).Direction = ParameterDirection.Output; }
                    }
                }

                int e = cmd.ExecuteNonQuery();

                for (int i = 0; i < ParametersData.Count; i++)
                {
                    if (cmd.Parameters[i].Direction == ParameterDirection.Output)
                    {
                        string mensaje = cmd.Parameters[i].Value.ToString();

                        if (!string.IsNullOrEmpty(mensaje))
                        {
                            ResponseData.message = mensaje;
                        }
                    }
                }

                ResponseData.exito = e > 0 ? true : false;
                ResponseData.message = e > 0 ? "found data" : "No se encontro el comprobante para actualizarlo";
            }
            catch (Exception EX)
            {
                ResponseData.exito = false;
                ResponseData.message = EX.Message;
            }
            finally
            {
                conexion.Close();
            }

            return ResponseData;
        }
    }
}
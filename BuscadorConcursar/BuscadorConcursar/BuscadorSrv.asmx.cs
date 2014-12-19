using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Services;

namespace BuscadorConcursar
{
    /// <summary>
    /// Descripción breve de BuscadorSrv
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class BuscadorSrv : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string BuscarPostulacionesPorDocumento(int documento)
        {
            try
            {

                var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConection"].ConnectionString);
                conn.Open();
                var un_comando = conn.CreateCommand();
                un_comando.CommandText = "BUCO_BuscarPostulacionesPorDocumento";
                un_comando.CommandType = System.Data.CommandType.StoredProcedure;
                un_comando.Parameters.Add(new SqlParameter("documento", documento));

                var resultado_consulta = un_comando.ExecuteReader();
                var postulaciones = new List<Postulacion>();

                while (resultado_consulta.Read())
                {
                    postulaciones.Add(new Postulacion(
                    (int)resultado_consulta["Nro_Doc"],
                    (string)resultado_consulta["Tipo_Doc"],
                    (string)resultado_consulta["Apellido"],
                    (string)resultado_consulta["Nombre"],
                    (string)resultado_consulta["Puesto"],
                    (string)resultado_consulta["Estado"],
                    (resultado_consulta["Observacion"] is DBNull) ? "" : (string)resultado_consulta["Observacion"],
                    (string)resultado_consulta["NombrePDF"]));
                }

                conn.Close();
                return JsonConvert.SerializeObject(postulaciones);
            }
            catch (Exception e)
            {
                return e.InnerException.Message;
            }
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Prueba(int numero)
        {
            return "FUNCIONA FUNCIONA!!!!! mandaste:" + numero;
        }
    }
}

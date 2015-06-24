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
        public string BuscarPostulacionesPorDocumento(int documento, int llamado, int anio)
        {
            try
            {

                var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConection"].ConnectionString);
                conn.Open();
                var un_comando = conn.CreateCommand();
                un_comando.CommandText = "BUCO_BuscarPostulacionesPorDocumento";
                un_comando.CommandType = System.Data.CommandType.StoredProcedure;
                un_comando.Parameters.Add(new SqlParameter("documento", documento));
                un_comando.Parameters.Add(new SqlParameter("llamado", llamado));
                un_comando.Parameters.Add(new SqlParameter("anio", anio));

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
        public string ActasPublicadas()
        {
            try
            {

                var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConection"].ConnectionString);
                conn.Open();
                var un_comando = conn.CreateCommand();
                un_comando.CommandText = "BUCO_BuscarActasPublicadas";
                un_comando.CommandType = System.Data.CommandType.StoredProcedure;

                var resultado_consulta = un_comando.ExecuteReader();
                var actas = new List<ActaPublicada>();

                while (resultado_consulta.Read())
                {
                    actas.Add(new ActaPublicada(
                    (int)resultado_consulta["Comite"],
                    (int)resultado_consulta["Perfil"],
                    (int)resultado_consulta["Acta"],
                    (string)resultado_consulta["Descripcion"],
                    (DateTime)resultado_consulta["Fecha"],
                    (string)resultado_consulta["Link"]));
                }

                conn.Close();
                return JsonConvert.SerializeObject(actas);
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

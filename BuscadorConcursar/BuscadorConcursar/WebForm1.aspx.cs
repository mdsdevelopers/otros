using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace BuscadorConcursar
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConection"].ConnectionString);
            conn.Open();
            var un_comando = conn.CreateCommand();
            un_comando.CommandText = "BUCO_BuscarPostulacionesPorDocumento";
            un_comando.CommandType = System.Data.CommandType.StoredProcedure;
            un_comando.Parameters.Add(new SqlParameter("documento", 29193500));

            var resultado_consulta = un_comando.ExecuteReader();

            grid1.DataSource = resultado_consulta;
            grid1.DataBind();







        }
    }
}
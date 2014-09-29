using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using TestStoredProcedures;

namespace TestStores
{
    [TestClass]
    public class Treta
    {
        SqlConnection conexion;
        SqlCommand comando_get_sps;

        [TestInitialize]
        public void setup()
        {
            //new SqlConnection("Data Source=DIOGENES\\DOSK;Initial Catalog=DB_RRHH;Integrated Security=True");
            conexion = new SqlConnection("Data Source=SQLTRETA;Initial Catalog=DB_RRHH;Integrated Security=True");
            conexion.Open();
            
            comando_get_sps = conexion.CreateCommand();
            comando_get_sps.Connection = conexion;
        }

        public LoggerEjecucionSps GetLogger()
        {
            return new LoggerEjecucionSps("C:\Documents and Settings\msaenz\Escritorio\Repositorio\otros\TestStoreProcedures\Logs");
        }

        [TestMethod]
        public void TestMethod1()
        {
            //comando_ejecutar_un_sp.CommandText = "[dbo].[CON_CONSULTA_RAPIDA_LEGAJO]";
            var lista_sps = GetListadoSps();
            var logger = GetLogger();
            
            for (int j = 0; j < lista_sps.Rows.Count; j++)
            {
                var nombre_sp = lista_sps.Rows[j]["name"].ToString();
                StoredProcedure sp = StoredProcedure.New(nombre_sp, conexion, GetLogger());
                sp.Ejecutar();
            }
        }

        private DataTable GetListadoSps()
        {
            comando_get_sps.CommandText = "SELECT * FROM db_rrhh.dbo.sysobjects where xtype = 'P' " +
                "and name not like 'dt_%' and name not like 'sp_%' " +
                "order by name";

            var adapter_lista_sps = new SqlDataAdapter();
            var lista_sps = new DataTable();

            adapter_lista_sps.SelectCommand = comando_get_sps;
            adapter_lista_sps.Fill(lista_sps);
            return lista_sps;
        }

        [TestCleanup]
        public void teardown()
        {
            conexion.Close();
        }
    }
}

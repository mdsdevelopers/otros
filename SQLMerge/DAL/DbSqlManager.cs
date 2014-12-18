using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.SqlEnum;
using System.Collections.Specialized;




namespace DAL
{
    public static class DbSqlManager
    {
        public static bool ExisteServidor(string direccion_de_servidor)
        {
            SqlConnectionStringBuilder string_de_conexion_nuevo =
            new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = direccion_de_servidor;
            string_de_conexion_nuevo["integrated Security"] = true;
            string_de_conexion_nuevo["Initial Catalog"] = "master";

            SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;

            try
            {
                conexion_nueva.Open();
                conexion_nueva.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
           
        public static bool ExisteServidor(string direccion_de_servidor, string usuario, string password)
        {            
            SqlConnectionStringBuilder string_de_conexion_nuevo =
            new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = direccion_de_servidor;
            string_de_conexion_nuevo["Initial Catalog"] = "master";          
            
            string_de_conexion_nuevo["User Id"] = usuario;
            string_de_conexion_nuevo["Password"] = password;

            SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;

            try
            {
                conexion_nueva.Open();
                conexion_nueva.Close();
                return true;
            }
            catch (Exception ex)
            {
               throw ex;
            }
        }
              
        public static bool ExisteServidor(string direccion_de_servidor, string nombre_base)
        {           
            SqlConnectionStringBuilder string_de_conexion_nuevo =
            new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = direccion_de_servidor;
            string_de_conexion_nuevo["Initial Catalog"] = nombre_base;
            string_de_conexion_nuevo["integrated Security"] = true;
          
            SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;

            try
            {
                conexion_nueva.Open();
                conexion_nueva.Close();
                return true;
            }
            catch (Exception ex)
            {
              throw ex;
            }
        }

    

        public static List<string> ProcedimientosExistentes(string direccion_servidor, string nombre_de_base, string usuario, string password)
        {
            SqlConnectionStringBuilder string_de_conexion_nuevo =
            new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = direccion_servidor;
            string_de_conexion_nuevo["Initial Catalog"] = nombre_de_base;
            string_de_conexion_nuevo["User Id"] = usuario;
            string_de_conexion_nuevo["Password"] = password;

            SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;
            try
            {
                conexion_nueva.Open();
                string sentencia = QueryManager.SentenciaProcedimientosExistentes(nombre_de_base);

                SqlCommand comando = new SqlCommand(sentencia);
                comando.Connection = (conexion_nueva);

                SqlDataReader reader = comando.ExecuteReader(CommandBehavior.CloseConnection);
                List<string> lista_de_nombres = new List<string>();

                while (reader.Read())
                {
                    lista_de_nombres.Add(reader[0].ToString());
                }
                reader.Close();
                conexion_nueva.Close();
                return lista_de_nombres;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        
        public static List<string> ProcedimientosExistentes(string direccion_servidor, string nombre_de_base)
        {
            SqlConnectionStringBuilder string_de_conexion_nuevo =
            new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = direccion_servidor;
            string_de_conexion_nuevo["integrated Security"] = true;
            string_de_conexion_nuevo["Initial Catalog"] = nombre_de_base;
     
            SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;

            try
            {
                conexion_nueva.Open();
                string sentencia = QueryManager.SentenciaProcedimientosExistentes(nombre_de_base);

                SqlCommand comando = new SqlCommand(sentencia);
                comando.Connection = (conexion_nueva);

                SqlDataReader reader = comando.ExecuteReader(CommandBehavior.CloseConnection);
                List<string> lista_de_nombres = new List<string>();

                while (reader.Read())
                {
                    lista_de_nombres.Add(reader[0].ToString());
                }
                reader.Close();
                conexion_nueva.Close();
                return lista_de_nombres;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        public static List<string> TablasExistentes(string direccion_servidor, string nombre_de_base)
        {
            SqlConnectionStringBuilder string_de_conexion_nuevo =
            new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = direccion_servidor;
            string_de_conexion_nuevo["integrated Security"] = true;
            string_de_conexion_nuevo["Initial Catalog"] = nombre_de_base;
            
            SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;

            try
            {
                conexion_nueva.Open();
                string sentencia = QueryManager.SentenciaTablasExistentes(nombre_de_base);////"select name from " + nombre_de_base + "..sysobjects where type = 'u' and category <> 2 order by name asc";

                SqlCommand comando = new SqlCommand(sentencia);
                comando.Connection = (conexion_nueva);

                SqlDataReader reader = comando.ExecuteReader(CommandBehavior.CloseConnection);
                List<string> lista_de_nombres = new List<string>();

                while (reader.Read())
                {
                    lista_de_nombres.Add(reader[0].ToString());
                }
                reader.Close();
                conexion_nueva.Close();
                return lista_de_nombres;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public static List<string> TablasExistentes(string direccion_servidor, string nombre_de_base, string usuario, string password)
        {
            SqlConnectionStringBuilder string_de_conexion_nuevo =
            new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = direccion_servidor;
            string_de_conexion_nuevo["Initial Catalog"] = nombre_de_base;
            string_de_conexion_nuevo["User Id"] = usuario;
            string_de_conexion_nuevo["Password"] = password;

            SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;

            try
            {
                conexion_nueva.Open();
                string sentencia = QueryManager.SentenciaTablasExistentes(nombre_de_base);
                SqlCommand comando = new SqlCommand(sentencia);
                comando.Connection = (conexion_nueva);

                SqlDataReader reader = comando.ExecuteReader(CommandBehavior.CloseConnection);
                List<string> lista_de_nombres = new List<string>();

                while (reader.Read())
                {
                    lista_de_nombres.Add(reader[0].ToString());
                }
                reader.Close();
                conexion_nueva.Close();
                return lista_de_nombres;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static List<string> TriggersExistentes(string direccion_servidor, string nombre_de_base)
        {
            SqlConnectionStringBuilder string_de_conexion_nuevo =
            new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = direccion_servidor;
            string_de_conexion_nuevo["integrated Security"] = true;
            string_de_conexion_nuevo["Initial Catalog"] = nombre_de_base;
            
            SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;

            try
            {
                conexion_nueva.Open();
                string sentencia = QueryManager.SentenciaTriggersExistentes(nombre_de_base);

                SqlCommand comando = new SqlCommand(sentencia);
                comando.Connection = (conexion_nueva);

                SqlDataReader reader = comando.ExecuteReader(CommandBehavior.CloseConnection);
                List<string> lista_de_nombres = new List<string>();

                while (reader.Read())
                {
                    lista_de_nombres.Add(reader[0].ToString());
                }
                reader.Close();
                conexion_nueva.Close();
                return lista_de_nombres;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        public static List<string> TriggersExistentes(string direccion_servidor, string nombre_de_base, string usuario, string password)
        {
            SqlConnectionStringBuilder string_de_conexion_nuevo =
            new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = direccion_servidor;
            string_de_conexion_nuevo["Initial Catalog"] = nombre_de_base;
            string_de_conexion_nuevo["User Id"] = usuario;
            string_de_conexion_nuevo["Password"] = password;

            SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;

            try
            {
                conexion_nueva.Open();
                string sentencia = QueryManager.SentenciaTriggersExistentes(nombre_de_base);

                SqlCommand comando = new SqlCommand(sentencia);
                comando.Connection = (conexion_nueva);

                SqlDataReader reader = comando.ExecuteReader(CommandBehavior.CloseConnection);
                List<string> lista_de_nombres = new List<string>();

                while (reader.Read())
                {
                    lista_de_nombres.Add(reader[0].ToString());
                }
                reader.Close();
                conexion_nueva.Close();
                return lista_de_nombres;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        
        public static List<string> VistasExistentes(string direccion_servidor, string nombre_de_base)
        {
            SqlConnectionStringBuilder string_de_conexion_nuevo = new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = direccion_servidor;
            string_de_conexion_nuevo["integrated Security"] = true;
            string_de_conexion_nuevo["Initial Catalog"] = nombre_de_base;


            SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;

            try
            {
                conexion_nueva.Open();
                string sentencia = QueryManager.SentenciaVistasExistentes(nombre_de_base); 
                SqlCommand comando = new SqlCommand(sentencia);
                comando.Connection = (conexion_nueva);

                SqlDataReader reader = comando.ExecuteReader(CommandBehavior.CloseConnection);
                List<string> lista_de_nombres = new List<string>();

                while (reader.Read())
                {
                    lista_de_nombres.Add(reader[0].ToString());
                }
                reader.Close();
                conexion_nueva.Close();
                return lista_de_nombres;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static List<string> VistasExistentes(string direccion_servidor, string nombre_de_base, string usuario, string password)
        {
            SqlConnectionStringBuilder string_de_conexion_nuevo =
            new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = direccion_servidor;
            string_de_conexion_nuevo["Initial Catalog"] = nombre_de_base;
            string_de_conexion_nuevo["User Id"] = usuario;
            string_de_conexion_nuevo["Password"] = password;

            SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;

            try
            {
                conexion_nueva.Open();
                string sentencia = QueryManager.SentenciaVistasExistentes(nombre_de_base);// "select name from " + nombre_de_base + "..sysobjects where type = 'V' and category <> 2 order by name asc";

                SqlCommand comando = new SqlCommand(sentencia);
                comando.Connection = (conexion_nueva);

                SqlDataReader reader = comando.ExecuteReader(CommandBehavior.CloseConnection);
                List<string> lista_de_nombres = new List<string>();

                while (reader.Read())
                {
                    lista_de_nombres.Add(reader[0].ToString());
                }
                reader.Close();
                conexion_nueva.Close();
                return lista_de_nombres;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
                

        public static List<string> FuncionesExistentes(string direccion_servidor, string nombre_de_base)
        {
            SqlConnectionStringBuilder string_de_conexion_nuevo =
            new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = direccion_servidor;
            string_de_conexion_nuevo["integrated Security"] = true;
            string_de_conexion_nuevo["Initial Catalog"] = nombre_de_base;


            SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;

            try
            {
                conexion_nueva.Open();
                string sentencia = QueryManager.SentenciaFuncionesExistentes(nombre_de_base);//"select name from " + nombre_de_base + "..sysobjects where type = 'FN' and category <> 2 order by name asc";
              
                SqlCommand comando = new SqlCommand(sentencia);
                comando.Connection = (conexion_nueva);

                SqlDataReader reader = comando.ExecuteReader(CommandBehavior.CloseConnection);
                List<string> lista_de_nombres = new List<string>();

                while (reader.Read())
                {
                    lista_de_nombres.Add(reader[0].ToString());
                }

                reader.Close();
                conexion_nueva.Close();

                return lista_de_nombres;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static List<string> FuncionesExistentes(string direccion_servidor, string nombre_de_base, string usuario, string password)
        {
            SqlConnectionStringBuilder string_de_conexion_nuevo =
            new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = direccion_servidor;
            string_de_conexion_nuevo["Initial Catalog"] = nombre_de_base;
            string_de_conexion_nuevo["User Id"] = usuario;
            string_de_conexion_nuevo["Password"] = password;

            SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;

            try
            {
                conexion_nueva.Open();
                string sentencia = QueryManager.SentenciaFuncionesExistentes(nombre_de_base);//"select name from " + nombre_de_base + "..sysobjects where type = 'FN' and category <> 2 order by name asc";

                SqlCommand comando = new SqlCommand(sentencia);
                comando.Connection = (conexion_nueva);

                SqlDataReader reader = comando.ExecuteReader(CommandBehavior.CloseConnection);
                List<string> lista_de_nombres = new List<string>();

                while (reader.Read())
                {
                    lista_de_nombres.Add(reader[0].ToString());
                }
                reader.Close();
                conexion_nueva.Close();
                return lista_de_nombres;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
                           
        public static string ObtenerTexto(string nombre_objeto, string nombre_de_base, string nombre_servidor, string usuario, string password)
        {
                      
            SqlConnectionStringBuilder string_de_conexion_nuevo =
            new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = nombre_servidor;
            string_de_conexion_nuevo["Initial Catalog"] = nombre_de_base;
            string_de_conexion_nuevo["User Id"] = usuario;
            string_de_conexion_nuevo["Password"] = password;

            SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;
            
            try
            {
                conexion_nueva.Open();

                string sentencia_existe_elemento = QueryManager.SentenciaExisteElemento(nombre_objeto);

                SqlCommand comando_validacion = new SqlCommand(sentencia_existe_elemento);
                comando_validacion.Connection = (conexion_nueva);
                comando_validacion.CommandType = CommandType.Text;
                SqlDataReader reader_validacion = comando_validacion.ExecuteReader();

                while (reader_validacion.Read())
                {
                    if (reader_validacion[0] is DBNull)
                    {
                        reader_validacion.Close();
                        conexion_nueva.Close();
                        return " ";
                    }
                }
                reader_validacion.Close();

                                
                string sentencia = QueryManager.SentenciaTexto() +nombre_objeto;
                SqlCommand comando = new SqlCommand(sentencia);
                comando.Connection = (conexion_nueva);
                comando.CommandType = CommandType.Text;
                SqlDataReader reader = comando.ExecuteReader(CommandBehavior.CloseConnection);
                
                string lista_de_nombres = "";
                StringBuilder sb = new StringBuilder();

                while (reader.Read())
                {
                    sb.Append(reader[0].ToString().Replace("\t", "  "));
                    lista_de_nombres = reader[0].ToString();
                }

                reader.Close();
                conexion_nueva.Close();
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static string ObtenerTexto(string nombre_objeto, string nombre_de_base, string nombre_servidor)
        {          
   
            SqlConnectionStringBuilder string_de_conexion_nuevo =
            new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = nombre_servidor;
            string_de_conexion_nuevo["integrated Security"] = true;
            string_de_conexion_nuevo["Initial Catalog"] = nombre_de_base;
            
            SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;

            try
            {
                conexion_nueva.Open();

                string sentencia_existe_elemento = QueryManager.SentenciaExisteElemento(nombre_objeto);

                SqlCommand comando_validacion = new SqlCommand(sentencia_existe_elemento);
                comando_validacion.Connection = (conexion_nueva);
                comando_validacion.CommandType = CommandType.Text;
                SqlDataReader reader_validacion = comando_validacion.ExecuteReader();

                while (reader_validacion.Read())
                {
                    if (reader_validacion[0] is DBNull)
	                {
                        reader_validacion.Close();
                        conexion_nueva.Close();
                        return " ";
	                }                                       
                }
                reader_validacion.Close();
                
                string sentencia = QueryManager.SentenciaTexto() + nombre_objeto;
                SqlCommand comando = new SqlCommand(sentencia);
                comando.Connection = (conexion_nueva);
                comando.CommandType = CommandType.Text;
                SqlDataReader reader = comando.ExecuteReader(CommandBehavior.CloseConnection);
                
                string lista_de_nombres = "";
                StringBuilder sb = new StringBuilder();

                while (reader.Read())
                {
                    sb.Append(reader[0].ToString().Replace("\t", "  "));
                    lista_de_nombres = reader[0].ToString();
                }

                reader.Close();
                conexion_nueva.Close();
                return sb.ToString();
            }
            catch (Exception ex)
            {   
                throw ex;
            }
        }


        /*texto de tablas*/

        public static string ObtenerTextoDeTabla2(string nombre_objeto, string nombre_de_base, string nombre_servidor)
        {

            SqlConnectionStringBuilder string_de_conexion_nuevo =
            new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = nombre_servidor;
            string_de_conexion_nuevo["integrated Security"] = true;
            string_de_conexion_nuevo["Initial Catalog"] = nombre_de_base;

            SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;

            try
            {
                conexion_nueva.Open();

                string sentencia_existe_elemento = QueryManager.SentenciaExisteElemento(nombre_objeto);

                SqlCommand comando_validacion = new SqlCommand(sentencia_existe_elemento);
                comando_validacion.Connection = (conexion_nueva);
                comando_validacion.CommandType = CommandType.Text;
                SqlDataReader reader_validacion = comando_validacion.ExecuteReader();

                while (reader_validacion.Read())
                {
                    if (reader_validacion[0] is DBNull)
                    {
                        reader_validacion.Close();
                        conexion_nueva.Close();
                        return " ";
                    }
                }
                reader_validacion.Close();

                string sentencia = QueryManager.SentenciaTextoTablas() + @"'" + nombre_objeto + @"'";
                SqlCommand comando = new SqlCommand(sentencia);
                comando.Connection = (conexion_nueva);
                comando.CommandType = CommandType.Text;
                SqlDataReader reader = comando.ExecuteReader(CommandBehavior.CloseConnection);

               // string lista_de_nombres = "";
                StringBuilder sb = new StringBuilder();
                string sb2 = "";
                while (reader.Read())
                {
                  sb2= sb2 + (reader[0].ToString().Replace("\t", "  ") + reader[1].ToString().Replace("\t", "  ") + reader[2].ToString().Replace("\t", "  ") + reader[3].ToString().Replace("\t", "  ") + reader[4].ToString().Replace("\t", "  ") + reader[5].ToString().Replace("\t", "  "));
                 
                    //  lista_de_nombres = sb2;// reader[0].ToString() + reader[1].ToString().Replace("\t", "  ") + reader[2].ToString().Replace("\t", "  ") + reader[3].ToString().Replace("\t", "  ") + reader[4].ToString().Replace("\t", "  ") + reader[5].ToString().Replace("\t", "  ");
                }

                reader.Close();
                conexion_nueva.Close();
                return sb2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /*ESTO ERA LO QUE ANDABA DE TABLAS */

        public static string ObtenerTextoDeTablaManeraLenta(string nombre_objeto, string nombre_de_base, string nombre_servidor)
        {
            SqlConnectionStringBuilder string_de_conexion_nuevo = new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = nombre_servidor;
            string_de_conexion_nuevo["integrated Security"] = true;
            string_de_conexion_nuevo["Initial Catalog"] = nombre_de_base;

            SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;


            try
            {

                string sentencia_existe_elemento = QueryManager.SentenciaExisteElemento(nombre_objeto);

                SqlCommand comando_validacion = new SqlCommand(sentencia_existe_elemento);
                comando_validacion.Connection = (conexion_nueva);
                comando_validacion.CommandType = CommandType.Text;
                conexion_nueva.Open();
                SqlDataReader reader_validacion = comando_validacion.ExecuteReader();

                while (reader_validacion.Read())
                {
                    if (reader_validacion[0] is DBNull)
                    {
                        reader_validacion.Close();
                        conexion_nueva.Close();
                        return " ";
                    }
                }
                reader_validacion.Close();
                conexion_nueva.Close();

                Server server = new Server(nombre_servidor);
                server.ConnectionContext.LoginSecure = true;

                Database database = new Database();
                database = server.Databases[nombre_de_base];

                Scripter scripter = new Scripter(server);
                Database la_base = server.Databases[nombre_de_base];

                Table tabla_ejemplo = database.Tables[nombre_objeto, @"dbo"];
                StringCollection result = tabla_ejemplo.Script();

                ScriptingOptions options = new ScriptingOptions();
                options.ClusteredIndexes = true;
                options.Default = true;
                options.DriAll = true;
                options.Indexes = true;
                options.SchemaQualify = true;

                options.IncludeHeaders = false;

                StringBuilder sb = new StringBuilder();

                StringCollection coll = tabla_ejemplo.Script(options);
                foreach (string str in coll)
                {
                    sb.Append(str);
                    sb.Append(Environment.NewLine);
                }

                /*
                var script = "";
                foreach (var line in result)
                {
                    script += line;
                }

                */

                return sb.ToString();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static string ObtenerTextoDeTablaManeraLenta(string nombre_objeto, string nombre_de_base, string nombre_servidor,string usuario, string password)
        {
            SqlConnectionStringBuilder string_de_conexion_nuevo = new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = nombre_servidor;
            //string_de_conexion_nuevo["integrated Security"] = false;
            string_de_conexion_nuevo["Initial Catalog"] = nombre_de_base;
            string_de_conexion_nuevo["User Id"] = usuario;
            string_de_conexion_nuevo["Password"] = password;

            SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;


            try
            {

                string sentencia_existe_elemento = QueryManager.SentenciaExisteElemento(nombre_objeto);

                SqlCommand comando_validacion = new SqlCommand(sentencia_existe_elemento);
                comando_validacion.Connection = (conexion_nueva);
                comando_validacion.CommandType = CommandType.Text;
                conexion_nueva.Open();
                SqlDataReader reader_validacion = comando_validacion.ExecuteReader();

                while (reader_validacion.Read())
                {
                    if (reader_validacion[0] is DBNull)
                    {
                        reader_validacion.Close();
                        conexion_nueva.Close();
                        return " ";
                    }
                }
                reader_validacion.Close();
                conexion_nueva.Close();

                Server server = new Server(nombre_servidor);
                server.ConnectionContext.LoginSecure = true;

                Database database = new Database();
                database = server.Databases[nombre_de_base];

                Scripter scripter = new Scripter(server);
                Database la_base = server.Databases[nombre_de_base];

                Table tabla_ejemplo = database.Tables[nombre_objeto, @"dbo"];
                StringCollection result = tabla_ejemplo.Script();

                ScriptingOptions options = new ScriptingOptions();
                options.ClusteredIndexes = true;
                options.Default = true;
                options.DriAll = true;
                options.Indexes = true;
                options.SchemaQualify = true;

                options.IncludeHeaders = false;

                StringBuilder sb = new StringBuilder();

                StringCollection coll = tabla_ejemplo.Script(options);
                foreach (string str in coll)
                {
                    sb.Append(str);
                    sb.Append(Environment.NewLine);
                }

                /*
                var script = "";
                foreach (var line in result)
                {
                    script += line;
                }

                */

                return sb.ToString();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      


        /*esto es viejo*/
        //public static string ObtenerTextoDeTabla_old(string nombre_objeto, string nombre_de_base, string nombre_servidor)
        //{      
        //    SqlConnectionStringBuilder string_de_conexion_nuevo =  new System.Data.SqlClient.SqlConnectionStringBuilder();
        //    string_de_conexion_nuevo["Data Source"] = nombre_servidor;
        //    string_de_conexion_nuevo["integrated Security"] = true;
        //    string_de_conexion_nuevo["Initial Catalog"] = nombre_de_base;

        //    SqlConnection conexion_nueva = new SqlConnection();
        //    conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;
            
        //    try
        //    {
        //        conexion_nueva.Open();
                
        //        string sentencia_existe_elemento = QueryManager.SentenciaExisteElemento(nombre_objeto);

        //        SqlCommand comando_validacion = new SqlCommand(sentencia_existe_elemento);
        //        comando_validacion.Connection = (conexion_nueva);
        //        comando_validacion.CommandType = CommandType.Text;
        //        SqlDataReader reader_validacion = comando_validacion.ExecuteReader();

        //        while (reader_validacion.Read())
        //        {
        //            if (reader_validacion[0] is DBNull)
        //            {
        //                reader_validacion.Close();
        //                conexion_nueva.Close();
        //                return " ";
        //            }
        //        }
        //        reader_validacion.Close();
                
        //        string sentencia_de_tabla = QueryManager.SentenciaTextoTabla() + nombre_objeto;

        //        SqlCommand comando = new SqlCommand(sentencia_de_tabla);
        //        comando.Connection = (conexion_nueva);
        //        comando.CommandType = CommandType.Text;
              
        //        SqlDataReader reader = comando.ExecuteReader();

        //        string resultado_consulta = "";
        //        StringBuilder sb = new StringBuilder();
        //        string resultado_consulta2 = "";
        //        resultado_consulta = "Column_name          Type          Length       Prec       Nullable" + "\r\n";

        //        reader.NextResult();
        //        while (reader.Read())
        //        {
        //            resultado_consulta2 =resultado_consulta2+ reader[0].ToString() + "                  " + reader[1].ToString() + "          " + reader[3].ToString() + "        " + reader[4].ToString() + "      " +  reader[6].ToString()+ "\r\n";
                                  
        //        }
                                    
        //        reader.Close();
        //        conexion_nueva.Close();
        //        return resultado_consulta + "\r\n" + resultado_consulta2;
             
        //    }
        //    catch (Exception ex)
        //    {   
        //        throw ex;
        //    }
        //}






        public static string ObtenerTextoDeTabla(string nombre_objeto, string nombre_de_base, string nombre_servidor, string usuario, string password)
        {
            SqlConnectionStringBuilder string_de_conexion_nuevo = new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = nombre_servidor;
            string_de_conexion_nuevo["Initial Catalog"] = nombre_de_base;
            string_de_conexion_nuevo["User Id"] = usuario;
            string_de_conexion_nuevo["Password"] = password;

            SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;


            try
            {

                string sentencia_existe_elemento = QueryManager.SentenciaExisteElemento(nombre_objeto);

                SqlCommand comando_validacion = new SqlCommand(sentencia_existe_elemento);
                comando_validacion.Connection = (conexion_nueva);
                comando_validacion.CommandType = CommandType.Text;
                conexion_nueva.Open();
                SqlDataReader reader_validacion = comando_validacion.ExecuteReader();

                while (reader_validacion.Read())
                {
                    if (reader_validacion[0] is DBNull)
                    {
                        reader_validacion.Close();
                        conexion_nueva.Close();
                        return " ";
                    }
                }
                reader_validacion.Close();
                conexion_nueva.Close();

                Server server = new Server(nombre_servidor);
                server.ConnectionContext.LoginSecure = false;

                server.ConnectionContext.Login = usuario;
                server.ConnectionContext.Password = password;
                
                Database database = new Database();
                database = server.Databases[nombre_de_base];

                Scripter scripter = new Scripter(server);
                Database la_base = server.Databases[nombre_de_base];

                Table tabla_ejemplo = database.Tables[nombre_objeto, @"dbo"];
                StringCollection result = tabla_ejemplo.Script();

                ScriptingOptions options = new ScriptingOptions();
                options.ClusteredIndexes = true;
                options.Default = true;
                options.DriAll = true;
                options.Indexes = true;
                options.SchemaQualify = true;

                options.IncludeHeaders = false;

                StringBuilder sb = new StringBuilder();

                StringCollection coll = tabla_ejemplo.Script(options);
                foreach (string str in coll)
                {
                    sb.Append(str);
                    sb.Append(Environment.NewLine);
                }

                /*
                var script = "";
                foreach (var line in result)
                {
                    script += line;
                }

                */

                return sb.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        


        //public static void GenerarCopiaDeBase(string nombre_de_base, string ruta_destino)
        //{


        //    SqlConnection conexion = new SqlConnection();
        //    conexion.ConnectionString = ConfigurationManager.ConnectionStrings["ConexionSql"].ConnectionString;

        //    SqlConnection conexion_nueva = new SqlConnection();
        //    conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;

        //    SqlConnectionStringBuilder string_de_conexion_nuevo =
        //    new System.Data.SqlClient.SqlConnectionStringBuilder();
        //    string_de_conexion_nuevo["Data Source"] = conexion.DataSource;
        //    string_de_conexion_nuevo["integrated Security"] = true;
        //    string_de_conexion_nuevo["Initial Catalog"] = nombre_de_base;

        //    try
        //    {
        //        SqlConnection conexion_nueva = new SqlConnection();
        //        conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;

        //        //string sentencia = "SELECT Name FROM sysdatabases WHERE name = " + "'" + nombre_de_base + "'";
        //        string sentencia_de_backup = "backup database " + nombre_de_base + " to disk= " + "'" + ruta_destino + "'" + " with init,stats=10";
        //        conexion_nueva.Open();

        //        // @"backup database BD to disk ='c:\ Respaldo\resp.bak' with init,stats=10", connect

        //        SqlCommand comando = new SqlCommand(sentencia_de_backup);
        //        comando.Connection = (conexion_nueva);

        //        SqlDataReader reader = comando.ExecuteReader(CommandBehavior.CloseConnection);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }



        //}

         
      

        public static List<string> BasesDeDatosExistentes(string direccion_de_servidor,string usuario, string password)
        {
            SqlConnectionStringBuilder string_de_conexion_nuevo =
            new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = direccion_de_servidor;
            string_de_conexion_nuevo["Initial Catalog"] = "master";

            string_de_conexion_nuevo["User Id"] = usuario;
            string_de_conexion_nuevo["Password"] = password;

          SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;


            try
            {
                conexion_nueva.Open();

                string sentencia = QueryManager.SentenciaBasesExistentes();//"select name from master..sysdatabases order by name asc";

                SqlCommand comando = new SqlCommand(sentencia);
                comando.Connection = (conexion_nueva);

                SqlDataReader reader = comando.ExecuteReader(CommandBehavior.CloseConnection);

                List<string> lista_de_nombres = new List<string>();

                while (reader.Read())
                {
                    lista_de_nombres.Add(reader[0].ToString());
                }
                reader.Close();
                conexion_nueva.Close();

                return lista_de_nombres;
            }
            catch (Exception ex)
            {               
                 throw ex;
            }

        }

        public static List<string> BasesDeDatosExistentes(string direccion_de_servidor)
        {
            SqlConnectionStringBuilder string_de_conexion_nuevo =
            new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = direccion_de_servidor;
            string_de_conexion_nuevo["integrated Security"] = true;
            string_de_conexion_nuevo["Initial Catalog"] = "master";
            
            SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;
            
            try
            {
                conexion_nueva.Open();

                string sentencia = QueryManager.SentenciaBasesExistentes();// "select name from master..sysdatabases order by name asc";

                SqlCommand comando = new SqlCommand(sentencia);
                comando.Connection = (conexion_nueva);

                SqlDataReader reader = comando.ExecuteReader(CommandBehavior.CloseConnection);


                List<string> lista_de_nombres = new List<string>();

                while (reader.Read())
                {
                    lista_de_nombres.Add(reader[0].ToString());
                }
                reader.Close();
                conexion_nueva.Close();

                return lista_de_nombres;
            }
            catch (Exception ex)
            {
               throw ex;
            }



        }
         




    }
}

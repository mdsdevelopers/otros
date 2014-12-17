using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DAL
{
    public static class DbSqlManager
    {
        public static bool ExisteServidor(string direccion_de_servidor)
        {
           //SqlConnection conexion = new SqlConnection();
           // conexion.ConnectionString = ConfigurationManager.ConnectionStrings["ConexionSql"].ConnectionString;

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
                return true;
            }
            catch (Exception ex)
            {
               // return false;
              throw ex;
            }

            
        }



        public static List<string> ProcedimientosExistentes(string nombre_de_base)
        {
            SqlConnectionStringBuilder string_de_conexion_nuevo =
            new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = "lachancha";
            string_de_conexion_nuevo["integrated Security"] = true;
            string_de_conexion_nuevo["Initial Catalog"] = "master";

            SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;


      

            try
            {
                conexion_nueva.Open();


              //  string serverVersion = conexion_nueva.ServerVersion;

                string sentencia = "select name from "+ nombre_de_base +"..sysobjects where type = 'p' order by name asc" ;

                SqlCommand comando = new SqlCommand(sentencia);
                comando.Connection = (conexion_nueva);

                SqlDataReader reader = comando.ExecuteReader(CommandBehavior.CloseConnection);



                List<string> lista_de_nombres = new List<string>();

                while (reader.Read())
                {

                    lista_de_nombres.Add(reader[0].ToString());
                }


                return lista_de_nombres;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }



        }





        public static string ObtenerTexto(string nombre_objeto)
        {

             SqlConnectionStringBuilder string_de_conexion_nuevo =
            new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = "lachancha";
            string_de_conexion_nuevo["integrated Security"] = true;
            string_de_conexion_nuevo["Initial Catalog"] = "gbell";

            SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;


            try
            {
                conexion_nueva.Open();

                string sentencia = "sp_helptext ven_factu_lista";

                SqlCommand comando = new SqlCommand(sentencia);
                comando.Connection = (conexion_nueva);
                comando.CommandType = CommandType.Text;
                SqlDataReader reader = comando.ExecuteReader(CommandBehavior.CloseConnection);

               

              string lista_de_nombres ="";
              StringBuilder sb = new StringBuilder();

                while (reader.Read())
                {
                    sb.Append(reader[0].ToString().Replace("\t", "  "));
                    lista_de_nombres=reader[0].ToString();
                }


                return sb.ToString();
            }
            catch (Exception ex)
            {
                //return null;
                 throw ex;
            }



        }


        public static string ObtenerTexto(string nombre_objeto, string nombre_de_base)
        {

            SqlConnectionStringBuilder string_de_conexion_nuevo =
            new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = "lachancha";
            string_de_conexion_nuevo["integrated Security"] = true;
            string_de_conexion_nuevo["Initial Catalog"] = nombre_de_base;

            SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;
            
            try
            {
                conexion_nueva.Open();

                string sentencia = "sp_helptext "+nombre_objeto;

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


                return sb.ToString();
            }
            catch (Exception ex)
            {
                //return null;
                throw ex;
            }



        }


        public static string ObtenerTexto2(string nombre_objeto)
        {

            SqlConnectionStringBuilder string_de_conexion_nuevo =
           new System.Data.SqlClient.SqlConnectionStringBuilder();
            string_de_conexion_nuevo["Data Source"] = "lachancha";
            string_de_conexion_nuevo["integrated Security"] = true;
            string_de_conexion_nuevo["Initial Catalog"] = "GrandBell";

            SqlConnection conexion_nueva = new SqlConnection();
            conexion_nueva.ConnectionString = string_de_conexion_nuevo.ConnectionString;


            try
            {
                conexion_nueva.Open();

                string sentencia = "sp_helptext ven_factu_lista";

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


                return sb.ToString();
            }
            catch (Exception ex)
            {
                //return null;
                throw ex;
            }



        }












    
       // }





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

                string sentencia = "select name from master..sysdatabases order by name asc";

                SqlCommand comando = new SqlCommand(sentencia);
                comando.Connection = (conexion_nueva);

                SqlDataReader reader = comando.ExecuteReader(CommandBehavior.CloseConnection);



                List<string> lista_de_nombres = new List<string>();

                while (reader.Read())
                {

                    lista_de_nombres.Add(reader[0].ToString());


                }


                return lista_de_nombres;
            }
            catch (Exception ex)
            {
                //return null;
                 throw ex;
            }



        }




    }
}

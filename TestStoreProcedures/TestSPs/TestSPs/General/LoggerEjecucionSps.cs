using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class LoggerEjecucionSps
    {
        protected string file_path;

        public LoggerEjecucionSps(string path)
        {
            file_path = path;
        }

        public void LogError(Exception e, SqlCommand comando, string file)
        {
            try
            {
                using (StreamWriter w = File.AppendText(file_path + file))
                {
                    Log("ERROR al ejecutar " + comando.CommandText, w);
                    for (int i = 0; i < comando.Parameters.Count; i++)
                    {
                        var parametro = comando.Parameters[i];
                        var value = "NONE";
                        if (parametro.Value != null)
                            value = parametro.Value.ToString();
                        w.WriteLine(parametro.ParameterName + ": " + value);
                    }
                    w.WriteLine(e.ToString());
                }
            }
            catch (Exception err)
            {
                Console.Write("No se pudo loguear en el archivo " + file_path + file);
            }
        }

        public void LogError(Exception e, SqlCommand comando)
        {
            this.LogError(e, comando, "\\LogERROR.txt");
        }

        public void LogEjecucionCorrecta(string nombre_sp)
        {
            using (StreamWriter w = File.AppendText(file_path + "\\LogOK.txt"))
            {
                Log(nombre_sp + " Ejecutado correctamente", w);
            }
        }

        protected static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }



    }
}

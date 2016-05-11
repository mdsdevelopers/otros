using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using General.Modi;
using General.Repositorios;
using System.Timers;
using System.IO;

namespace FileServerRRHH
{
    public partial class Form1 : Form
    {
        private string path = @"\\calipso\digitalizacion_rrhh\";

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            var timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(RevisarSiHayNovedades);
            timer.Interval = 1000;
            timer.Enabled = true;
            txtLog.Text = "";
            loguear("File Server inicializado");
        }

        private void RevisarSiHayNovedades(object source, ElapsedEventArgs e)
        {
            try
            {
                var conexion_db = new ConexionBDSQL("Data Source=10.80.5.5;Initial Catalog=DB_RRHH;Integrated Security=True");
                var file_system = new FileSystem();

                TablaDeDatos novedades = conexion_db.Ejecutar("dbo.FS_GetNovedades");

                foreach (var row in novedades.Rows)
                {
                    if (!(row.GetObject("nueva") is DBNull))
                    {
                        byte[] imageBytes = Encoding.ASCII.GetBytes(row.GetString("bytes_file"));
                        FileStream fs = new FileStream(path + row.GetInt("id"), FileMode.Create);
                        fs.Write(imageBytes, 0, imageBytes.Count());
                        fs.Close();

                        var parametros = new Dictionary<string, object>();
                        parametros.Add("@id", row.GetInt("id"));

                        conexion_db.Ejecutar("dbo.FS_ArchivoGuardadoConExito", parametros);
                    }

                    if (!(row.GetObject("request") is DBNull))
                    {
                        FileStream fs = new FileStream(path + row.GetInt("id"), FileMode.Open);
                        Byte[] b = new Byte[fs.Length];
                        fs.Read(b, 0, b.Length);
                        fs.Close();

                        var parametros = new Dictionary<string, object>();
                        parametros.Add("@id", row.GetInt("id"));
                        parametros.Add("@bytes", Encoding.ASCII.GetString(b));

                        conexion_db.Ejecutar("dbo.FS_SubirArchivoPedido", parametros);
                    }
                }
            }
            catch (Exception error)
            {
                loguear("error:" + error.Message);
            }
        }

        private void loguear(string mensaje)
        {
            txtLog.Text += "-----------------------------------------------" + "\r\n";
            txtLog.Text += mensaje + "\r\n";
            txtLog.Text += "-----------------------------------------------" + "\r\n";
        }
    }
}

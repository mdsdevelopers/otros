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
        private bool ocupado = false;
        private ConexionBDSQL conexion_db;

        public Form1()
        {
            InitializeComponent();
            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            conexion_db = new ConexionBDSQL("Data Source=10.80.5.5;Initial Catalog=DB_RRHH;Integrated Security=True");        
            
            var timerNovedades = new System.Timers.Timer();
            timerNovedades.Elapsed += new ElapsedEventHandler(RevisarSiHayNovedades);
            timerNovedades.Interval = 1000;
            timerNovedades.Enabled = true;

            var timerCache = new System.Timers.Timer();
            timerCache.Elapsed += new ElapsedEventHandler(evtBorrarCache);
            timerCache.Interval = 600000; //10 minutos
            timerCache.Enabled = true;

            txtLog.Text = "";
            loguear("File Server inicializado");
        }

        private void RevisarSiHayNovedades(object source, ElapsedEventArgs e)
        {
            if (ocupado) return;
            try
            {
                ocupado = true;
                TablaDeDatos novedades = conexion_db.Ejecutar("dbo.FS_GetNovedades");

                foreach (var row in novedades.Rows)
                {
                    if (!(row.GetObject("nueva") is DBNull))
                    {
                        try
                        {
                            byte[] imageBytes = Encoding.ASCII.GetBytes(row.GetString("bytes_file"));
                            FileStream fs = new FileStream(path + row.GetInt("id"), FileMode.Create);
                            fs.Write(imageBytes, 0, imageBytes.Count());
                            fs.Close();

                            var parametros = new Dictionary<string, object>();
                            parametros.Add("@id", row.GetInt("id"));

                            conexion_db.Ejecutar("dbo.FS_ArchivoGuardadoConExito", parametros);
                        } 
                        catch (Exception error)
                        {
                            loguear("Error: " + error.Message);
                            throw;
                        }
                    }

                    if (!(row.GetObject("request") is DBNull))
                    {
                        try
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
                        catch (Exception error)
                        {
                            loguear("Error: " + error.Message);
                            throw;
                        }
                    }
                }
            }
            catch (Exception error)
            {
                loguear("Error: " + error.Message);
            }
            ocupado = false;
        }

        private void loguear(string mensaje)
        {
            txtLog.Text += "-----------------------------------------------" + "\r\n";
            txtLog.Text += DateTime.Now.ToString() + "\r\n";
            txtLog.Text += mensaje + "\r\n";
            txtLog.Text += "-----------------------------------------------" + "\r\n";
            if (chkAutoScroll.Checked == true)
            {
                txtLog.SelectionStart = txtLog.TextLength;
                txtLog.ScrollToCaret();
            }
        }

        private void evtBorrarCache(object source, ElapsedEventArgs e)
        {
            BorrarCache();
        }

        private void BorrarCache()
        {
            try
            {
                var parametros = new Dictionary<string, object>();
                parametros.Add("@tiempo_de_vida_m", 10);
                conexion_db.EjecutarSinResultado("dbo.FS_BorrarCache", parametros);
                loguear("Borrada caché de archivos");
            }
            catch (Exception error)
            {
                loguear("error:" + error.Message);
            }

        }
        private void btnBorrarCache_Click(object sender, EventArgs e)
        {
            BorrarCache();
        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

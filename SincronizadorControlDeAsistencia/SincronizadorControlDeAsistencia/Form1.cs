using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using General.Repositorios;
using General.Modi;
using System.IO;

namespace SincronizadorControlDeAsistencia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            var conexion_db = new ConexionBDSQL("Data Source=10.80.5.5;Initial Catalog=DB_RRHH;Integrated Security=True");
            var file_system = new FileSystem();

            var parametros = new Dictionary<string, object>();
            parametros.Add("@fecha_desde", dtpFechaDesde.Value);
            var tablaIds = conexion_db.Ejecutar("dbo.Acre_GetImagenesUltimasCredenciales", parametros);


            tablaIds.Rows.ForEach((row) =>
            {
                var id_foto = row.GetInt("IdFoto");
                parametros = new Dictionary<string, object>();
                parametros.Add("@id", id_foto);
                var tabla_resultado = conexion_db.Ejecutar("dbo.FS_IniciarPedidoArchivo", parametros);
            });

            var imagenes_descargadas = new List<int>();

            while (tablaIds.Rows.Count > imagenes_descargadas.Count)
            {
                tablaIds.Rows.ForEach((row) =>
                {
                    var id_foto = row.GetInt("IdFoto");
                    if (imagenes_descargadas.Contains(id_foto)) return;

                    parametros = new Dictionary<string, object>();
                    parametros.Add("@id", id_foto);
                    var tabla_resultado = conexion_db.Ejecutar("dbo.FS_ObtenerArchivoPedido", parametros);

                    string bytes_imagen;
                    if (!(tabla_resultado.Rows[0].GetObject("bytes_file") is DBNull))
                    {
                        bytes_imagen = tabla_resultado.Rows[0].GetString("bytes_file");
                        imagenes_descargadas.Add(id_foto);

                        byte[] imageBytes = Convert.FromBase64String(bytes_imagen);
                        MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

                        ms.Write(imageBytes, 0, imageBytes.Length);
                        Image imagen = Image.FromStream(ms, true);
                        imagen.Save("c:\\imagenes\\bla\\" + row.GetInt("nroDocumento") + ".jpg");
                    }

                });
            }
        }
    }
}

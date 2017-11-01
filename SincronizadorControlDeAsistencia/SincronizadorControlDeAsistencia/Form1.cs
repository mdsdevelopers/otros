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
            var conexion_db = new ConexionBDSQL("Data Source=10.80.5.5;Initial Catalog=DB_RRHH_DESA;Integrated Security=True");
            var file_system = new FileSystem();

            var parametros = new Dictionary<string, object>();
            parametros.Add("@fecha_desde", dtpFechaDesde.Text);
            var tablaDatos = conexion_db.Ejecutar("dbo.FS_SubirArchivo", parametros);
            var repo_imagenes = new RepositorioDeImagenes(conexion_db);

            var imagenes_descargadas = new List<int>();

            while (tablaDatos.Rows.Count < imagenes_descargadas.Count)
            {
                tablaDatos.Rows.ForEach((row) =>
                {
                    if (imagenes_descargadas.Contains(row.GetInt("IdFoto"))) return;
                    var imagen = repo_imagenes.GetImagen(row.GetInt("IdFoto"));
                    if (!imagen.reintentar)
                    {
                        imagenes_descargadas.Add(row.GetInt("IdFoto"));
                        file_system.guardarImagenEnPath("", imagen.bytes);
                    }
                });
            }

            //var imagenes = Directory.GetFiles(path, "*.jpg")
            //                             .Select(p => Path.GetFileName(p))
            //                             .ToList();

            //imagenes.ForEach(nombre_imagen =>
            //{
            //    try
            //    {

            //        Image img = file_system.getImagenFromPath(path + "\\" + nombre_imagen);
            //        var ms = new MemoryStream();
            //        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //        byte[] imageBytes = ms.ToArray();
            //        var bytesImagen = Convert.ToBase64String(imageBytes);

            //        var parametros_subir_imagen = new Dictionary<string, object>();
            //        parametros_subir_imagen.Add("@bytes", bytesImagen);
            //        var id_imagen = int.Parse(conexion_db.EjecutarEscalar("dbo.FS_SubirArchivo", parametros_subir_imagen).ToString());

            //        var documento = nombre_imagen.ToLower().Replace(".jpg", "");
            //        var parametros_asignar_imagen = new Dictionary<string, object>();
            //        parametros_asignar_imagen.Add("@documento", documento);
            //        parametros_asignar_imagen.Add("@id_imagen", id_imagen);
            //        conexion_db.Ejecutar("dbo.GEN_AsignarImagenAPersona", parametros_asignar_imagen);

            //        file_system.moverArchivo(path + "\\" + nombre_imagen, path + "\\ImagenesSubidas");
            //    }
            //    catch (Exception)
            //    {

            //    }

            //});
        }
    }
}

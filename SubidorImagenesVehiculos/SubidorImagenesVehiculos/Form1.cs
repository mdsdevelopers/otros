using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using General.Repositorios;
using General.Modi;

namespace SubidorImagenesVehiculos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var path = txtPath.Text;
            var reemplazar_imagenes = optReemplazar.Checked;
            var conexion_db = new ConexionBDSQL("Data Source=10.80.5.5;Initial Catalog=DB_RRHH;Integrated Security=True");
            var file_system = new FileSystem();

            var carpetas = Directory.GetDirectories(path)
                                    .ToList();

            carpetas.ForEach(carpeta =>
            {
                var patente = new DirectoryInfo(carpeta).Name.Replace(" ", "");
                var imagenes = Directory.GetFiles(carpeta, "*.jpg")
                                         .Select(p => Path.GetFileName(p))
                                         .ToList();

                imagenes.ForEach(nombre_imagen =>
                {
                    try
                    {
                        var parametros_bien = new Dictionary<string, object>();
                        parametros_bien.Add("@patente", patente);
                        var id_bien = conexion_db.EjecutarEscalar("dbo.MOBI_GetIdBienPorPatente", parametros_bien);

                        Image img = file_system.getImagenFromPath(carpeta + "\\" + nombre_imagen);
                        var ms = new MemoryStream();
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] imageBytes = ms.ToArray();
                        var bytesImagen = Convert.ToBase64String(imageBytes);

                        var parametros_subir_imagen = new Dictionary<string, object>();
                        parametros_subir_imagen.Add("@bytes", bytesImagen);
                        var id_imagen = int.Parse(conexion_db.EjecutarEscalar("dbo.FS_SubirArchivo", parametros_subir_imagen).ToString());

                        var parametros_asignar_imagen = new Dictionary<string, object>();
                        parametros_asignar_imagen.Add("@idBien", id_bien);
                        parametros_asignar_imagen.Add("@idImagen", id_imagen);
                        conexion_db.Ejecutar("dbo.MOBI_AsignarImagenABien", parametros_asignar_imagen);

                        file_system.moverArchivo(carpeta + "\\" + nombre_imagen, carpeta + "\\ImagenesSubidas");
                    }
                    catch (Exception)
                    {

                    }

                });
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

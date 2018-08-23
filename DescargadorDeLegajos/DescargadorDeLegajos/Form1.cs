using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using General.Repositorios;
using System.IO;

namespace DescargadorDeLegajos
{
    public partial class Form1 : Form
    {
        private string path = @"\\calipso\digitalizacion_rrhh\";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var conexion_db = new ConexionBDSQL("Data Source=10.80.5.5;Initial Catalog=DB_RRHH;Integrated Security=True");
            var parametros = new Dictionary<string, object>();

            parametros.Add("@id_interna", int.Parse(txtLegajo.Text));
            var tablaImagenes = conexion_db.Ejecutar("dbo.MODI_Imagenes_De_Un_Legajo", parametros);
            tablaImagenes.Rows.ForEach((row) =>
            {
                var parametros_foto = new Dictionary<string, object>();

                parametros_foto.Add("@id_imagen", row.GetInt("id_imagen"));
                var tablaFoto = conexion_db.Ejecutar("dbo.MODI_Get_Imagen", parametros_foto);

                var id_foto = tablaFoto.Rows[0].GetInt("id_archivo");

                FileStream fs = new FileStream(path + id_foto, FileMode.Open);
                Byte[] b = new Byte[fs.Length];
                fs.Read(b, 0, b.Length);
                fs.Close();

                string bytes_file = Encoding.ASCII.GetString(b);

                byte[] imageBytes = Convert.FromBase64String(bytes_file);

                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

                ms.Write(imageBytes, 0, imageBytes.Length);
                Image imagen = Image.FromStream(ms, true);

                imagen.Save("C:\\imagenes\\" + id_foto + ".jpg");
            });
        }
    }
}

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
using iTextSharp.text;
using iTextSharp.text.pdf;

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
            var ids = txtLegajo.Text.Split(',');

            foreach (string textid in ids)
            {
                descargarLegajo(int.Parse(textid));
            }            
        }

        private void descargarLegajo(int legajo)
        {
            var conexion_db = new ConexionBDSQL("Data Source=10.80.5.5;Initial Catalog=DB_RRHH;Integrated Security=True");

            var parametros_imagenes = new Dictionary<string, object>();
            parametros_imagenes.Add("@id_interna", legajo);
            var tablaImagenes = conexion_db.Ejecutar("dbo.MODI_Imagenes_De_Un_Legajo", parametros_imagenes);

            var parametros_docs = new Dictionary<string, object>();
            parametros_docs.Add("@legajo", legajo);
            parametros_docs.Add("@id", legajo);
            var tablaDocs = conexion_db.Ejecutar("dbo.LEG_GET_Indice_Documentos", parametros_docs);

            string bytes_file;
            byte[] imageBytes;
            iTextSharp.text.Image pic;

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

                bytes_file = Encoding.ASCII.GetString(b);

                imageBytes = Convert.FromBase64String(bytes_file);

                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

                ms.Write(imageBytes, 0, imageBytes.Length);
                System.Drawing.Image imagen = System.Drawing.Image.FromStream(ms, true);

                if (row.GetObject("id_documento") == null) return;
                var nombre_doc = GetNombreDoc(row.GetInt("id_documento"), tablaDocs);

                Document document = new Document(PageSize.LETTER);
                PdfWriter.GetInstance(document, new FileStream("C:\\imagenes\\" + legajo + '_' + nombre_doc + ".pdf", FileMode.Create));
                document.Open();

                pic = iTextSharp.text.Image.GetInstance(imagen, System.Drawing.Imaging.ImageFormat.Jpeg);

                if (pic.Height > pic.Width)
                {
                    //Maximum height is 800 pixels.
                    float percentage = 0.0f;
                    percentage = 700 / pic.Height;
                    pic.ScalePercent(percentage * 100);
                }
                else
                {
                    //Maximum width is 600 pixels.
                    float percentage = 0.0f;
                    percentage = 540 / pic.Width;
                    pic.ScalePercent(percentage * 100);
                }

                document.Add(pic);
                document.NewPage();
                document.Close();
                ms.Dispose();                
                //imagen.Save("C:\\imagenes\\" + txtLegajo.Text + '_' + id_foto + ".jpg");
            });


        }

        private string GetNombreDoc(int id_doc, TablaDeDatos tablaDocs)
        {
            String nombre = "";
            tablaDocs.Rows.ForEach((row) =>
            {
                var id_doc_en_tabla = row.GetInt("id");
                if (id_doc == id_doc_en_tabla)
                {
                    nombre = row.GetString("TIPO_LUE");
                }
            });
            return nombre.Replace("\\", "-").Replace("/", "-").Replace(":", "-");
        }
    }
}

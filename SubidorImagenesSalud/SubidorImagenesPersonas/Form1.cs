﻿using System;
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


namespace SubidorImagenesPersonas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var path = txtPath.Text;
            var reemplazar_imagenes = optReemplazar.Checked;
            var conexion_db = new ConexionBDSQL("Data Source=10.80.5.5;Initial Catalog=DB_RRHH;Integrated Security=True");
            var file_system = new FileSystem();

            var imagenes = Directory.GetFiles(path, "*.jpg")
                                         .Select(p => Path.GetFileName(p))
                                         .ToList();

            var tabla_personas_sin_foto = conexion_db.Ejecutar("dbo.ACRE_GetPersonasDeSaludSinFoto");

            var doc_personas_sin_foto = new List<int>();
            tabla_personas_sin_foto.Rows.ForEach((row) =>
            {
                doc_personas_sin_foto.Add(row.GetInt("nroDocumento"));
            });


            doc_personas_sin_foto.ForEach(doc_persona =>
            {
                try
                {
                    Image img = file_system.getImagenFromPath(path + "\\" + doc_persona.ToString() + ".jpg");
                    var ms = new MemoryStream();
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] imageBytes = ms.ToArray();
                    var bytesImagen = Convert.ToBase64String(imageBytes);
                    
                    var parametros_subir_imagen = new Dictionary<string, object>();
                    parametros_subir_imagen.Add("@bytes", bytesImagen);
                    var id_imagen = int.Parse(conexion_db.EjecutarEscalar("dbo.FS_SubirArchivo", parametros_subir_imagen).ToString());

                    var parametros_asignar_imagen = new Dictionary<string, object>();
                    parametros_asignar_imagen.Add("@documento", doc_persona);
                    parametros_asignar_imagen.Add("@id_imagen", id_imagen);
                    conexion_db.Ejecutar("dbo.GEN_AsignarImagenAPersona", parametros_asignar_imagen);

                    file_system.moverArchivo(path + "\\" + doc_persona.ToString() + ".jpg", path + "\\ImagenesSubidas");
                }
                catch (Exception error)
                {
                    var a = 'a';

                }

            });
        }
    }
}

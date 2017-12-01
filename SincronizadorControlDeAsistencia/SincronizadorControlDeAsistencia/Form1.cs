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
using System.Configuration;

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
            try
            {

            int cantidad_imagenes = 0;
            var connectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;

            // var conexion_db = new ConexionBDSQL("Data Source=10.80.5.5;Initial Catalog=DB_RRHH_DESA;Integrated Security=True");
            var conexion_db = new ConexionBDSQL(connectionString);
            
                
            var file_system = new FileSystem();
            var parametros = new Dictionary<string, object>();

            Cursor.Current = Cursors.WaitCursor;

            parametros.Add("@fecha_desde", dtpFechaDesde.Value);
            var tablaIds = conexion_db.Ejecutar("dbo.Acre_GetImagenesUltimasCredenciales", parametros);

            if (!tablaIds.Rows.Any()) { Cursor.Current = Cursors.Default; MessageBox.Show("No se encontraron imágenes con la fecha indicada", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

           

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
                       // imagen.Save("c:\\imagenes\\bla\\" + row.GetInt("nroDocumento") + ".jpg");

                        if (!Directory.Exists(txt_destino.Text))
                        {
                            Directory.CreateDirectory(txt_destino.Text); 
                        }
                       
                        imagen.Save(txt_destino.Text + '\\' + row.GetInt("nroDocumento") + ".jpg");
                    }

                });
            }
            Cursor.Current = Cursors.Default;
            cantidad_imagenes = imagenes_descargadas.Count;
            MessageBox.Show("Proceso finalizado. Se descargaron " + cantidad_imagenes.ToString() + " imágenes", "Resultado de Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex )
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Ocurrió una excepción:" + ex.Message + "-" + ex.InnerException, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        
        private void btn_cambiarRutaImagenes_Click(object sender, EventArgs e)
        {
            DialogResult button1_Click = folderBrowserDialog1.ShowDialog();
            txt_destino.Text = folderBrowserDialog1.SelectedPath;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult button2_Click = folderBrowserDialog1.ShowDialog();
            txt_destinoCredenciales.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                     

            var connectionString = ConfigurationManager.ConnectionStrings["Sql"].ConnectionString;
                
            // var conexion_db = new ConexionBDSQL("Data Source=10.80.5.5;Initial Catalog=DB_RRHH_DESA;Integrated Security=True");
            var conexion_db = new ConexionBDSQL(connectionString);
            
            var file_system = new FileSystem();

            Cursor.Current = Cursors.WaitCursor;
            var tablaIds = conexion_db.Ejecutar("dbo.Acre_MigracionCredencialesActivas");
            
            if (!tablaIds.Rows.Any()) { MessageBox.Show("No se encontraron credenciales", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            //
            var lines = new List<string>();

            string[] columnNames = tablaIds.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName).
                                              ToArray();

            var header = string.Join(";", columnNames);
            lines.Add(header);

            var valueLines = tablaIds.AsEnumerable()
                               .Select(row => string.Join(";", row.ItemArray));
            lines.AddRange(valueLines);

            if (!Directory.Exists(txt_destinoCredenciales.Text))
            {
                Directory.CreateDirectory(txt_destinoCredenciales.Text);
            }
           
            File.WriteAllLines(txt_destinoCredenciales.Text+"\\"+ "Credenciales.csv", lines);
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Proceso finalizado. Se encontraron " + tablaIds.Rows.Count.ToString() + " registros", "Resultado de Operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //
                
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Ocurrió una excepción:" + ex.Message + "-" + ex.InnerException, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}

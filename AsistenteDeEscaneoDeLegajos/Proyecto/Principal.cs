using System;
using System.Windows.Forms;
using General.Modi;
using General.Repositorios;

namespace AsistenteDeEscaneoDeLegajos
{
    public partial class Principal : Form
    {
        private ConexionBDSQL conexion_db;
        private FileSystem file_system;
        private ServicioDeCompresionYPersistenciaDeImagenes servicio_de_subida;
        private string path = @"\\ZEUS\RRHHyORG\Organización\DigitalizacionLegajos";
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = this.path;
        }

        private void btnSubirImagenes_Click(object sender, EventArgs e)
        {

            this.conexion_db = new ConexionBDSQL("Data Source=" + this.comboBox1.Text + ";Initial Catalog=DB_RRHH;Integrated Security=True");
            this.file_system = new FileSystem();
            this.servicio_de_subida = new ServicioDeCompresionYPersistenciaDeImagenes(conexion_db,
                file_system,
                path);
            servicio_de_subida.AgregarImagenesSinAsignarDeUnLegajoALaBase(Int32.Parse(this.txtIdInterna.Text));
            MessageBox.Show("Listo");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.path = this.folderBrowserDialog1.SelectedPath;
            this.textBox1.Text = this.path;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppLogic;

namespace SQLMerge
{
    public partial class FrmComparacionSimple : Form
    {
        public FrmComparacionSimple()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            string cadenaConexion = "Data Source=" + txt_servidor.Text + ";Integrated Security=True;Initial Catalog=master";



            Servidor servidor = new Servidor(txt_servidor.Text);

            try
            {

                if (servidor.ConexionRealizada())
                {
                    MessageBox.Show("Conexión Ok");
                    cbo_bases.Items.Clear();
                    cbo_base1.Items.Clear();
                    cbo_base2.Items.Clear();


                    foreach (BaseDeDatos una_base in servidor.BasesDeDatosExistentes())
                    {
                        cbo_bases.Items.Add(una_base.Nombre);
                        cbo_base1.Items.Add(una_base.Nombre);
                        cbo_base2.Items.Add(una_base.Nombre);


                        dataGridView1.DataSource = una_base.Procedimientos(); ;



                    }

                }
                else
                {
                    MessageBox.Show("Conexión falló");

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Conexión falló");


            }




        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_comparar_Click(object sender, EventArgs e)
        {

        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {


            var source = new BindingSource();


            BaseDeDatos base_1 = new BaseDeDatos(cbo_base1.Text);
            BaseDeDatos base_2 = new BaseDeDatos(cbo_base2.Text);


            List<StoredProcedure> proc1 = new List<StoredProcedure>();
            List<StoredProcedure> proc2 = new List<StoredProcedure>();
            proc1 = base_1.Procedimientos();
            proc2 = base_2.Procedimientos();

            source.DataSource = proc1;

            dataGridView1.DataSource = proc1;

            lbl_total_cantidad1.Text = proc1.Count.ToString();
            lbl_total_cantidad2.Text = proc2.Count.ToString();
            dataGridView2.DataSource = proc2;

            DeterminarProcedimientosFaltantes();
            DeterminarProcedimientosDiferentes();
            
        }



        private void cbo_base2_TextChanged(object sender, EventArgs e)
        {
            if ((cbo_base2.Text == cbo_base1.Text) || (cbo_base2.Text == "" || cbo_base1.Text == ""))
            {
                btn_comparar.Enabled = false;
            }
            else
            {
                btn_comparar.Enabled = true;
            }
        }

        private void cbo_base1_TextChanged(object sender, EventArgs e)
        {
            if ((cbo_base2.Text == cbo_base1.Text) || (cbo_base2.Text == "" || cbo_base1.Text == ""))
            {
                btn_comparar.Enabled = false;
            }
            else
            {
                btn_comparar.Enabled = true;
            }
        }


        private void cbo_base1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if ((cbo_base2.Text == cbo_base1.Text) || (cbo_base2.Text == "" || cbo_base1.Text == ""))
            {
                btn_comparar.Enabled = false;
            }
            else
            {
                btn_comparar.Enabled = true;
            }

        }

        private void cbo_base2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cbo_base2.Text == cbo_base1.Text) || (cbo_base2.Text == "" || cbo_base1.Text == ""))
            {
                btn_comparar.Enabled = false;
            }
            else
            {
                btn_comparar.Enabled = true;
            }


        }


        private void DeterminarProcedimientosFaltantes()
        {
            BaseDeDatos base_1 = new BaseDeDatos(cbo_base1.Text);
            BaseDeDatos base_2 = new BaseDeDatos(cbo_base2.Text);
            
            List<StoredProcedure> proc1 = new List<StoredProcedure>();
            List<StoredProcedure> proc2 = new List<StoredProcedure>();
            proc1 = base_1.Procedimientos();
            proc2 = base_2.Procedimientos();
            
            var result = proc2.Except(proc1).Union(proc1.Except(proc2)).ToList();
            
            var result2 = proc2.Except(proc1).ToList();
            var result3 = proc1.Except(proc2).ToList();


            IEnumerable<StoredProcedure> except = proc2.Except(proc1, new StoredProcedure());
            IEnumerable<StoredProcedure> except2 = proc1.Except(proc2, new StoredProcedure());
            
            var a = 0;

            dataGridView3.DataSource = except.ToList();
            dataGridView4.DataSource = except2.ToList();

            lbl_faltantes_de_base_1.Text = except.Count().ToString();
            lbl_faltantes_de_base_2.Text = except2.Count().ToString();

        }

        private void DeterminarProcedimientosDiferentes()
        {

            try
            {

           

            BaseDeDatos base_1 = new BaseDeDatos(cbo_base1.Text);
            BaseDeDatos base_2 = new BaseDeDatos(cbo_base2.Text);

            List<StoredProcedure> proc1 = new List<StoredProcedure>();
            List<StoredProcedure> proc2 = new List<StoredProcedure>();

            List<StoredProcedure> procdiferentes = new List<StoredProcedure>();
            
            proc1 = base_1.Procedimientos();
            proc2 = base_2.Procedimientos();

            var result = proc2.Except(proc1).Union(proc1.Except(proc2)).ToList();

            var result2 = proc2.Except(proc1).ToList();
            var result3 = proc1.Except(proc2).ToList();


            IEnumerable<StoredProcedure> except = proc2.Except(proc1, new StoredProcedure());
            IEnumerable<StoredProcedure> except2 = proc1.Except(proc2, new StoredProcedure());

            var a = 0;

            dataGridView3.DataSource = except.ToList();
            dataGridView4.DataSource = except2.ToList();

            lbl_faltantes_de_base_1.Text = except.Count().ToString();
            lbl_faltantes_de_base_2.Text = except2.Count().ToString();


            string proced1 = "";
            string proced2 = "";

            List<StoredProcedure> proc_faltantes = new List<StoredProcedure>();
         

            foreach (var item in except)
            {
                proc_faltantes.Add(item);
            }
            foreach (var item in except2)
            {
                proc_faltantes.Add(item);
            }

            this.Cursor = Cursors.WaitCursor;
            foreach (var item in proc1)
            {

                if (!proc_faltantes.Exists(p=>p.Nombre ==item.Nombre))
                {
                    
                
                proced1 = base_1.ObtenerTextoDeProcedimiento(item.Nombre);
                proced2 = base_2.ObtenerTextoDeProcedimiento(item.Nombre);

                if (proced1!=proced2)
                {
                    procdiferentes.Add(item);
                }
                }



            }
            this.Cursor = Cursors.Default;
            dataGridView_proc_diferentes.DataSource = null;
            dataGridView_proc_diferentes.DataSource = procdiferentes;
            lbl_proc_diferentes.Text = procdiferentes.Count.ToString();

            MessageBox.Show("Operación realizada correctamente","Validación de operación",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               // throw;
            }


        }




        private void FrmComparacionSimple_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {



            string cadenaConexion = "Data Source=" + txt_servidor.Text + ";Integrated Security=True;Initial Catalog=master";



            Servidor servidor = new Servidor(txt_servidor.Text);

            try
            {

                if (servidor.ConexionRealizada())
                {
                    MessageBox.Show("Conexión Ok");
                    cbo_bases.Items.Clear();
                    cbo_base1.Items.Clear();
                    cbo_base2.Items.Clear();


                    foreach (BaseDeDatos una_base in servidor.BasesDeDatosExistentes())
                    {
                        cbo_bases.Items.Add(una_base.Nombre);
                        cbo_base1.Items.Add(una_base.Nombre);
                        cbo_base2.Items.Add(una_base.Nombre);


                        dataGridView1.DataSource = una_base.Procedimientos(); ;



                    }

                }
                else
                {
                    MessageBox.Show("Conexión falló");

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Conexión falló");


            }











        }

        private void button3_Click(object sender, EventArgs e)
        {

          string texto = "";
          string texto2 = "";
           texto = AppLogic.Servidor.ObtenerProcedimiento(txt_servidor.Text);
           texto2 = AppLogic.Servidor.ObtenerProcedimiento2(txt_servidor.Text);


           bool a = texto.Equals(texto2);

           if (texto==texto2)
           {
               bool b = true;
           }

           MessageBox.Show("asdad","");





        }

        protected override void OnMove(EventArgs e)
        {
            ////
            //// Get the MDI Client window reference
            ////
            //MdiClient mdiClient = null;
            //foreach (Control ctl in MdiParent.Controls)
            //{
            //    mdiClient = ctl as MdiClient;
            //    if (mdiClient != null)
            //        break;
            //}
            ////
            //// Don't allow moving form outside of MDI client bounds
            ////
            //if (Left < mdiClient.ClientRectangle.Left)
            //    Left = mdiClient.ClientRectangle.Left;
            //if (Top < mdiClient.ClientRectangle.Top)
            //    Top = mdiClient.ClientRectangle.Top;
            //if (Top + Height > mdiClient.ClientRectangle.Height)
            //    Top = mdiClient.ClientRectangle.Height - Height;
            //if (Left + Width > mdiClient.ClientRectangle.Width)
            //    Left = mdiClient.ClientRectangle.Width - Width;
            //base.OnMove(e);



            this.CenterToParent();

        }

        

        private void FrmComparacionSimple_LocationChanged(object sender, EventArgs e)
        {
           // this.CenterToParent();
          //  this.Location = FormStartPosition.CenterScreen(); 

      //        int boundWidth = Screen.PrimaryScreen.Bounds.Width;

      //int boundHeight = Screen.PrimaryScreen.Bounds.Height;

      //int x = boundWidth - this.Width;

      //int y = boundHeight - this.Height;


     // this.Location =new Point(this.MdiParent.Width / 2 - this.Width / 2, this.MdiParent.Height / 2 - this.Height / 2);
     // this.Location = new Point(this.MdiParent.Width  -5 , this.MdiParent.Height-5);
   

          //  this.Location =;
        }


















    }
}

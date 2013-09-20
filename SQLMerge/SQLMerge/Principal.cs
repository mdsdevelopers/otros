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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

       

                 
//        private void button1_Click(object sender, EventArgs e)
//        {
       
//            string cadenaConexion = "Data Source=" + txt_servidor.Text + ";Integrated Security=True;Initial Catalog=master";

     

//            Servidor servidor = new Servidor(txt_servidor.Text);
            
//            try
//            {

//                if (servidor.ConexionRealizada())
//                {
//                    MessageBox.Show("Conexión Ok");
//                    cbo_bases.Items.Clear();
//                    cbo_base1.Items.Clear();
//                    cbo_base2.Items.Clear();
                    
                    
//                    foreach (BaseDeDatos una_base in servidor.BasesDeDatosExistentes())
//                    {
//                        cbo_bases.Items.Add(una_base.Nombre);
//                        cbo_base1.Items.Add(una_base.Nombre);
//                        cbo_base2.Items.Add(una_base.Nombre);


//                        dataGridView1.DataSource = una_base.Procedimientos(); ;



//                    }

//                }
//                else
//                {
//                    MessageBox.Show("Conexión falló");

//                }

//            }
//            catch (Exception)
//            {
//                MessageBox.Show("Conexión falló");

               
//            }

         

         
//      }

//        private void cbo_base1_SelectedIndexChanged(object sender, EventArgs e)
//        {

//            if ((cbo_base2.Text == cbo_base1.Text) || (cbo_base2.Text == "" || cbo_base1.Text == ""))
//            {
//                btn_comparar.Enabled = false;
//            }
//            else
//            {
//                btn_comparar.Enabled = true;
//            }

//        }

//        private void cbo_base2_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if ((cbo_base2.Text == cbo_base1.Text)|| (cbo_base2.Text =="" || cbo_base1.Text==""))
//            {
//                btn_comparar.Enabled = false;
//            }
//            else
//            {
//                btn_comparar.Enabled = true;
//            }


//        }

//        private void btn_comparar_Click(object sender, EventArgs e)
//        {
//            var source = new BindingSource();
        
                      
//            BaseDeDatos base_1 = new BaseDeDatos(cbo_base1.Text);
//            BaseDeDatos base_2 = new BaseDeDatos(cbo_base2.Text);


//            List<StoredProcedure> proc1 = new List<StoredProcedure>();
//            List<StoredProcedure> proc2 = new List<StoredProcedure>();
//            proc1 = base_1.Procedimientos();
//            proc2 = base_2.Procedimientos();

//            source.DataSource = proc1;
                     
//            dataGridView1.DataSource = proc1;

//            lbl_total_cantidad1.Text = proc1.Count.ToString();
//            lbl_total_cantidad2.Text = proc2.Count.ToString();
//            dataGridView2.DataSource = proc2;

//            DeterminarProcedimientosFaltantes();

          
// }



       



//        private void DeterminarProcedimientosFaltantes()
//        {
//            BaseDeDatos base_1 = new BaseDeDatos(cbo_base1.Text);
//            BaseDeDatos base_2 = new BaseDeDatos(cbo_base2.Text);



//            List<StoredProcedure> proc1 = new List<StoredProcedure>();
//            List<StoredProcedure> proc2 = new List<StoredProcedure>();
//            proc1 = base_1.Procedimientos();
//            proc2 = base_2.Procedimientos();
            

//            var result = proc2.Except(proc1).Union(proc1.Except(proc2)).ToList();


//            var result2 = proc2.Except(proc1).ToList();
//            var result3 = proc1.Except(proc2).ToList();


//            IEnumerable<StoredProcedure> except =proc2.Except(proc1, new StoredProcedure());
//            IEnumerable<StoredProcedure> except2 = proc1.Except(proc2, new StoredProcedure());
            

//            var a = 0;
               
//            dataGridView3.DataSource = except.ToList();
//            dataGridView4.DataSource = except2.ToList();
         



//        }

//        private void cbo_base2_TextChanged(object sender, EventArgs e)
//        {
//            if ((cbo_base2.Text == cbo_base1.Text) || (cbo_base2.Text == "" || cbo_base1.Text == ""))
//            {
//                btn_comparar.Enabled = false;
//            }
//            else
//            {
//                btn_comparar.Enabled = true;
//            }
//        }

//        private void cbo_base1_TextChanged(object sender, EventArgs e)
//        {
//            if ((cbo_base2.Text == cbo_base1.Text) || (cbo_base2.Text == "" || cbo_base1.Text == ""))
//            {
//                btn_comparar.Enabled = false;
//            }
//            else
//            {
//                btn_comparar.Enabled = true;
//            }
//        }

//        private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
//        {
            
  
//}



        private void ComparacionSimpleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["FrmComparacionSimple"] != null)
            {
                // form is opened, so activate it
                Application.OpenForms["FrmComparacionSimple"].Activate();
            }

            else
             {

            FrmComparacionSimple frm = new FrmComparacionSimple();
            
              //  frm.MdiParent = this;
               // frm.Dock = DockStyle.;
            frm.ShowDialog();


        }


        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {



            switch (MessageBox.Show("¿Desea salir de la aplicación?","Confirmación de operación", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    this.Close();
                    break;

                case DialogResult.No:
                    break;

                case DialogResult.Cancel:
                    break;

            }

      






        }

        //private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        //{

        //    if (Application.OpenForms["FrmCopiaSeguridad"] != null)
        //    {
        //        // form is opened, so activate it
        //        Application.OpenForms["FrmCopiaSeguridad"].Activate();
        //    }

        //    else
        //    {

        //        FrmCopiaSeguridad frm = new FrmCopiaSeguridad();
        //        frm.MdiParent = this;
        //        frm.Show();


        //    }



        //}

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void distintoServidorToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (Application.OpenForms["FrmComparacionServidores"] != null)
            {
                // form is opened, so activate it
                Application.OpenForms["FrmComparacionServidores"].Activate();
            }

            else
             {

            FrmComparacionServidores frm = new FrmComparacionServidores();
            
               //frm.MdiParent = this;
             //   frm.Dock = DockStyle.;
            frm.ShowDialog();




        }









    }

        private void compSimpleToolStripMenuItem_Click(object sender, EventArgs e)
        {


             if (Application.OpenForms["FrmComparacionSimple"] != null)
            {
                // form is opened, so activate it
                Application.OpenForms["FrmComparacionSimple"].Activate();
            }

            else
             {

            FrmComparacionSimple frm = new FrmComparacionSimple();
            
              //  frm.MdiParent = this;
               // frm.Dock = DockStyle.;
            frm.ShowDialog();





        }

    }

        private void cDobleToolStripMenuItem_Click(object sender, EventArgs e)
        {
        

                 if (Application.OpenForms["FrmComparacionServidores"] != null)
            {
                // form is opened, so activate it
                Application.OpenForms["FrmComparacionServidores"].Activate();
            }

            else
             {

            FrmComparacionServidores frm = new FrmComparacionServidores();
            
               //frm.MdiParent = this;
             //   frm.Dock = DockStyle.;
            frm.ShowDialog();


  }





        }

        }


        }
    


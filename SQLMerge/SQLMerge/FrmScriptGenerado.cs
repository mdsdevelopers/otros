using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQLMerge
{
    public partial class FrmScriptGenerado : Form
    {
        public FrmScriptGenerado()
        {
            InitializeComponent();
        }

        private void FrmScriptGenerado_Load(object sender, EventArgs e)
        {

        }

        public void MostrarElementos(string scrip_generado)
        {

            textBox_script_generado.Text = scrip_generado;
         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (EstaVacio(textBox_script_generado.Text))
            {
                return;
            }
          
                Clipboard.SetDataObject(textBox_script_generado.Text, true);
              


        }




        private bool EstaVacio(string elemento)
        {
            if (elemento.Trim().ToString().Length==0)
            {
                return true ;
            }
            return false;
        }

        private void textBox_script_generado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
                textBox_script_generado.SelectAll();
        }

    }
}

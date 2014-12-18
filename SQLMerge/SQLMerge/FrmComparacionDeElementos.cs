﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SQLMerge
{
    public partial class FrmComparacionDeElementos : Form
    {
        
        
        public void MostrarElementos(string elemento1, string elemento2)
        {
            textBox1.ShortcutsEnabled = true;
            textBox2.ShortcutsEnabled = true;
            textBox1.Text = elemento1;
            lbl_longitud_elemento_1.Text = elemento1.Length.ToString();  
            textBox2.Text = elemento2;
            lbl_longitud_elemento_2.Text = elemento2.Length.ToString();  
        
        }

        public FrmComparacionDeElementos()
        {
            InitializeComponent();
         
        }

        private void FrmComparacionDeElementos_Load(object sender, EventArgs e)
        {

        }

      

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
                textBox1.SelectAll();

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
                textBox2.SelectAll();
        }










    }
}
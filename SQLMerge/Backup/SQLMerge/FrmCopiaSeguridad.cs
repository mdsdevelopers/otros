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
    public partial class FrmCopiaSeguridad : Form
    {
        public FrmCopiaSeguridad()
        {
            InitializeComponent();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {




            if (MessageBox.Show("¿Confirma realizar el backup de la base?", "Confirmación de operación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                ////if (!VerificarControles())
                ////{
                ////    MessageBox.Show("Debe completar todos los campos", "Validación de operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ////    return;
                ////}
                //try
                //{
                //    Cursor.Current = Cursors.WaitCursor;
                //    //if (!ExisteBaseDeDatos(NombreDeBaseDeDatos()))
                //    //{
                //    //    Cursor.Current = Cursors.Default;
                //    //    MessageBox.Show("No existe una base de datos con el nombre especificado", "Validación de operación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    //    return;
                //    //}
                //    else
                //    {
                //        Cursor.Current = Cursors.WaitCursor;
                //        AppLogic.Servidor.RealizarCopiaDeSeguridad(NombreDeBaseDeDatos(), RutaCompletaConBase());

                //        Cursor.Current = Cursors.Default;
                //        MessageBox.Show("Se generó la copia de la base de datos correctamente.", "Validación de operación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        return;



                //    }
                //}
                //catch (Exception ex)
                //{
                //    Cursor.Current = Cursors.Default;

                //    MessageBox.Show("Ocurrió una excepción en la operación. " + ex.Message, "Validación de operación", MessageBoxButtons.OK, MessageBoxIcon.Information);


                //    //throw;
                //}

            }












        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppLogic;
using System.Security.Principal;

namespace SQLMerge
{
    public partial class FrmInformacion : Form
    {
        public FrmInformacion()
        {
            InitializeComponent();
        }

        string mensaje_resumen = "";
        private bool EsPosibleConectarseConServidor()
        {

            if (UsarAutenticacionDeWindows())
            {                
                 Servidor server = new Servidor();
                 return server.ConexionRealizadaAutenticacion(Servidor());
            }
            else
            {
                Servidor server = new Servidor();
                return server.ConexionRealizada(Servidor(),Usuario(),Password());
            }
            
            //return false;

        }

        private bool UsarAutenticacionDeWindows()
        {
            return check_autenticacion.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Servidor servidor = new Servidor(txt_servidor.Text);
            try
            {
                if (servidor.ConexionRealizada())
                {
                    MessageBox.Show(MensajeOperacionCorrecta());
                 //   cbo_bases.Items.Clear();
                    cbo_base1.Items.Clear();
                    cbo_base2.Items.Clear();


                    foreach (BaseDeDatos una_base in servidor.BasesDeDatosExistentes(Usuario(),Password()))
                    {
                       // cbo_bases.Items.Add(una_base.Nombre);
                        cbo_base1.Items.Add(una_base.Nombre);
                        cbo_base2.Items.Add(una_base.Nombre);
                        
                    //    dataGridView1.DataSource = una_base.Procedimientos(Servidor(),una_base.Nombre,Usuario(),Password()); ;
                    }

                }
                else
                {
                    MessageBox.Show(MensajeDeConexionIncorrecta());

                }

            }
            catch (Exception)
            {
                MessageBox.Show(MensajeDeConexionIncorrecta());
                return;

            }

        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_comparar_Click(object sender, EventArgs e)
        {

        }

        private bool FaltaSeleccionarBases()
        {

            if (EstaVacio(NombreBase1()) || EstaVacio(NombreBase2()))
            {
                return true;
            }
            return false;        
        
        }


        private bool FaltaIndicarDatosDeConexion()
        {

            if (EstaVacio(Usuario()) || EstaVacio(Servidor()))
            {
                return true;
            }
            return false;

        }



        private bool CompararProcedimientos()
        {

            return check_procedimientos.Checked;

        }

        private bool CompararTablas()
        {
            return check_tablas.Checked;
        }

        private bool CompararTriggers()
        {
            return check_triggers.Checked;
        }

        private bool CompararVistas()
        {
            return check_vistas.Checked;
        }

        private bool CompararFunciones()
        {
            return check_funciones.Checked;
        }


        //private bool HaySeleccionadosElementos()
        //{
        //    return CompararProcedimientos() && CompararTablas();       
        
        //}

        private bool FaltaSeleccionarElementosDeComparacion()
        {
            if ((!CompararProcedimientos() && !CompararTablas() && !CompararTriggers() && !CompararVistas() && !CompararTriggers() && !CompararFunciones()))
            {
                return true;
            }
            return false;
        }


        private string MensajeFaltaEspecificarElementos()
        {
            return "Debe indicar los elementos a comparar.";
        }


        private void RealizarComparacionDeProcedimientos()
        {
            if (CompararProcedimientos())
            {
                DeterminarProcedimientosFaltantes();
                DeterminarProcedimientosDiferentes();
            }
        }


        private void RealizarComparacionDeTablas()
        {

            if (CompararTablas())
            {
                DeterminarTablasFaltantes();
                DeterminarTablasDiferentes();
            }

        }

        private void RealizarComparacionDeTriggers()
        {
            if (CompararTriggers())
            {
                DeterminarTriggersFaltantes();
                DeterminarTriggersDiferentes();

            }

        }

        private void RealizarComparacionDeVistas()
        {
            if (CompararVistas())
            {
                DeterminarVistasFaltantes();
                DeterminarVistasDiferentes();
            }
        }


        private void RealizarComparacionDeFunciones()
        {
            if (CompararFunciones())
            {
                DeterminarFuncionesFaltantes();
                DeterminarFuncionesDiferentes();
            }
        }


        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mensaje_resumen = "";
            groupBox_Resumen.Visible = false;
            if (FaltaSeleccionarBases())
            {
                MessageBox.Show(MensajeFaltaSeleccionarBase(), MensajeValidacionOperacion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MismaBaseSeleccionada())
            {
                MessageBox.Show(MensajeMismaBase(), MensajeValidacionOperacion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (FaltaSeleccionarElementosDeComparacion())
            {
                MessageBox.Show(MensajeFaltaEspecificarElementos(), MensajeValidacionOperacion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
               return;
            }                             
         
            try
            {                          

            if (!EsPosibleConectarseConServidor())
            {
                MessageBox.Show(MensajeDeConexionIncorrecta(), MensajeValidacionOperacion(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LimpiarControlesPorNuevaComparacion();
            
            RealizarComparacionDeProcedimientos();
            RealizarComparacionDeTablas();
            RealizarComparacionDeTriggers();
            RealizarComparacionDeVistas();
            RealizarComparacionDeFunciones();




            GenerarMensajeResumen();

            groupBox_Resumen.Visible = true;

            MessageBox.Show(MensajeOperacionCorrecta(), MensajeValidacionOperacion(), MessageBoxButtons.OK, MessageBoxIcon.Information);




            return;         
            }     
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,MensajeValidacionOperacion(),MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }
        

        private void GenerarMensajeResumen()
        {
            txt_resumen.Text = "";

            if (lbl_proc_faltantes1.Text != "0" || lbl_proc_faltantes2.Text != "0" || lbl_proc_diferentes.Text != "0" )
            {
                mensaje_resumen = "Procedimientos" + "\r\n"; 
            }

            if (lbl_triggers_faltantes1.Text != "0" || lbl_triggers_faltantes2.Text != "0" || lbl_triggers_diferentes.Text != "0")
            {
                mensaje_resumen = mensaje_resumen + "Triggers" + "\r\n";
            }

            if (lbl_tablas_faltantes1.Text != "0" || lbl_tablas_faltantes2.Text != "0" || lbl_tablas_diferentes.Text != "0")
            {
                mensaje_resumen = mensaje_resumen + "Tablas" + "\r\n";
            }


            if (lbl_vistas_faltantes1.Text != "0" || lbl_vistas_faltantes2.Text != "0" || lbl_vistas_diferentes.Text != "0")
            {
                mensaje_resumen = mensaje_resumen + "Vistas" + "\r\n";
            }

            if (lbl_funciones_faltantes1.Text != "0" || lbl_funciones_faltantes2.Text != "0" || lbl_funciones_diferentes.Text != "0")
            {
                mensaje_resumen = mensaje_resumen + "Funciones" + "\r\n";
            }

            if (mensaje_resumen.ToString().Length==0)
            {
                mensaje_resumen = "No hay diferencias";
            }


            txt_resumen.Text = mensaje_resumen;

        }

        private void DeterminarFuncionesFaltantes()
        {

            BaseDeDatos base_1 = new BaseDeDatos(cbo_base1.Text);
            BaseDeDatos base_2 = new BaseDeDatos(cbo_base2.Text);

            List<Funcion> funcion1 = new List<Funcion>();
            List<Funcion> funcion2 = new List<Funcion>();

            if (UsarAutenticacionDeWindows())
            {
                funcion1 = base_1.Funciones(Servidor(), base_1.Nombre);
                funcion2 = base_2.Funciones(Servidor(), base_2.Nombre);
            }
            else
            {
                funcion1 = base_1.Funciones(Servidor(), base_1.Nombre, Usuario(), Password());
                funcion2 = base_2.Funciones(Servidor(), base_2.Nombre, Usuario(), Password());
            }

            var result = funcion2.Except(funcion1).Union(funcion1.Except(funcion2)).ToList();

            var result2 = funcion2.Except(funcion1).ToList();
            var result3 = funcion1.Except(funcion2).ToList();


            IEnumerable<Funcion> except = funcion2.Except(funcion1, new Funcion());
            IEnumerable<Funcion> except2 = funcion1.Except(funcion2, new Funcion());

            GridView_funciones_faltantes1.DataSource = except.ToList();
            GridView_funciones_faltantes2.DataSource = except2.ToList();


            lbl_funciones_faltantes1.Text = except.Count().ToString();
            lbl_funciones_faltantes2.Text = except2.Count().ToString();

            GridView_funciones_faltantes2.Columns["CorrerVw2s"].DisplayIndex = 1;


        }


        private void DeterminarFuncionesDiferentes()
        {
            try
            {
                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());

                List<Funcion> funcion1 = new List<Funcion>();
                List<Funcion> funcion2 = new List<Funcion>();

                List<Funcion> func_diferentes = new List<Funcion>();


                if (UsarAutenticacionDeWindows())
                {
                    funcion1 = base_1.Funciones(Servidor(), base_1.Nombre);
                    funcion2 = base_2.Funciones(Servidor(), base_2.Nombre);
                }
                else
                {
                    funcion1 = base_1.Funciones(Servidor(), base_1.Nombre, Usuario(), Password());
                    funcion2 = base_2.Funciones(Servidor(), base_2.Nombre, Usuario(), Password());
                }


                var result = funcion2.Except(funcion1).Union(funcion1.Except(funcion2)).ToList();

                var result2 = funcion2.Except(funcion1).ToList();
                var result3 = funcion1.Except(funcion2).ToList();


                IEnumerable<Funcion> except = funcion2.Except(funcion1, new Funcion());
                IEnumerable<Funcion> except2 = funcion1.Except(funcion2, new Funcion());


                string funciones1 = "";
                string funciones2 = "";

                List<Funcion> funciones_faltantes = new List<Funcion>();


                foreach (var item in except)
                {
                    funciones_faltantes.Add(item);
                }
                foreach (var item in except2)
                {
                    funciones_faltantes.Add(item);
                }

                this.Cursor = Cursors.WaitCursor;
                foreach (var item in funcion1)
                {

                    if (!funciones_faltantes.Exists(p => p.Nombre == item.Nombre))
                    {

                        if (UsarAutenticacionDeWindows())
                        {
                            funciones1 = base_1.ObtenerTextoDeFuncion(item.Nombre, Servidor());
                            funciones2 = base_2.ObtenerTextoDeFuncion(item.Nombre, Servidor());
                        }
                        else
                        {
                            funciones1 = base_1.ObtenerTextoDeFuncion(item.Nombre, Servidor(), Usuario(), Password());
                            funciones2 = base_2.ObtenerTextoDeFuncion(item.Nombre, Servidor(), Usuario(), Password());
                        }


                        if (funciones1 != funciones2)
                        {
                            func_diferentes.Add(item);
                        }
                    }

                }
                this.Cursor = Cursors.Default;


                GridView_funciones_diferentes.DataSource = null;
                GridView_funciones_diferentes.DataSource = func_diferentes;
                lbl_funciones_diferentes.Text = funciones_faltantes.Count.ToString();

               // MessageBox.Show(MensajeOperacionCorrecta(), MensajeValidacionOperacion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
                //this.Cursor = Cursors.Default;
                //throw;
            }




        }



        /**/



        private void DeterminarVistasFaltantes()
        {

            BaseDeDatos base_1 = new BaseDeDatos(cbo_base1.Text);
            BaseDeDatos base_2 = new BaseDeDatos(cbo_base2.Text);

            List<Vista> vista1 = new List<Vista>();
            List<Vista> vista2 = new List<Vista>();

            if (UsarAutenticacionDeWindows())
            {
                vista1 = base_1.Vistas(Servidor(), base_1.Nombre);
                vista2 = base_2.Vistas(Servidor(), base_2.Nombre);
            }
            else
            {
                vista1 = base_1.Vistas(Servidor(), base_1.Nombre, Usuario(), Password());
                vista2 = base_2.Vistas(Servidor(), base_2.Nombre, Usuario(), Password());
            }


            var result = vista2.Except(vista1).Union(vista1.Except(vista2)).ToList();

            var result2 = vista2.Except(vista1).ToList();
            var result3 = vista1.Except(vista2).ToList();


            IEnumerable<Vista> except = vista2.Except(vista1, new Vista());
            IEnumerable<Vista> except2 = vista1.Except(vista2, new Vista());

            GridView_vistas_faltantes1.DataSource = except.ToList();
            GridView_vistas_faltantes2.DataSource = except2.ToList();


            lbl_vistas_faltantes1.Text = except.Count().ToString();
            lbl_vistas_faltantes2.Text = except2.Count().ToString();

            GridView_vistas_faltantes2.Columns["CorrerVw2s"].DisplayIndex = 1;

        }





        private void DeterminarTriggersFaltantes()
        {

            BaseDeDatos base_1 = new BaseDeDatos(cbo_base1.Text);
            BaseDeDatos base_2 = new BaseDeDatos(cbo_base2.Text);

            List<Trigger> trigger1 = new List<Trigger>();
            List<Trigger> trigger2 = new List<Trigger>();

            if(UsarAutenticacionDeWindows())
            {
                trigger1 = base_1.Triggers(Servidor(), base_1.Nombre);
                trigger2 = base_2.Triggers(Servidor(), base_2.Nombre);
            }
            else
            {
                trigger1 = base_1.Triggers(Servidor(), base_1.Nombre, Usuario(), Password());
                trigger2 = base_2.Triggers(Servidor(), base_2.Nombre, Usuario(), Password());
            }


            var result = trigger2.Except(trigger1).Union(trigger1.Except(trigger2)).ToList();

            var result2 = trigger2.Except(trigger1).ToList();
            var result3 = trigger1.Except(trigger2).ToList();


            IEnumerable<Trigger> except = trigger2.Except(trigger1, new Trigger());
            IEnumerable<Trigger> except2 = trigger1.Except(trigger2, new Trigger());

            GridView_triggers_faltantes1.DataSource = except.ToList();
            GridView_triggers_faltantes2.DataSource = except2.ToList();

            GridView_triggers_faltantes2.Columns["CorrerTr2s"].DisplayIndex = 1;

          
            lbl_triggers_faltantes1.Text = except.Count().ToString();
            lbl_triggers_faltantes2.Text = except2.Count().ToString();


        }



        private void DeterminarVistasDiferentes()
        {
            try
            {


                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());

                List<Vista> vista1 = new List<Vista>();
                List<Vista> vista2 = new List<Vista>();

                List<Vista> vist_diferentes = new List<Vista>();


                if (UsarAutenticacionDeWindows())
                {
                    vista1 = base_1.Vistas(Servidor(), base_1.Nombre);
                    vista2 = base_2.Vistas(Servidor(), base_2.Nombre);
                }
                else
                {
                    vista1 = base_1.Vistas(Servidor(), base_1.Nombre, Usuario(), Password());
                    vista2 = base_2.Vistas(Servidor(), base_2.Nombre, Usuario(), Password());
                }


                var result = vista2.Except(vista1).Union(vista1.Except(vista2)).ToList();

                var result2 = vista2.Except(vista1).ToList();
                var result3 = vista1.Except(vista2).ToList();


                IEnumerable<Vista> except = vista2.Except(vista1, new Vista());
                IEnumerable<Vista> except2 = vista1.Except(vista2, new Vista());


                string vistas1 = "";
                string vistas2 = "";

                List<Vista> vistas_faltantes = new List<Vista>();


                foreach (var item in except)
                {
                    vistas_faltantes.Add(item);
                }
                foreach (var item in except2)
                {
                    vistas_faltantes.Add(item);
                }

                this.Cursor = Cursors.WaitCursor;
                foreach (var item in vista1)
                {

                    if (!vistas_faltantes.Exists(p => p.Nombre == item.Nombre))
                    {

                        if (UsarAutenticacionDeWindows())
                        {
                            vistas1 = base_1.ObtenerTextoDeTrigger(item.Nombre, Servidor());
                            vistas2 = base_2.ObtenerTextoDeTrigger(item.Nombre, Servidor());
                        }
                        else
                        {
                            vistas1 = base_1.ObtenerTextoDeTrigger(item.Nombre, Servidor(), Usuario(), Password());
                            vistas2 = base_2.ObtenerTextoDeTrigger(item.Nombre, Servidor(), Usuario(), Password());
                        }


                        if (vistas1 != vistas2)
                        {
                            vist_diferentes.Add(item);
                        }
                    }

                }
                this.Cursor = Cursors.Default;


                GridView_vistas_diferentes.DataSource = null;
                GridView_vistas_diferentes.DataSource = vist_diferentes;
                lbl_vistas_diferentes.Text = vist_diferentes.Count.ToString();

               // MessageBox.Show(MensajeOperacionCorrecta(), MensajeValidacionOperacion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
                //this.Cursor = Cursors.Default;
                //throw;
            }




        }



















        private void DeterminarTriggersDiferentes()
        {
            try
            {


                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());

                List<Trigger> trigger1 = new List<Trigger>();
                List<Trigger> trigger2 = new List<Trigger>();

                List<Trigger> tabl_diferentes = new List<Trigger>();


                if (UsarAutenticacionDeWindows())
                {
                    trigger1 = base_1.Triggers(Servidor(), base_1.Nombre);
                    trigger2 = base_2.Triggers(Servidor(), base_2.Nombre);
                }
                else
                {
                    trigger1 = base_1.Triggers(Servidor(), base_1.Nombre, Usuario(), Password());
                    trigger2 = base_2.Triggers(Servidor(), base_2.Nombre, Usuario(), Password());
                }


                var result = trigger2.Except(trigger1).Union(trigger1.Except(trigger2)).ToList();

                var result2 = trigger2.Except(trigger1).ToList();
                var result3 = trigger1.Except(trigger2).ToList();


                IEnumerable<Trigger> except = trigger2.Except(trigger1, new Trigger());
                IEnumerable<Trigger> except2 = trigger1.Except(trigger2, new Trigger());

              
                string triggers1 = "";
                string triggers2 = "";

                List<Trigger> tablas_faltantes = new List<Trigger>();


                foreach (var item in except)
                {
                    tablas_faltantes.Add(item);
                }
                foreach (var item in except2)
                {
                    tablas_faltantes.Add(item);
                }

                this.Cursor = Cursors.WaitCursor;
                foreach (var item in trigger1)
                {

                    if (!tablas_faltantes.Exists(p => p.Nombre == item.Nombre))
                    {

                        if (UsarAutenticacionDeWindows())
                        {
                            triggers1 = base_1.ObtenerTextoDeTrigger(item.Nombre, Servidor());
                            triggers2 = base_2.ObtenerTextoDeTrigger(item.Nombre, Servidor());
                        }
                        else
                        {
                            triggers1 = base_1.ObtenerTextoDeTrigger(item.Nombre, Servidor(), Usuario(), Password());
                            triggers2 = base_2.ObtenerTextoDeTrigger(item.Nombre, Servidor(), Usuario(), Password());
                        }


                        if (DesestimarCaracteresDespreciables(triggers1) != DesestimarCaracteresDespreciables(triggers2))
                        {
                            tabl_diferentes.Add(item);
                        }
                    }

                }
                this.Cursor = Cursors.Default;


                GridView_triggers_diferentes.DataSource = null;
                GridView_triggers_diferentes.DataSource = tabl_diferentes;
                lbl_triggers_diferentes.Text = tabl_diferentes.Count.ToString();

               // MessageBox.Show(MensajeOperacionCorrecta(), MensajeValidacionOperacion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
                //this.Cursor = Cursors.Default;
                //throw;
            }

            


        }








        private void DeterminarTablasFaltantes()
        {

            BaseDeDatos base_1 = new BaseDeDatos(cbo_base1.Text);
            BaseDeDatos base_2 = new BaseDeDatos(cbo_base2.Text);

            List<Tabla> tabla1 = new List<Tabla>();
            List<Tabla> tabla2 = new List<Tabla>();

            if (UsarAutenticacionDeWindows())
            {
                tabla1 = base_1.Tablas(Servidor(), base_1.Nombre);
                tabla2 = base_2.Tablas(Servidor(), base_2.Nombre);
            }
            else
            {
                tabla1 = base_1.Tablas(Servidor(), base_1.Nombre, Usuario(), Password());
                tabla2 = base_2.Tablas(Servidor(), base_2.Nombre, Usuario(), Password());
            }


            var result = tabla2.Except(tabla1).Union(tabla1.Except(tabla2)).ToList();

            var result2 = tabla2.Except(tabla1).ToList();
            var result3 = tabla1.Except(tabla2).ToList();


            IEnumerable<Tabla> except = tabla2.Except(tabla1, new Tabla());
            IEnumerable<Tabla> except2 = tabla1.Except(tabla2, new Tabla());


            gridview_tablas_faltantes1.DataSource = except.ToList();
            gridview_tablas_faltantes2.DataSource = except2.ToList();

            gridview_tablas_faltantes2.Columns["CorrerTb2s"].DisplayIndex = 1;

            lbl_tablas_faltantes1.Text = except.Count().ToString();
            lbl_tablas_faltantes2.Text = except2.Count().ToString();


        }


        private void DeterminarTablasDiferentes()
        {
            try
            {
                           

            BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
            BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());

            List<Tabla> tabl1 = new List<Tabla>();
            List<Tabla> tabl2 = new List<Tabla>();

            List<Tabla> tabl_diferentes = new List<Tabla>();


            if (UsarAutenticacionDeWindows())
            {
                tabl1 = base_1.Tablas(Servidor(), base_1.Nombre);
                tabl2 = base_2.Tablas(Servidor(), base_2.Nombre);
            }
            else
            {
                tabl1 = base_1.Tablas(Servidor(), base_1.Nombre, Usuario(), Password());
                tabl2 = base_2.Tablas(Servidor(), base_2.Nombre, Usuario(), Password());
            }


            var result = tabl2.Except(tabl1).Union(tabl1.Except(tabl2)).ToList();

            var result2 = tabl2.Except(tabl1).ToList();
            var result3 = tabl1.Except(tabl2).ToList();


            IEnumerable<Tabla> except = tabl2.Except(tabl1, new Tabla());
            IEnumerable<Tabla> except2 = tabl1.Except(tabl2, new Tabla());

           

            string tablas1 = "";
            string tablas2 = "";

            List<Tabla> tablas_faltantes = new List<Tabla>();
         

            foreach (var item in except)
            {
                tablas_faltantes.Add(item);
            }
            foreach (var item in except2)
            {
                tablas_faltantes.Add(item);
            }

            this.Cursor = Cursors.WaitCursor;
            foreach (var item in tabl1)
            {

                if (!tablas_faltantes.Exists(p => p.Nombre == item.Nombre))
                {

                    if (UsarAutenticacionDeWindows())
                    {
                        tablas1 = base_1.ObtenerTextoDeTabla(item.Nombre, Servidor());
                        tablas2 = base_2.ObtenerTextoDeTabla(item.Nombre, Servidor());
                    }
                    else
                    {
                        tablas1 = base_1.ObtenerTextoDeTabla(item.Nombre, Servidor(), Usuario(), Password());
                        tablas2 = base_2.ObtenerTextoDeTabla(item.Nombre, Servidor(), Usuario(), Password());
                    }


                    if (tablas1 != tablas2)
                {
                    tabl_diferentes.Add(item);
                }
                }

            }
            this.Cursor = Cursors.Default;
            gridview_tablas_diferentes.DataSource = null;
            gridview_tablas_diferentes.DataSource = tabl_diferentes;
           lbl_tablas_diferentes.Text = tabl_diferentes.Count.ToString();

        
            return;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
              
            }                        
        }


        private string NombreBase1()
        {
            if (cbo_base1.Text == "")
            {
                return "";
            }

            return cbo_base1.Text;

        }

        private string NombreBase2()
        {
            if (cbo_base2.Text == "")
            {
                return "";
            }

            return cbo_base2.Text;

        }



        private string Servidor()
        {
            if (txt_servidor.Text == "")
            {
                return "";
            }

            return txt_servidor.Text;

        }


        private string Usuario()
        {
            if (txt_usuario.Text == "")
            {
                return "";
            }

            return txt_usuario.Text;

        }

        private string Password()
        {
            if (txt_password.Text == "")
            {
                return "";
            }

            return txt_password.Text;

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

            if (UsarAutenticacionDeWindows())
            {
                proc1 = base_1.Procedimientos(Servidor(), base_1.Nombre);
                proc2 = base_2.Procedimientos(Servidor(), base_2.Nombre);
            }
            else
            {
                proc1 = base_1.Procedimientos(Servidor(), base_1.Nombre, Usuario(), Password());
                proc2 = base_2.Procedimientos(Servidor(), base_2.Nombre, Usuario(), Password());
            }
          
            
            var result = proc2.Except(proc1).Union(proc1.Except(proc2)).ToList();
            
            var result2 = proc2.Except(proc1).ToList();
            var result3 = proc1.Except(proc2).ToList();


            IEnumerable<StoredProcedure> except = proc2.Except(proc1, new StoredProcedure());
            IEnumerable<StoredProcedure> except2 = proc1.Except(proc2, new StoredProcedure());
            
            gridview_proc_faltantes1.DataSource = except.ToList();
            gridview_proc_faltantes2.DataSource = except2.ToList();

            gridview_proc_faltantes2.Columns["CorrerSp2s"].DisplayIndex = 1;

            lbl_proc_faltantes1.Text = except.Count().ToString();
            lbl_proc_faltantes2.Text = except2.Count().ToString();

        }

        private void DeterminarProcedimientosDiferentes()
        {

            try
            {
                           

            BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
            BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());

            List<StoredProcedure> proc1 = new List<StoredProcedure>();
            List<StoredProcedure> proc2 = new List<StoredProcedure>();

            List<StoredProcedure> procdiferentes = new List<StoredProcedure>();


            if (UsarAutenticacionDeWindows())
            {
                proc1 = base_1.Procedimientos(Servidor(), base_1.Nombre);
                proc2 = base_2.Procedimientos(Servidor(), base_2.Nombre);
            }
            else
            {
                proc1 = base_1.Procedimientos(Servidor(), base_1.Nombre, Usuario(), Password());
                proc2 = base_2.Procedimientos(Servidor(), base_2.Nombre, Usuario(), Password());
            }
          

            var result = proc2.Except(proc1).Union(proc1.Except(proc2)).ToList();

            var result2 = proc2.Except(proc1).ToList();
            var result3 = proc1.Except(proc2).ToList();


            IEnumerable<StoredProcedure> except = proc2.Except(proc1, new StoredProcedure());
            IEnumerable<StoredProcedure> except2 = proc1.Except(proc2, new StoredProcedure());

           

            gridview_proc_faltantes1.DataSource = except.ToList();
            gridview_proc_faltantes2.DataSource = except2.ToList();

            lbl_proc_faltantes1.Text = except.Count().ToString();
            lbl_proc_faltantes2.Text = except2.Count().ToString();


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


                    if (UsarAutenticacionDeWindows())
                    {
                        proced1 = base_1.ObtenerTextoDeProcedimiento(item.Nombre, Servidor());
                        proced2 = base_2.ObtenerTextoDeProcedimiento(item.Nombre, Servidor());
                    }
                    else
                    {
                        proced1 = base_1.ObtenerTextoDeProcedimiento(item.Nombre, Servidor(), Usuario(), Password());
                        proced2 = base_2.ObtenerTextoDeProcedimiento(item.Nombre, Servidor(), Usuario(), Password());
                    }


                if (DesestimarCaracteresDespreciables(proced1) != DesestimarCaracteresDespreciables(proced2))
                {
                    procdiferentes.Add(item);
                }
                }

            }
            this.Cursor = Cursors.Default;
            GridView_proc_diferentes.DataSource = null;
            GridView_proc_diferentes.DataSource = procdiferentes;
            lbl_proc_diferentes.Text = procdiferentes.Count.ToString();

           // MessageBox.Show(MensajeOperacionCorrecta(), MensajeValidacionOperacion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
               //this.Cursor = Cursors.Default;
               //throw;
            }


        }


        private string DesestimarCaracteresDespreciables(string original)
        {
            return original.Replace(" ", "").Replace("   ", "").Replace("[", "").Replace("]", "").Replace(Environment.NewLine, "").Replace("-", "");

            //if (proced1.ToUpper().Replace(@"\r\n?|\n", string.Empty).Replace(" ", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty).Replace(" ", "").Replace("   ", "").Replace("[", "").Replace("]", "").Replace(Environment.NewLine, "").Replace("-", "") != proced2.ToUpper().Replace(@"\r\n?|\n", string.Empty).Replace(" ", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty).Replace(" ", "").Replace("   ", "").Replace("[", "").Replace("]", "").Replace(Environment.NewLine, "").Replace("-", ""))


        }


        private void FrmComparacionSimple_Load(object sender, EventArgs e)
        {
            //this.CenterToParent();
        }


        private bool EstaVacio(string campo_a_validar)
        {
            if (campo_a_validar.Length==0)
            {
                return true;
            }
            return false;

            
        }


        private void button1_Click_1(object sender, EventArgs e)
        {


            if (FaltaIndicarDatosDeConexion())
            {
                MessageBox.Show(MensajeDebeInformarDatosDeConexion(), MensajeValidacionOperacion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            Servidor servidor = new Servidor(Servidor(),Usuario(),Password());



            try
            {         
     
               // EsPosibleConectarseConServidor()
                if ( EsPosibleConectarseConServidor())
                {

                    MessageBox.Show(MensajeDeConexionCorrecta(), MensajeValidacionOperacion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // cbo_bases.Items.Clear();
                    cbo_base1.Items.Clear();
                    cbo_base2.Items.Clear();
                    DeshabilitarControlesPorConexion();
                    btn_comparar.Enabled = true;


                    List<BaseDeDatos> lista_de_bases = new List<BaseDeDatos>();    
                    if (UsarAutenticacionDeWindows())
                    {
                        lista_de_bases = servidor.BasesDeDatosExistentes();
                    }
                    else
                    {
                        lista_de_bases = servidor.BasesDeDatosExistentes(Usuario(), Password());
                    }


                    foreach (BaseDeDatos una_base in lista_de_bases)
                    {
                       // cbo_bases.Items.Add(una_base.Nombre);
                        cbo_base1.Items.Add(una_base.Nombre);
                        cbo_base2.Items.Add(una_base.Nombre);
                       // dataGridView1.DataSource = una_base.Procedimientos(); ;

                    }
                }
                else
                {
                    MessageBox.Show(MensajeDeConexionIncorrecta(), MensajeValidacionOperacion(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }

            }
            catch (Exception)
            {
                MessageBox.Show(MensajeDeConexionIncorrecta(), MensajeValidacionOperacion(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;


            }

        }


        private bool MismaBaseSeleccionada()
        {

            if (cbo_base1.Text == cbo_base2.Text)
            {
                return true;
            }

            return false;
        }

        private void DeshabilitarControlesPorConexion()
        {

            txt_password.Enabled = false;
            txt_servidor.Enabled = false;
            txt_usuario.Enabled = false;
            check_autenticacion.Enabled = false;
            btn_conectar.Enabled = false;

        }

        private string MensajeDeConexionCorrecta()
        {
            return "Conexión realizada correctamente.";
        }

        private string MensajeDebeInformarDatosDeConexion()
        {
            return "Debe informar los datos de conexiòn.";
        }

        private string MensajeOperacionCorrecta()
        {
            return "Operación realizada correctamente.";
        }


        private string MensajeDeConexionIncorrecta()
        {
            return "Datos de conexión incorrectos.";
        }

        private string MensajeFaltaSeleccionarBase()
        {
            return "Debe indicar la base de datos.";
        }

        private string MensajeMismaBase()
        {
            return "Debe indicar otra base de datos para comparar.";
        }

        private string MensajeValidacionOperacion()
        {
            return "Validación de operación.";
        }

        protected override void OnMove(EventArgs e)
        {
           
           // this.CenterToParent();

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

        private void check_autenticacion_CheckedChanged(object sender, EventArgs e)
        {
            if (check_autenticacion.AutoCheck == true)
            {
                var usuario_de_windows = WindowsIdentity.GetCurrent();

                txt_password.Enabled = false;
                txt_servidor.Enabled = true;
                txt_usuario.Enabled = false;
                txt_usuario.Text = usuario_de_windows.Name;
            }
            else
            {
                txt_password.Enabled = true;
                txt_servidor.Enabled = true;
                txt_usuario.Enabled = true;
                txt_usuario.Text = "";
            }


        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HabilitarControles();
        }




        private void HabilitarControles()
        {
            groupBox_Resumen.Visible = false;
            mensaje_resumen = "";
            check_autenticacion.Enabled = true;
            check_autenticacion.Checked = false;
            txt_password.Enabled = true;
            txt_servidor.Enabled = true;
            txt_usuario.Enabled = true;

            txt_password.Text = "";
            txt_servidor.Text = "";
            txt_usuario.Text = "";
           
            btn_comparar.Enabled = false;
            btn_conectar.Enabled = true;

            check_tablas.Checked = false;
            check_triggers.Checked = false;
            check_procedimientos.Checked = false;
            check_vistas.Checked = false;
            check_funciones.Checked = false;

            cbo_base1.Items.Clear();
            cbo_base2.Items.Clear();
           // dataGridView1.DataSource = null;
           // dataGridView2.DataSource = null;
            gridview_proc_faltantes1.DataSource = null;
            gridview_proc_faltantes2.DataSource = null;
            GridView_proc_diferentes.DataSource = null;

            gridview_tablas_diferentes.DataSource = null;
            gridview_tablas_faltantes1.DataSource = null;
            gridview_tablas_faltantes2.DataSource = null;

            GridView_triggers_diferentes.DataSource = null;
            GridView_triggers_faltantes1.DataSource = null;
            GridView_triggers_faltantes2.DataSource = null;

            GridView_vistas_diferentes.DataSource = null;
            GridView_vistas_faltantes1.DataSource = null;
            GridView_vistas_faltantes2.DataSource = null;

            GridView_funciones_diferentes.DataSource = null;
            GridView_funciones_faltantes1.DataSource = null;
            GridView_funciones_faltantes2.DataSource = null;
            
            lbl_proc_faltantes1.Text = "0";
            lbl_proc_faltantes2.Text = "0";
            lbl_proc_diferentes.Text = "0";
            
            lbl_tablas_faltantes1.Text = "0";
            lbl_tablas_faltantes2.Text = "0";
            lbl_tablas_diferentes.Text = "0";
            
            lbl_triggers_diferentes.Text = "0";
            lbl_triggers_faltantes1.Text = "0";
            lbl_triggers_faltantes2.Text = "0";
            
            lbl_vistas_diferentes.Text = "0";
            lbl_vistas_faltantes1.Text = "0";
            lbl_vistas_faltantes2.Text = "0";

            lbl_funciones_diferentes.Text = "0";
            lbl_funciones_faltantes1.Text = "0";
            lbl_funciones_faltantes2.Text = "0";

            
           // lbl_total_cantidad1.Text = "0";
           // lbl_total_cantidad2.Text = "0";

        }

        private void LimpiarControlesPorNuevaComparacion()
        {

            gridview_proc_faltantes1.DataSource = null;
            gridview_proc_faltantes2.DataSource = null;
            GridView_proc_diferentes.DataSource = null;

            gridview_tablas_diferentes.DataSource = null;
            gridview_tablas_faltantes1.DataSource = null;
            gridview_tablas_faltantes2.DataSource = null;

            GridView_triggers_diferentes.DataSource = null;
            GridView_triggers_faltantes1.DataSource = null;
            GridView_triggers_faltantes2.DataSource = null;

            GridView_vistas_diferentes.DataSource = null;
            GridView_vistas_faltantes1.DataSource = null;
            GridView_vistas_faltantes2.DataSource = null;

            GridView_funciones_diferentes.DataSource = null;
            GridView_funciones_faltantes1.DataSource = null;
            GridView_funciones_faltantes2.DataSource = null;

            lbl_proc_faltantes1.Text = "0";
            lbl_proc_faltantes2.Text = "0";
            lbl_proc_diferentes.Text = "0";

            lbl_tablas_faltantes1.Text = "0";
            lbl_tablas_faltantes2.Text = "0";
            lbl_tablas_diferentes.Text = "0";

            lbl_triggers_diferentes.Text = "0";
            lbl_triggers_faltantes1.Text = "0";
            lbl_triggers_faltantes2.Text = "0";

            lbl_vistas_diferentes.Text = "0";
            lbl_vistas_faltantes1.Text = "0";
            lbl_vistas_faltantes2.Text = "0";

            lbl_funciones_diferentes.Text = "0";
            lbl_funciones_faltantes1.Text = "0";
            lbl_funciones_faltantes2.Text = "0";


        }
        private void GridView_proc_diferentes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (GridView_proc_diferentes.RowCount == 0)
            {
                return;
            }
            else
            {
                DeterminarProcedimientosDiferentes(GridView_proc_diferentes.CurrentCell.Value.ToString());
            }



        }

        private void GridView_triggers_diferentes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (GridView_triggers_diferentes.RowCount == 0)
            {
                return;
            }
            else
            {
                DeterminarTriggersDiferentes(GridView_triggers_diferentes.CurrentCell.Value.ToString());
            }


        }

        private void gridview_tablas_diferentes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (gridview_tablas_diferentes.RowCount == 0)
            {
                return;
            }
            else
            {
                //DeterminarTablasDiferentes(gridview_tablas_diferentes.CurrentCell.Value.ToString());
                DeterminarTablasDiferentesManeraVieja(gridview_tablas_diferentes.CurrentCell.Value.ToString());
            }



        }


        private void DeterminarTablasDiferentesManeraVieja(string nombre_tabla)
        {
            try
            {
                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());

                string tabl1 = "";
                string tabl2 = "";

                if (UsarAutenticacionDeWindows())
                {
                    tabl1 = base_1.ObtenerTextoDeTablaManeraLenta(nombre_tabla, Servidor());
                    tabl2 = base_2.ObtenerTextoDeTablaManeraLenta(nombre_tabla, Servidor());
                }
                else
                {
                    tabl1 = base_1.ObtenerTextoDeTabla(nombre_tabla, Servidor(), Usuario(), Password());
                    tabl2 = base_2.ObtenerTextoDeTabla(nombre_tabla, Servidor(), Usuario(), Password());
                }


             
                AbrirFormularioDeComparacion(tabl1, tabl2);
                return;

            }


            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);

            }


        }





        private void GridView_vistas_diferentes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            if (GridView_vistas_diferentes.RowCount == 0)
            {
                return;
            }
            else
            {
                DeterminarVistasDiferentes(GridView_vistas_diferentes.CurrentCell.Value.ToString());
                
            }







        }

        private void GridView_funciones_diferentes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GridView_funciones_diferentes.RowCount == 0)
            {
                return;
            }
            else
            {
                DeterminarFuncionesDiferentes(GridView_funciones_diferentes.CurrentCell.Value.ToString());
            }

        }


        private void AbrirFormularioDeComparacion(string elemento1, string elemento2)
        {

            FrmComparacionDeElementos frmcomp = new FrmComparacionDeElementos();
            frmcomp.MostrarElementos(elemento1, elemento2);
            frmcomp.ShowDialog();

        }
        
        private void DeterminarProcedimientosDiferentes(string nombre_procedimiento)
        {
            try
            {
                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());

                string proced1 = "";
                string proced2 = "";
                        if (UsarAutenticacionDeWindows())
                        {
                            proced1 = base_1.ObtenerTextoDeProcedimiento(nombre_procedimiento, Servidor());
                            proced2 = base_2.ObtenerTextoDeProcedimiento(nombre_procedimiento, Servidor());
                        }
                        else
                        {
                            proced1 = base_1.ObtenerTextoDeProcedimiento(nombre_procedimiento, Servidor(), Usuario(), Password());
                            proced2 = base_2.ObtenerTextoDeProcedimiento(nombre_procedimiento, Servidor(), Usuario(), Password());
                        }
                        AbrirFormularioDeComparacion(proced1, proced2);
              }   
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);              
            }
        }



        private void DeterminarTablasDiferentes(string nombre_tabla)
        {
            try
            {
                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());

                string tabla1 = "";
                string tabla2 = "";
                if (UsarAutenticacionDeWindows())
                {
                    tabla1 = base_1.ObtenerTextoDeTabla(nombre_tabla, Servidor());
                    tabla2 = base_2.ObtenerTextoDeTabla(nombre_tabla, Servidor());
                }
                else
                {
                    tabla1 = base_1.ObtenerTextoDeTabla(nombre_tabla, Servidor(), Usuario(), Password());
                    tabla2 = base_2.ObtenerTextoDeTabla(nombre_tabla, Servidor(), Usuario(), Password());
                }
                AbrirFormularioDeComparacion(tabla1, tabla2);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }


        private void DeterminarVistasDiferentes(string nombre_vista)
        {
            try
            {
                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());

                string vista1 = "";
                string vista2 = "";
                if (UsarAutenticacionDeWindows())
                {
                    vista1 = base_1.ObtenerTextoDeVista(nombre_vista, Servidor());
                    vista2 = base_2.ObtenerTextoDeVista(nombre_vista, Servidor());
                }
                else
                {
                    vista1 = base_1.ObtenerTextoDeVista(nombre_vista, Servidor(), Usuario(), Password());
                    vista2 = base_2.ObtenerTextoDeVista(nombre_vista, Servidor(), Usuario(), Password());
                }
                AbrirFormularioDeComparacion(vista1, vista2);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        private void DeterminarTriggersDiferentes(string nombre_trigger)
        {
            try
            {
                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());

                string trigger1 = "";
                string trigger2 = "";
                if (UsarAutenticacionDeWindows())
                {
                    trigger1 = base_1.ObtenerTextoDeTrigger(nombre_trigger, Servidor());
                    trigger2 = base_2.ObtenerTextoDeTrigger(nombre_trigger, Servidor());
                }
                else
                {
                    trigger1 = base_1.ObtenerTextoDeTrigger(nombre_trigger, Servidor(), Usuario(), Password());
                    trigger2 = base_2.ObtenerTextoDeTrigger(nombre_trigger, Servidor(), Usuario(), Password());
                }
                AbrirFormularioDeComparacion(trigger1, trigger2);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }


        private void DeterminarFuncionesDiferentes(string nombre_funcion)
        {
            try
            {
                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());

                string funcion1 = "";
                string funcion2 = "";
                if (UsarAutenticacionDeWindows())
                {
                    funcion1 = base_1.ObtenerTextoDeTrigger(nombre_funcion, Servidor());
                    funcion2 = base_2.ObtenerTextoDeTrigger(nombre_funcion, Servidor());
                }
                else
                {
                    funcion1 = base_1.ObtenerTextoDeTrigger(nombre_funcion, Servidor(), Usuario(), Password());
                    funcion2 = base_2.ObtenerTextoDeTrigger(nombre_funcion, Servidor(), Usuario(), Password());
                }
                AbrirFormularioDeComparacion(funcion1, funcion2);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_script_proc_faltantes_1_Click(object sender, EventArgs e)
        {

            if (gridview_proc_faltantes1.Rows.Count == 0)
            {
                return;
            }

            List<StoredProcedure> lista_de_procedimientos = new List<StoredProcedure>();

            foreach (DataGridViewRow Fila in gridview_proc_faltantes1.Rows)
            {

                StoredProcedure procedimiento_en_fila = new StoredProcedure(Fila.Cells[0].Value.ToString());
                lista_de_procedimientos.Add(procedimiento_en_fila);

            }

            GenerarScriptProcedimientosFaltantesBase1(lista_de_procedimientos);



        }

        private void AbrirFormularioDeScript(string script_generado)
        {
            FrmScriptGenerado form = new FrmScriptGenerado();
            form.MostrarElementos(script_generado);
            form.ShowDialog();            
        }


        private void GenerarScriptProcedimientosFaltantesBase1(List<StoredProcedure> lista_de_procedimientos)
        {
            try
            {

                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());
                List<StoredProcedure> procdiferentes = new List<StoredProcedure>();

                string script_generado = "";

                foreach (StoredProcedure procedimiento in lista_de_procedimientos)
                {
                    if (UsarAutenticacionDeWindows())
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeProcedimiento(procedimiento.Nombre, Servidor()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                    else
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeProcedimiento(procedimiento.Nombre, Servidor(), Usuario(), Password()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                }

                AbrirFormularioDeScript(script_generado);
                return;
            }


            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);

            }


        }


        private string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.ToUpper().IndexOf(search.ToUpper());
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }


        private void GenerarScriptProcedimientosDiferentesMerge(List<StoredProcedure> lista_de_procedimientos)
        {
            try
            {
                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());
                

                string script_generado1 = "";
                string script_generado2 = "";

                foreach (StoredProcedure procedimiento in lista_de_procedimientos)
                {
                    if (UsarAutenticacionDeWindows())
                    {
                        script_generado1 = script_generado1 + "GO" + "\r\n" + "\r\n" + ReplaceFirst(base_1.ObtenerTextoDeProcedimiento(procedimiento.Nombre, Servidor()),"Create","Alter") + "\r\n" + "\r\n" + "GO" + "\r\n";
                        script_generado2 = script_generado2 + "GO" + "\r\n" + "\r\n" + ReplaceFirst(base_2.ObtenerTextoDeProcedimiento(procedimiento.Nombre, Servidor()),"Create","Alter") + "\r\n" + "\r\n" + "GO" + "\r\n";
                                      
                    }
                    else
                    {
                        script_generado1 = script_generado1 + "GO" + "\r\n" + "\r\n" + ReplaceFirst(base_1.ObtenerTextoDeProcedimiento(procedimiento.Nombre, Servidor(), Usuario(), Password()), "Create", "Alter") + "\r\n" + "\r\n" + "GO" + "\r\n";
                        script_generado2 = script_generado2 + "GO" + "\r\n" + "\r\n" + ReplaceFirst(base_2.ObtenerTextoDeProcedimiento(procedimiento.Nombre, Servidor(), Usuario(), Password()),"Create","Alter") + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                }

               
                AbrirFormularioDeComparacion(script_generado1, script_generado2);

                return;
            }


            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);

            }


        }


        private void GenerarScriptTriggersDiferentesMerge(List<Trigger> lista_de_triggers)
        {
            try
            {
                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());
           

                string script_generado1 = "";
                string script_generado2 = "";

                foreach (Trigger trigger in lista_de_triggers)
                {
                    if (UsarAutenticacionDeWindows())
                    {
                        script_generado1 = script_generado1 + "GO" + "\r\n" + "\r\n" + ReplaceFirst(base_1.ObtenerTextoDeTrigger(trigger.Nombre, Servidor()),"Create","Alter") + "\r\n" + "\r\n" + "GO" + "\r\n";
                        script_generado2 = script_generado2 + "GO" + "\r\n" + "\r\n" + ReplaceFirst(base_2.ObtenerTextoDeTrigger(trigger.Nombre, Servidor()),"Create","Alter") + "\r\n" + "\r\n" + "GO" + "\r\n";

                    }
                    else
                    {
                        script_generado1 = script_generado1 + "GO" + "\r\n" + "\r\n" + ReplaceFirst(base_1.ObtenerTextoDeTrigger(trigger.Nombre, Servidor(), Usuario(), Password()),"Create","Alter") + "\r\n" + "\r\n" + "GO" + "\r\n";
                        script_generado2 = script_generado2 + "GO" + "\r\n" + "\r\n" + ReplaceFirst(base_2.ObtenerTextoDeTrigger(trigger.Nombre, Servidor(), Usuario(), Password()), "Create", "Alter") + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                }


                AbrirFormularioDeComparacion(script_generado1, script_generado2);

                return;
            }


            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);

            }


        }



        private void GenerarScriptTablasDiferentesMerge(List<Tabla> lista_de_tablas)
        {
            try
            {
                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());


                string script_generado1 = "";
                string script_generado2 = "";

                foreach (Tabla tabla in lista_de_tablas)
                {
                    if (UsarAutenticacionDeWindows())
                    {
                        script_generado1 = script_generado1 + "GO" + "\r\n" + "\r\n" + base_1.ObtenerTextoDeTablaManeraLenta(tabla.Nombre, Servidor()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                        script_generado2 = script_generado2 + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeTablaManeraLenta(tabla.Nombre, Servidor()) + "\r\n" + "\r\n" + "GO" + "\r\n";

                    }
                    else
                    {
                        script_generado1 = script_generado1 + "GO" + "\r\n" + "\r\n" + base_1.ObtenerTextoDeTablaManeraLenta(tabla.Nombre, Servidor(), Usuario(), Password()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                        script_generado2 = script_generado2 + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeTablaManeraLenta(tabla.Nombre, Servidor(), Usuario(), Password()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                }

                AbrirFormularioDeComparacion(script_generado1, script_generado2);

                return;
            }


            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);

            }


        }


        private void GenerarScriptVistasDiferentesMerge(List<Vista> lista_de_vistas)
        {
            try
            {
                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());


                string script_generado1 = "";
                string script_generado2 = "";

                foreach (Vista vista in lista_de_vistas)
                {
                    if (UsarAutenticacionDeWindows())
                    {
                        script_generado1 = script_generado1 + "GO" + "\r\n" + "\r\n" + ReplaceFirst(base_1.ObtenerTextoDeVista(vista.Nombre, Servidor()),"Create","Alter") + "\r\n" + "\r\n" + "GO" + "\r\n";
                        script_generado2 = script_generado2 + "GO" + "\r\n" + "\r\n" + ReplaceFirst(base_2.ObtenerTextoDeVista(vista.Nombre, Servidor()), "Create", "Alter") + "\r\n" + "\r\n" + "GO" + "\r\n";

                    }
                    else
                    {
                        script_generado1 = script_generado1 + "GO" + "\r\n" + "\r\n" + ReplaceFirst(base_1.ObtenerTextoDeVista(vista.Nombre, Servidor(), Usuario(), Password()),"Create","Alter") + "\r\n" + "\r\n" + "GO" + "\r\n";
                        script_generado2 = script_generado2 + "GO" + "\r\n" + "\r\n" + ReplaceFirst(base_2.ObtenerTextoDeVista(vista.Nombre, Servidor(), Usuario(), Password()), "Create", "Alter") + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                }

                AbrirFormularioDeComparacion(script_generado1, script_generado2);

                return;
            }


            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);

            }


        }

        private void GenerarScriptFuncionesDiferentesMerge(List<Funcion> lista_de_funciones)
        {
            try
            {
                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());


                string script_generado1 = "";
                string script_generado2 = "";

                foreach (Funcion funcion in lista_de_funciones)
                {
                    if (UsarAutenticacionDeWindows())
                    {
                        script_generado1 = script_generado1 + "GO" + "\r\n" + "\r\n" + ReplaceFirst(base_1.ObtenerTextoDeFuncion(funcion.Nombre, Servidor()),"Create","Alter") + "\r\n" + "\r\n" + "GO" + "\r\n";
                        script_generado2 = script_generado2 + "GO" + "\r\n" + "\r\n" + ReplaceFirst(base_2.ObtenerTextoDeFuncion(funcion.Nombre, Servidor()),"Create", "Alter") + "\r\n" + "\r\n" + "GO" + "\r\n";

                    }
                    else
                    {
                        script_generado1 = script_generado1 + "GO" + "\r\n" + "\r\n" + ReplaceFirst(base_1.ObtenerTextoDeFuncion(funcion.Nombre, Servidor(), Usuario(), Password()),"Create","Alter") + "\r\n" + "\r\n" + "GO" + "\r\n";
                        script_generado2 = script_generado2 + "GO" + "\r\n" + "\r\n" + ReplaceFirst(base_2.ObtenerTextoDeFuncion(funcion.Nombre, Servidor(), Usuario(), Password()), "Create", "Alter") + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                }

                AbrirFormularioDeComparacion(script_generado1, script_generado2);

                return;
            }


            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);

            }


        }

















        private void button1_Click_2(object sender, EventArgs e)
        {

            if (gridview_proc_faltantes2.Rows.Count == 0)
            {
                return;
            }

            List<StoredProcedure> lista_de_procedimientos = new List<StoredProcedure>();

            foreach (DataGridViewRow Fila in gridview_proc_faltantes2.Rows)
            {

                StoredProcedure procedimiento_en_fila = new StoredProcedure(Fila.Cells[0].Value.ToString());
                lista_de_procedimientos.Add(procedimiento_en_fila);

            }

            GenerarScriptProcedimientosFaltantesBase2(lista_de_procedimientos);





        }



        private void GenerarScriptProcedimientosFaltantesBase2(List<StoredProcedure> lista_de_procedimientos)
        {
            try
            {

                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                List<StoredProcedure> procdiferentes = new List<StoredProcedure>();

                string script_generado = "";

                foreach (StoredProcedure procedimiento in lista_de_procedimientos)
                {
                    if (UsarAutenticacionDeWindows())
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_1.ObtenerTextoDeProcedimiento(procedimiento.Nombre, Servidor()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                    else
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_1.ObtenerTextoDeProcedimiento(procedimiento.Nombre, Servidor(), Usuario(), Password()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                }

                AbrirFormularioDeScript(script_generado);
                return;
            }


            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (GridView_triggers_faltantes1.Rows.Count == 0)
            {
                return;
            }

            List<Trigger> lista_de_triggers = new List<Trigger>();

            foreach (DataGridViewRow Fila in GridView_triggers_faltantes1.Rows)
            {

                Trigger trigger_en_fila = new Trigger(Fila.Cells[0].Value.ToString());
                lista_de_triggers.Add(trigger_en_fila);

            }

            GenerarScriptTriggersFaltantesBase1(lista_de_triggers);




        }


        private void GenerarScriptTriggersFaltantesBase1(List<Trigger> lista_de_triggers)
        {
            try
            {

                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());
                
                string script_generado = "";

                foreach (Trigger trigger in lista_de_triggers)
                {
                    if (UsarAutenticacionDeWindows())
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeTrigger(trigger.Nombre, Servidor()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                    else
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeTrigger(trigger.Nombre, Servidor(), Usuario(), Password()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                }

                AbrirFormularioDeScript(script_generado);
                return;
            }


            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (GridView_triggers_faltantes2.Rows.Count == 0)
            {
                return;
            }

            List<Trigger> lista_de_triggers = new List<Trigger>();

            foreach (DataGridViewRow Fila in GridView_triggers_faltantes2.Rows)
            {

                Trigger trigger_en_fila = new Trigger(Fila.Cells[0].Value.ToString());
                lista_de_triggers.Add(trigger_en_fila);

            }

            GenerarScriptTriggersFaltantesBase2(lista_de_triggers);



        }


        private void GenerarScriptTriggersFaltantesBase2(List<Trigger> lista_de_triggers)
        {
            try
            {

                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                //List<Trigger> trigdiferentes = new List<Trigger>();

                string script_generado = "";

                foreach (Trigger trigger in lista_de_triggers)
                {
                    if (UsarAutenticacionDeWindows())
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_1.ObtenerTextoDeTrigger(trigger.Nombre, Servidor()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                    else
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_1.ObtenerTextoDeTrigger(trigger.Nombre, Servidor(), Usuario(), Password()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                }

                AbrirFormularioDeScript(script_generado);
                return;
            }


            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (gridview_tablas_faltantes1.Rows.Count == 0)
            {
                return;
            }

            List<Tabla> lista_de_tablas = new List<Tabla>();

            foreach (DataGridViewRow Fila in gridview_tablas_faltantes1.Rows)
            {

                Tabla tabla_en_fila = new Tabla(Fila.Cells[0].Value.ToString());
                lista_de_tablas.Add(tabla_en_fila);

            }

            GenerarScriptTablasFaltantesBase1(lista_de_tablas);
            
            
        }


        private void GenerarScriptTablasFaltantesBase1(List<Tabla> lista_de_tablas)
        {
            try
            {

                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());
                //List<Trigger> trigdiferentes = new List<Trigger>();

                string script_generado = "";

                foreach (Tabla tabla in lista_de_tablas)
                {
                    if (UsarAutenticacionDeWindows())
                    {
                        //script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeTabla(vista.Nombre, Servidor()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeTablaManeraLenta(tabla.Nombre, Servidor()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                
                    }
                    else
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeTablaManeraLenta(tabla.Nombre, Servidor(), Usuario(), Password()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                }

                AbrirFormularioDeScript(script_generado);
                return;
            }


            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);

            }


        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (gridview_tablas_faltantes2.Rows.Count == 0)
            {
                return;
            }

            List<Tabla> lista_de_tablas = new List<Tabla>();

            foreach (DataGridViewRow Fila in gridview_tablas_faltantes2.Rows)
            {

                Tabla tabla_en_fila = new Tabla(Fila.Cells[0].Value.ToString());
                lista_de_tablas.Add(tabla_en_fila);

            }

            GenerarScriptTablasFaltantesBase2(lista_de_tablas);
                        
        }



        private void GenerarScriptTablasFaltantesBase2(List<Tabla> lista_de_tablas)
        {
            try
            {
                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                //List<Trigger> trigdiferentes = new List<Trigger>();

                string script_generado = "";

                foreach (Tabla tabla in lista_de_tablas)
                {
                    if (UsarAutenticacionDeWindows())
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_1.ObtenerTextoDeTablaManeraLenta(tabla.Nombre, Servidor()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                    else
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_1.ObtenerTextoDeTablaManeraLenta(tabla.Nombre, Servidor(), Usuario(), Password()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                }

                AbrirFormularioDeScript(script_generado);
                return;
            }


            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);

            }


        }

        private void button6_Click(object sender, EventArgs e)
        {


            if (GridView_vistas_faltantes1.Rows.Count == 0)
            {
                return;
            }

            List<Vista> lista_de_vistas = new List<Vista>();

            foreach (DataGridViewRow Fila in GridView_vistas_faltantes1.Rows)
            {

                Vista vista_en_fila = new Vista(Fila.Cells[0].Value.ToString());
                lista_de_vistas.Add(vista_en_fila);

            }

            GenerarScriptVistasFaltantesBase1(lista_de_vistas);



        }

        private void GenerarScriptVistasFaltantesBase1(List<Vista> lista_de_vistas)
        {
            try
            {

                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());
                //List<Trigger> trigdiferentes = new List<Trigger>();

                string script_generado = "";

                foreach (Vista vista in lista_de_vistas)
                {
                    if (UsarAutenticacionDeWindows())
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeVista(vista.Nombre, Servidor()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                    else
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeVista(vista.Nombre, Servidor(), Usuario(), Password()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                }

                AbrirFormularioDeScript(script_generado);
                return;
            }


            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);

            }


        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (GridView_vistas_faltantes2.Rows.Count == 0)
            {
                return;
            }

            List<Vista> lista_de_vistas = new List<Vista>();

            foreach (DataGridViewRow Fila in GridView_vistas_faltantes2.Rows)
            {
                Vista vista_en_fila = new Vista(Fila.Cells[0].Value.ToString());
                lista_de_vistas.Add(vista_en_fila);
            }

            GenerarScriptVistasFaltantesBase2(lista_de_vistas);
            
        }


        private void GenerarScriptVistasFaltantesBase2(List<Vista> lista_de_vistas)
        {
            try
            {
                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                //List<Trigger> trigdiferentes = new List<Trigger>();
                string script_generado = "";

                foreach (Vista vista in lista_de_vistas)
                {
                    if (UsarAutenticacionDeWindows())
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_1.ObtenerTextoDeTrigger(vista.Nombre, Servidor()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                    else
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_1.ObtenerTextoDeTrigger(vista.Nombre, Servidor(), Usuario(), Password()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                }

                AbrirFormularioDeScript(script_generado);
                return;
            }

            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);

            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            if (GridView_funciones_faltantes1.Rows.Count == 0)
            {
                return;
            }

            List<Funcion> lista_de_funciones = new List<Funcion>();

            foreach (DataGridViewRow Fila in GridView_funciones_faltantes1.Rows)
            {

                Funcion funcion_en_fila = new Funcion(Fila.Cells[0].Value.ToString());
                lista_de_funciones.Add(funcion_en_fila);

            }

            GenerarScriptFuncionesFaltantesBase1(lista_de_funciones);
        }


        private void GenerarScriptFuncionesFaltantesBase1(List<Funcion> lista_de_funciones)
        {
            try
            {

                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());
                //List<Trigger> trigdiferentes = new List<Trigger>();

                string script_generado = "";

                foreach (Funcion vista in lista_de_funciones)
                {
                    if (UsarAutenticacionDeWindows())
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeFuncion(vista.Nombre, Servidor()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                    else
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeFuncion(vista.Nombre, Servidor(), Usuario(), Password()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                }

                AbrirFormularioDeScript(script_generado);
                return;
            }


            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);

            }


        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (GridView_funciones_faltantes2.Rows.Count == 0)
            {
                return;
            }

            List<Funcion> lista_de_funciones = new List<Funcion>();

            foreach (DataGridViewRow Fila in GridView_funciones_faltantes2.Rows)
            {
                Funcion funcion_en_fila = new Funcion(Fila.Cells[0].Value.ToString());
                lista_de_funciones.Add(funcion_en_fila);
            }
            GenerarScriptFuncionesFaltantesBase2(lista_de_funciones);
      
        }

        private void GenerarScriptFuncionesFaltantesBase2(List<Funcion> lista_de_funciones)
        {
            try
            {
                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                //List<Trigger> trigdiferentes = new List<Trigger>();

                string script_generado = "";

                foreach (Funcion vista in lista_de_funciones)
                {
                    if (UsarAutenticacionDeWindows())
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_1.ObtenerTextoDeFuncion(vista.Nombre, Servidor()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                    else
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_1.ObtenerTextoDeFuncion(vista.Nombre, Servidor(), Usuario(), Password()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                }

                AbrirFormularioDeScript(script_generado);
                return;
            }


            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);

            }


        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (GridView_proc_diferentes.Rows.Count == 0)
            {
                return;
            }
           

            List<StoredProcedure> lista_de_procedimientos = new List<StoredProcedure>();

            foreach (DataGridViewRow Fila in GridView_proc_diferentes.Rows)
            {

                StoredProcedure procedimiento_en_fila = new StoredProcedure(Fila.Cells[0].Value.ToString());
                lista_de_procedimientos.Add(procedimiento_en_fila);

            }

            GenerarScriptProcedimientosDiferentesMerge(lista_de_procedimientos);






        }

        private void GridView_proc_diferentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_script_triggers_diferentes_Click(object sender, EventArgs e)
        {
            if (GridView_triggers_diferentes.Rows.Count == 0)
            {
                return;
            }


            List<Trigger> lista_de_triggers = new List<Trigger>();

            foreach (DataGridViewRow Fila in GridView_triggers_diferentes.Rows)
            {

                Trigger trigger_en_fila = new Trigger(Fila.Cells[0].Value.ToString());
                lista_de_triggers.Add(trigger_en_fila);

            }

            GenerarScriptTriggersDiferentesMerge(lista_de_triggers);



        }

        private void btn_script_tablas_diferentes_Click(object sender, EventArgs e)
        {
            if (gridview_tablas_diferentes.Rows.Count == 0)
            {
                return;
            }


            List<Tabla> lista_de_tablas = new List<Tabla>();

            foreach (DataGridViewRow Fila in gridview_tablas_diferentes.Rows)
            {

                Tabla tabla_en_fila = new Tabla(Fila.Cells[0].Value.ToString());
                lista_de_tablas.Add(tabla_en_fila);

            }

            GenerarScriptTablasDiferentesMerge(lista_de_tablas);
        }

        private void btn_script_vistas_diferentes_Click(object sender, EventArgs e)
        {
             
            if (GridView_vistas_diferentes.Rows.Count == 0)
            {
                return;
            }
            
            List<Vista> lista_de_vistas = new List<Vista>();

            foreach (DataGridViewRow Fila in GridView_triggers_diferentes.Rows)
            {
                Vista vista_en_fila = new Vista(Fila.Cells[0].Value.ToString());
                lista_de_vistas.Add(vista_en_fila);

            }

            GenerarScriptVistasDiferentesMerge(lista_de_vistas);
       

        }

        private void btn_script_funciones_diferentes_Click(object sender, EventArgs e)
        {
            if (GridView_funciones_diferentes.Rows.Count == 0)
            {
                return;
            }

            List<Funcion> lista_de_funciones = new List<Funcion>();

            foreach (DataGridViewRow Fila in GridView_triggers_diferentes.Rows)
            {
                Funcion funcion_en_fila = new Funcion(Fila.Cells[0].Value.ToString());
                lista_de_funciones.Add(funcion_en_fila);

            }

            GenerarScriptFuncionesDiferentesMerge(lista_de_funciones);
        }


        #region CellPainting de celdas

        private void gridview_proc_faltantes1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {


            if (e.ColumnIndex >= 0 && this.gridview_proc_faltantes1.Columns[e.ColumnIndex].Name == "CorrerSp1s" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.gridview_proc_faltantes1.Rows[e.RowIndex].Cells["CorrerSp1s"] as DataGridViewButtonCell;


                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\favicon.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.gridview_proc_faltantes1.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.gridview_proc_faltantes1.Columns[e.ColumnIndex].Width = icoAtomico.Width + 10;

                e.Handled = true;
            }



        }

        private void gridview_proc_faltantes2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {


            if (e.ColumnIndex >= 0 && this.gridview_proc_faltantes2.Columns[e.ColumnIndex].Name == "CorrerSp2s" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.gridview_proc_faltantes2.Rows[e.RowIndex].Cells["CorrerSp2s"] as DataGridViewButtonCell;


                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\favicon.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.gridview_proc_faltantes2.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.gridview_proc_faltantes2.Columns[e.ColumnIndex].Width = icoAtomico.Width + 10;

                e.Handled = true;
            }


        }

        private void GridView_triggers_faltantes1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            

            if (e.ColumnIndex >= 0 && this.GridView_triggers_faltantes1.Columns[e.ColumnIndex].Name == "CorrerTr1s" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.GridView_triggers_faltantes1.Rows[e.RowIndex].Cells["CorrerTr1s"] as DataGridViewButtonCell;


                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\favicon.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.GridView_triggers_faltantes1.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.GridView_triggers_faltantes1.Columns[e.ColumnIndex].Width = icoAtomico.Width + 10;

                e.Handled = true;
            }






        }

        private void GridView_triggers_faltantes2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {



            if (e.ColumnIndex >= 0 && this.GridView_triggers_faltantes2.Columns[e.ColumnIndex].Name == "CorrerTr2s" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.GridView_triggers_faltantes2.Rows[e.RowIndex].Cells["CorrerTr2s"] as DataGridViewButtonCell;


                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\favicon.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.GridView_triggers_faltantes2.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.GridView_triggers_faltantes2.Columns[e.ColumnIndex].Width = icoAtomico.Width + 10;

                e.Handled = true;
            }






        }

        private void gridview_tablas_faltantes1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {


            if (e.ColumnIndex >= 0 && this.gridview_tablas_faltantes1.Columns[e.ColumnIndex].Name == "CorrerTb1s" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.gridview_tablas_faltantes1.Rows[e.RowIndex].Cells["CorrerTb1s"] as DataGridViewButtonCell;


                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\favicon.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.gridview_tablas_faltantes1.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.gridview_tablas_faltantes1.Columns[e.ColumnIndex].Width = icoAtomico.Width + 10;

                e.Handled = true;
            }





        }

        private void gridview_tablas_faltantes2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.gridview_tablas_faltantes2.Columns[e.ColumnIndex].Name == "CorrerTb2s" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.gridview_tablas_faltantes2.Rows[e.RowIndex].Cells["CorrerTb2s"] as DataGridViewButtonCell;


                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\favicon.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.gridview_tablas_faltantes2.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.gridview_tablas_faltantes2.Columns[e.ColumnIndex].Width = icoAtomico.Width + 10;

                e.Handled = true;
            }
        }

        private void GridView_vistas_faltantes1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {


            if (e.ColumnIndex >= 0 && this.GridView_vistas_faltantes1.Columns[e.ColumnIndex].Name == "CorrerVw1s" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.GridView_vistas_faltantes1.Rows[e.RowIndex].Cells["CorrerVw1s"] as DataGridViewButtonCell;


                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\favicon.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.GridView_vistas_faltantes1.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.GridView_vistas_faltantes1.Columns[e.ColumnIndex].Width = icoAtomico.Width + 10;

                e.Handled = true;
            }


        }

        private void GridView_vistas_faltantes2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {


            if (e.ColumnIndex >= 0 && this.GridView_vistas_faltantes1.Columns[e.ColumnIndex].Name == "CorrerVw2s" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.GridView_vistas_faltantes2.Rows[e.RowIndex].Cells["CorrerVw2s"] as DataGridViewButtonCell;


                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\favicon.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.GridView_vistas_faltantes2.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.GridView_vistas_faltantes2.Columns[e.ColumnIndex].Width = icoAtomico.Width + 10;

                e.Handled = true;
            }

        }

        private void GridView_funciones_faltantes1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.ColumnIndex >= 0 && this.GridView_funciones_faltantes1.Columns[e.ColumnIndex].Name == "CorrerFn1s" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.GridView_funciones_faltantes1.Rows[e.RowIndex].Cells["CorrerFn1s"] as DataGridViewButtonCell;


                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\favicon.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.GridView_funciones_faltantes1.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.GridView_funciones_faltantes1.Columns[e.ColumnIndex].Width = icoAtomico.Width + 10;

                e.Handled = true;
            }



        }

        private void GridView_funciones_faltantes2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {


            if (e.ColumnIndex >= 0 && this.GridView_funciones_faltantes2.Columns[e.ColumnIndex].Name == "CorrerFn2s" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = this.GridView_funciones_faltantes2.Rows[e.RowIndex].Cells["CorrerFn2s"] as DataGridViewButtonCell;


                Icon icoAtomico = new Icon(Environment.CurrentDirectory + @"\favicon.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 3, e.CellBounds.Top + 3);

                this.GridView_funciones_faltantes2.Rows[e.RowIndex].Height = icoAtomico.Height + 10;
                this.GridView_funciones_faltantes2.Columns[e.ColumnIndex].Width = icoAtomico.Width + 10;

                e.Handled = true;
            }

        }




#endregion

    }
}

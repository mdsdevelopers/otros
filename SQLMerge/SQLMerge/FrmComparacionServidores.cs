using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using AppLogic;

namespace SQLMerge
{
    public partial class FrmComparacionServidores : Form
    {
        public FrmComparacionServidores()
        {
            InitializeComponent();
        }

        string mensaje_resumen = "";
            IEnumerable<StoredProcedure> proc_faltantes_grilla1; 
            IEnumerable<StoredProcedure> proc_faltantes_grilla2; 

        private void DeshabilitarControlesPorConexion1()
        {

            txt_password.Enabled = false;
            txt_servidor.Enabled = false;
            txt_usuario.Enabled = false;


        }

        private void DeshabilitarControlesPorConexion2()
        {

            txt_password2.Enabled = false;
            txt_servidor2.Enabled = false;
            txt_usuario2.Enabled = false;


        }

        private bool FaltaIndicarDatosDeConexion()
        {

            if (EstaVacio(Usuario()) || EstaVacio(Servidor()))
            {
                return true;
            }
            return false;

        }

        private bool EstaComparandoMismoServidor()
        {
            if (txt_servidor2.Text == txt_servidor.Text)
	        {
                return true;
	        }
            return false;
           
        }

        private void btn_conectar_Click(object sender, EventArgs e)
        {

            /**/

            if (FaltaIndicarDatosDeConexion())
            {
                return;
            }


            if (EstaComparandoMismoServidor())
            {
                return;
            }

            
            Servidor servidor = new Servidor(Servidor(), Usuario(), Password());
            try
            {
               
                if (EsPosibleConectarseConServidor1())
                {

                    MessageBox.Show(MensajeDeConexionCorrecta(), MensajeValidacionOperacion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                    cbo_base1.Items.Clear();
                    cbo_base2.Items.Clear();
                    DeshabilitarControlesPorConexion1();
                    btn_comparar.Enabled = true;
                    
                    List<BaseDeDatos> lista_de_bases = new List<BaseDeDatos>();
                    if (UsarAutenticacionDeWindowsServer1())
                    {
                        lista_de_bases = servidor.BasesDeDatosExistentes();
                    }
                    else
                    {
                        lista_de_bases = servidor.BasesDeDatosExistentes(Usuario(), Password());
                    }
                    
                    foreach (BaseDeDatos una_base in lista_de_bases)
                    {                       
                        cbo_base1.Items.Add(una_base.Nombre);                    
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



        private bool EsPosibleConectarseConServidor1()
        {

            if (UsarAutenticacionDeWindowsServer1())
            {
                Servidor server = new Servidor();
                return server.ConexionRealizadaAutenticacion(Servidor());
            }
            else
            {
                Servidor server = new Servidor();
                return server.ConexionRealizada(Servidor(), Usuario(), Password());
            }

         

        }


        private bool EsPosibleConectarseConServidor2()
        {

            if (UsarAutenticacionDeWindowsServer2())
            {
                Servidor server2 = new Servidor();
                return server2.ConexionRealizadaAutenticacion(Servidor2());
            }
            else
            {
                Servidor server2 = new Servidor();
                return server2.ConexionRealizada(Servidor2(), Usuario2(), Password2());
            }

       
        }



        private bool UsarAutenticacionDeWindowsServer1()
        {
            return check_autenticacion.Checked;
        }


        private bool UsarAutenticacionDeWindowsServer2()
        {
            return check_autenticacion2.Checked;
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


        private string Servidor2()
        {
            if (txt_servidor2.Text == "")
            {
                return "";
            }

            return txt_servidor2.Text;

        }


        private string Usuario2()
        {
            if (txt_usuario2.Text == "")
            {
                return "";
            }

            return txt_usuario2.Text;

        }

        private string Password2()
        {
            if (txt_password2.Text == "")
            {
                return "";
            }

            return txt_password2.Text;

        }



        private bool EstaVacio(string elemento)
        {
            if (elemento.Length==0)
            {
                return true;
            }
            return false;
        }



    

        private string MensajeDeConexionCorrecta()
        {
            return "Conexión realizada correctamente.";
        }


        private string MensajeFaltaEspecificarElementos()
        {
            return "Debe indicar los elementos a comparar.";
        }

        private string MensajeOperacionCorrecta()
        {
            return "Operación realizada correctamente.";
        }


        private string MensajeDeConexionIncorrecta()
        {
            return "Datos de conexión incorrectos.";
        }


        private string MensajeValidacionOperacion()
        {
            return "Validación de operación.";
        }

        private string MensajeFaltaSeleccionarBase()
        {
            return "Debe indicar la base de datos.";
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

        private void check_autenticacion2_CheckedChanged(object sender, EventArgs e)
        {
            if (check_autenticacion.AutoCheck == true)
            {
                var usuario_de_windows = WindowsIdentity.GetCurrent();

                txt_password2.Enabled = false;
                txt_servidor2.Enabled = true;
                txt_usuario2.Enabled = false;
                txt_usuario2.Text = usuario_de_windows.Name;
            }
            else
            {
                txt_password2.Enabled = true;
                txt_servidor2.Enabled = true;
                txt_usuario2.Enabled = true;
                txt_usuario2.Text = "";
            }


        }

        private bool CompararVistas()
        {
            return check_vistas.Checked;
        }

        private bool CompararFunciones()
        {
            return check_funciones.Checked;
        }


        private void HabilitarControles()
        {

            groupBox_Resumen.Visible = false;
            txt_resumen.Text = "";

            check_autenticacion.Checked = false;
            check_autenticacion2.Checked = false;

            txt_password.Enabled = true;
            txt_usuario.Enabled = true;
            txt_servidor.Enabled = true;

            txt_password2.Enabled = true;
            txt_servidor2.Enabled = true;
            txt_usuario2.Enabled = true;

            txt_password.Text = "";
            txt_servidor.Text = "";
            txt_usuario.Text = "";
                                 
            txt_password2.Text = "";
            txt_servidor2.Text = "";
            txt_usuario2.Text = "";
            
            btn_comparar.Enabled = false;
           
            check_tablas.Checked = false;
            check_triggers.Checked = false;
            check_procedimientos.Checked = false;
            check_vistas.Checked = false;
            check_funciones.Checked = false;

            cbo_base1.Items.Clear();
            cbo_base2.Items.Clear();
          

            GridView_proc_diferentes.DataSource = null;
            gridview_proc_faltantes1.DataSource = null;
            gridview_proc_faltantes2.DataSource = null;

            GridView_triggers_diferentes.DataSource = null;
            GridView_triggers_faltantes1.DataSource = null;
            GridView_triggers_faltantes2.DataSource = null;

            gridview_tablas_faltantes1.DataSource = null;
            gridview_tablas_faltantes2.DataSource = null;
            gridview_tablas_diferentes.DataSource = null;

            GridView_vistas_diferentes.DataSource = null;
            GridView_vistas_faltantes1.DataSource = null;
            GridView_vistas_faltantes2.DataSource = null;

            GridView_funciones_diferentes.DataSource = null;
            GridView_funciones_faltantes1.DataSource = null;
            GridView_funciones_faltantes2.DataSource = null;


            lbl_proc_faltantes_de_base_1.Text = "0";
            lbl_proc_faltantes_de_base_2.Text = "0";
            lbl_proc_diferentes.Text = "0";

            lbl_tablas_faltantes1.Text = "0";
            lbl_tablas_faltantes2.Text = "0";
            lbl_tablas_diferentes.Text = "0";

            lbl_triggers_faltantes1.Text = "0";
            lbl_triggers_faltantes2.Text = "0";
            lbl_triggers_diferentes.Text = "0";

            lbl_vistas_diferentes.Text = "0";
            lbl_vistas_faltantes1.Text = "0";
            lbl_vistas_faltantes2.Text = "0";

            lbl_funciones_diferentes.Text = "0";
            lbl_funciones_faltantes1.Text = "0";
            lbl_funciones_faltantes2.Text = "0";



          
        }
        private void btn_conectar2_Click(object sender, EventArgs e)
        {

            if (FaltaIndicarDatosDeConexion())
            {
                return;
            }


            if (EstaComparandoMismoServidor())
            {
                return;
            }

          
            Servidor servidor = new Servidor(Servidor2(), Usuario2(), Password2());
            try
            {

               
                if (EsPosibleConectarseConServidor2())
                {
                    MessageBox.Show(MensajeDeConexionCorrecta(), MensajeValidacionOperacion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                    cbo_base2.Items.Clear();
                    DeshabilitarControlesPorConexion2();
                    btn_comparar.Enabled = true;

                    List<BaseDeDatos> lista_de_bases = new List<BaseDeDatos>();
                    if (UsarAutenticacionDeWindowsServer2())
                    {
                        lista_de_bases = servidor.BasesDeDatosExistentes();
                    }
                    else
                    {
                        lista_de_bases = servidor.BasesDeDatosExistentes(Usuario2(), Password2());
                    }

                    foreach (BaseDeDatos una_base in lista_de_bases)
                    {
                         cbo_base2.Items.Add(una_base.Nombre);                      
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

        private void check_autenticacion_CheckedChanged_1(object sender, EventArgs e)
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


        private bool UsarAutenticacionDeWindows()
        {
            return check_autenticacion.Checked;
        }

        private void check_autenticacion2_CheckedChanged_1(object sender, EventArgs e)
        {


            if (check_autenticacion2.AutoCheck == true)
            {
                var usuario_de_windows = WindowsIdentity.GetCurrent();

                txt_password2.Enabled = false;
                txt_servidor2.Enabled = true;
                txt_usuario2.Enabled = false;
                txt_usuario2.Text = usuario_de_windows.Name;
            }
            else
            {
                txt_password2.Enabled = true;
                txt_servidor2.Enabled = true;
                txt_usuario2.Enabled = true;
                txt_usuario2.Text = "";
            }
                        
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HabilitarControles();
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

        private bool FaltaSeleccionarBases()
        {

            if (EstaVacio(NombreBase1()) || EstaVacio(NombreBase2()))
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



        private bool HaySeleccionadosElementos()
        {

            return CompararProcedimientos() && CompararTablas();


        }


        private bool FaltaSeleccionarElementosDeComparacion()
        {

            if ((!CompararProcedimientos() && !CompararTablas() && !CompararTriggers() && !CompararVistas() && !CompararTriggers() && !CompararFunciones()))
            {
                return true;
            }

            return false;
        
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


        private void btn_comparar_Click(object sender, EventArgs e)
        {
            mensaje_resumen = "";
            groupBox_Resumen.Visible = false;

            if (FaltaSeleccionarBases())
            {
                MessageBox.Show(MensajeFaltaSeleccionarBase(), MensajeValidacionOperacion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (FaltaSeleccionarElementosDeComparacion())
            {
                MessageBox.Show(MensajeFaltaEspecificarElementos(), MensajeValidacionOperacion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            try
            {
                if (!EsPosibleConectarseConServidor1() || !EsPosibleConectarseConServidor2())
                {
                    MessageBox.Show(MensajeDeConexionIncorrecta(), MensajeValidacionOperacion(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                           
                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());


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

                MessageBox.Show(ex.Message);
                return;
            }



        }


        private void GenerarMensajeResumen()
        {
            txt_resumen.Text = "";

            if (lbl_proc_faltantes_de_base_1.Text != "0" || lbl_proc_faltantes_de_base_2.Text != "0" || lbl_proc_diferentes.Text != "0")
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

            if (mensaje_resumen.ToString().Length == 0)
            {
                mensaje_resumen = "No hay diferencias";
            }


            txt_resumen.Text = mensaje_resumen;

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

            lbl_proc_faltantes_de_base_1.Text = "0";
            lbl_proc_faltantes_de_base_2.Text = "0";
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
       
        private void DeterminarFuncionesFaltantes()
        {

            BaseDeDatos base_1 = new BaseDeDatos(cbo_base1.Text);
            BaseDeDatos base_2 = new BaseDeDatos(cbo_base2.Text);

            List<Funcion> funcion1 = new List<Funcion>();
            List<Funcion> funcion2 = new List<Funcion>();

            if (UsarAutenticacionDeWindowsServer1())
            {
             funcion1 = base_1.Funciones(Servidor(), base_1.Nombre);               
            }
            else
	        {
               funcion1 = base_1.Funciones(Servidor(), base_1.Nombre, Usuario(), Password());
	        }

            if (UsarAutenticacionDeWindowsServer2())
            {
                funcion2 = base_2.Funciones(Servidor2(), base_2.Nombre);         
            }
            else
            {
                funcion2 = base_2.Funciones(Servidor2(), base_2.Nombre, Usuario2(), Password2());
            }
           
            
            

            var result = funcion2.Except(funcion1).Union(funcion1.Except(funcion2)).ToList();

            var result2 = funcion2.Except(funcion1).ToList();
            var result3 = funcion1.Except(funcion2).ToList();

            GridView_funciones_faltantes1.AutoResizeColumns();
            GridView_funciones_faltantes2.AutoResizeColumns();


            IEnumerable<Funcion> except = funcion2.Except(funcion1, new Funcion());
            IEnumerable<Funcion> except2 = funcion1.Except(funcion2, new Funcion());

            GridView_funciones_faltantes1.DataSource = except.ToList();
            GridView_funciones_faltantes2.DataSource = except2.ToList();

          
            lbl_funciones_faltantes1.Text = except.Count().ToString();
            lbl_funciones_faltantes2.Text = except2.Count().ToString();
            
        }

        
        private void DeterminarFuncionesDiferentes()
        {
            try
            {
                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());

                List<Funcion> func1 = new List<Funcion>();
                List<Funcion> func2 = new List<Funcion>();

                List<Funcion> func_diferentes = new List<Funcion>();


                if (UsarAutenticacionDeWindowsServer1())
                {
                    func1 = base_1.Funciones(Servidor(), base_1.Nombre);
                }
                else
                {
                    func1 = base_1.Funciones(Servidor(), base_1.Nombre, Usuario(), Password());
                }

                if (UsarAutenticacionDeWindowsServer2())
                {
                    func2 = base_2.Funciones(Servidor2(), base_2.Nombre);
                }
                else
                {
                    func2 = base_2.Funciones(Servidor2(), base_2.Nombre, Usuario2(), Password2());
                }
                
                var result = func2.Except(func1).Union(func1.Except(func2)).ToList();

                var result2 = func2.Except(func1).ToList();
                var result3 = func1.Except(func2).ToList();
                
                IEnumerable<Funcion> except = func2.Except(func1, new Funcion());
                IEnumerable<Funcion> except2 = func1.Except(func2, new Funcion());
                
                dataGridView3.DataSource = except.ToList();
                dataGridView4.DataSource = except2.ToList();

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
                foreach (var item in func1)
                {

                    if (!funciones_faltantes.Exists(p => p.Nombre == item.Nombre))
                    {

                        if (UsarAutenticacionDeWindowsServer1())
                        {
                            funciones1 = base_1.ObtenerTextoDeFuncion(item.Nombre, Servidor());
                       
                        }
                        else
	                    {
                            funciones1 = base_1.ObtenerTextoDeFuncion(item.Nombre, Servidor(), Usuario(), Password());
	                    }
                        
                        if (UsarAutenticacionDeWindowsServer2())
                        {
                            funciones2 = base_2.ObtenerTextoDeFuncion(item.Nombre, Servidor2());
                        }
                        else
                        {
                            funciones2 = base_2.ObtenerTextoDeFuncion(item.Nombre, Servidor2(), Usuario2(), Password2());
                        }

                        if (funciones1.ToUpper().Replace(@"\r\n?|\n", string.Empty).Replace(" ", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty) != funciones2.ToUpper().Replace(@"\r\n?|\n", string.Empty).Replace(" ", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty))
                        {
                            func_diferentes.Add(item);
                        }
                    }
                }
                this.Cursor = Cursors.Default;
                GridView_funciones_diferentes.DataSource = null;
                GridView_funciones_diferentes.DataSource = func_diferentes;

                GridView_funciones_diferentes.AutoResizeColumns();

                lbl_funciones_diferentes.Text = func_diferentes.Count.ToString();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }

        }


        private void DeterminarVistasFaltantes()
        {

            BaseDeDatos base_1 = new BaseDeDatos(cbo_base1.Text);
            BaseDeDatos base_2 = new BaseDeDatos(cbo_base2.Text);

            List<Vista> vista1 = new List<Vista>();
            List<Vista> vista2 = new List<Vista>();

            if (UsarAutenticacionDeWindowsServer1())
            {
               vista1 = base_1.Vistas(Servidor(), base_1.Nombre);             
            }
            else
            {
                vista1 = base_1.Vistas(Servidor(), base_1.Nombre, Usuario(), Password());
            }
            
            if (UsarAutenticacionDeWindowsServer2())
            {              
                vista2 = base_2.Vistas(Servidor2(), base_2.Nombre);
            }
            else
            {               
                vista2 = base_2.Vistas(Servidor2(), base_2.Nombre, Usuario2(), Password2());
            }

            var result = vista2.Except(vista1).Union(vista1.Except(vista2)).ToList();

            var result2 = vista2.Except(vista1).ToList();
            var result3 = vista1.Except(vista2).ToList();
            
            IEnumerable<Vista> except = vista2.Except(vista1, new Vista());
            IEnumerable<Vista> except2 = vista1.Except(vista2, new Vista());

            GridView_vistas_faltantes1.DataSource = except.ToList();
            GridView_vistas_faltantes2.DataSource = except2.ToList();

            GridView_vistas_faltantes1.AutoResizeColumns();

            GridView_vistas_faltantes2.AutoResizeColumns();

            lbl_vistas_faltantes1.Text = except.Count().ToString();
            lbl_vistas_faltantes2.Text = except2.Count().ToString();


        }

       
        private void DeterminarVistasDiferentes()
        {
            try
            {


                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());

                List<Vista> vist1 = new List<Vista>();
                List<Vista> vist2 = new List<Vista>();

                List<Vista> vist_diferentes = new List<Vista>();


                if (UsarAutenticacionDeWindowsServer1())
                {
                    vist1 = base_1.Vistas(Servidor(), base_1.Nombre);
                }
                else
                {
                    vist1 = base_1.Vistas(Servidor(), base_1.Nombre, Usuario(), Password());
                }

                if (UsarAutenticacionDeWindowsServer2())
                {
                    vist2 = base_2.Vistas(Servidor2(), base_2.Nombre);
                }
                else
                {
                    vist2 = base_2.Vistas(Servidor2(), base_2.Nombre, Usuario2(), Password2());
                }


                var result = vist2.Except(vist1).Union(vist1.Except(vist2)).ToList();

                var result2 = vist2.Except(vist1).ToList();
                var result3 = vist1.Except(vist2).ToList();


                IEnumerable<Vista> except = vist2.Except(vist1, new Vista());
                IEnumerable<Vista> except2 = vist1.Except(vist2, new Vista());

                //var a = 0;

                dataGridView3.DataSource = except.ToList();
                dataGridView4.DataSource = except2.ToList();

                //   lbl_proc_faltantes_de_base_1.Text = except.Count().ToString();
                // lbl_proc_faltantes_de_base_2.Text = except2.Count().ToString();


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
                foreach (var item in vist1)
                {

                    if (!vistas_faltantes.Exists(p => p.Nombre == item.Nombre))
                    {

                        if (UsarAutenticacionDeWindowsServer1())
                        {
                            vistas1 = base_1.ObtenerTextoDeVista(item.Nombre, Servidor());
                        }
                        else
                        {
                            vistas1 = base_1.ObtenerTextoDeVista(item.Nombre, Servidor(), Usuario(), Password());
                        }

                        if (UsarAutenticacionDeWindowsServer2())
                        {
                            vistas2 = base_2.ObtenerTextoDeVista(item.Nombre, Servidor2());
                        }
                        else
                        {
                            vistas2 = base_2.ObtenerTextoDeVista(item.Nombre, Servidor2(), Usuario2(), Password2());
                        }

                        if (vistas1.ToUpper().Replace(@"\r\n?|\n", string.Empty).Replace(" ", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty) != vistas2.ToUpper().Replace(@"\r\n?|\n", string.Empty).Replace(" ", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty))
                        {
                            vist_diferentes.Add(item);
                        }
                    }



                }
                this.Cursor = Cursors.Default;
                GridView_vistas_diferentes.DataSource = null;
                GridView_vistas_diferentes.DataSource = vist_diferentes;

                GridView_vistas_diferentes.AutoResizeColumns();

                lbl_vistas_diferentes.Text = vist_diferentes.Count.ToString();

               // MessageBox.Show(MensajeOperacionCorrecta(), MensajeValidacionOperacion(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                // return;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, MensajeValidacionOperacion(),MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                //this.Cursor = Cursors.Default;
                //throw;
            }

        }

        
        private void DeterminarTriggersFaltantes()
        {

            BaseDeDatos base_1 = new BaseDeDatos(cbo_base1.Text);
            BaseDeDatos base_2 = new BaseDeDatos(cbo_base2.Text);

            List<Trigger> trigger1 = new List<Trigger>();
            List<Trigger> trigger2 = new List<Trigger>();

            if (UsarAutenticacionDeWindowsServer1())
            {
                trigger1 = base_1.Triggers(Servidor(), base_1.Nombre);              
            }
            else
            {
                trigger1 = base_1.Triggers(Servidor(), base_1.Nombre, Usuario(), Password());               
            }

            if (UsarAutenticacionDeWindowsServer2()) 
            {
                trigger2 = base_2.Triggers(Servidor2(), base_2.Nombre);
            }
            else
            {
                trigger2 = base_2.Triggers(Servidor2(), base_2.Nombre, Usuario2(), Password2());
            }

            var result = trigger2.Except(trigger1).Union(trigger1.Except(trigger2)).ToList();

            var result2 = trigger2.Except(trigger1).ToList();
            var result3 = trigger1.Except(trigger2).ToList();


            IEnumerable<Trigger> except = trigger2.Except(trigger1, new Trigger());
            IEnumerable<Trigger> except2 = trigger1.Except(trigger2, new Trigger());


            GridView_triggers_faltantes1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
            GridView_triggers_faltantes2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);

            GridView_triggers_faltantes1.DataSource = except.ToList();
            GridView_triggers_faltantes2.DataSource = except2.ToList();

          


            lbl_triggers_faltantes1.Text = except.Count().ToString();
            lbl_triggers_faltantes2.Text = except2.Count().ToString();


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


                if (UsarAutenticacionDeWindowsServer1())
                {
                    trigger1 = base_1.Triggers(Servidor(), base_1.Nombre);
                }
                else
                {
                    trigger1 = base_1.Triggers(Servidor(), base_1.Nombre, Usuario(), Password());
                }

                if (UsarAutenticacionDeWindowsServer2())
                {
                    trigger2 = base_2.Triggers(Servidor2(), base_2.Nombre);
                }
                else
                {
                    trigger2 = base_2.Triggers(Servidor2(), base_2.Nombre, Usuario2(), Password2());
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
                         
                        }
                        else
                        {
                            triggers1 = base_1.ObtenerTextoDeTrigger(item.Nombre, Servidor(), Usuario(), Password());
                        }


                        if (UsarAutenticacionDeWindowsServer2())
                        {

                            triggers2 = base_2.ObtenerTextoDeTrigger(item.Nombre, Servidor2());
                        }
                        else
                        {
                         
                            triggers2 = base_2.ObtenerTextoDeTrigger(item.Nombre, Servidor2(), Usuario(), Password());
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

                GridView_triggers_diferentes.AutoResizeColumns();

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
                tabla2 = base_2.Tablas(Servidor2(), base_2.Nombre);
            }
            else
            {
                tabla1 = base_1.Tablas(Servidor(), base_1.Nombre, Usuario(), Password());
                tabla2 = base_2.Tablas(Servidor2(), base_2.Nombre, Usuario(), Password());
            }


            var result = tabla2.Except(tabla1).Union(tabla1.Except(tabla2)).ToList();

            var result2 = tabla2.Except(tabla1).ToList();
            var result3 = tabla1.Except(tabla2).ToList();


            IEnumerable<Tabla> except = tabla2.Except(tabla1, new Tabla());
            IEnumerable<Tabla> except2 = tabla1.Except(tabla2, new Tabla());

           

            gridview_tablas_faltantes1.DataSource = except.ToList();
            gridview_tablas_faltantes2.DataSource = except2.ToList();

            gridview_tablas_faltantes1.AutoResizeColumns();
            gridview_tablas_faltantes2.AutoResizeColumns();

            lbl_tablas_faltantes1.Text = except.Count().ToString();
            lbl_tablas_faltantes2.Text = except2.Count().ToString();

            this.Cursor = Cursors.Default;
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

           ///////

                if (UsarAutenticacionDeWindowsServer1())
                {
                    tabl1 = base_1.Tablas(Servidor(), base_1.Nombre);

                }
                else
                {
                    tabl1 = base_1.Tablas(Servidor(), base_1.Nombre, Usuario(), Password());
                }


                if (UsarAutenticacionDeWindowsServer2())
                {
                    tabl2 = base_2.Tablas(Servidor2(), base_2.Nombre);
                }
                else
                {
                    tabl2 = base_2.Tablas(Servidor2(), base_2.Nombre, Usuario2(), Password2());
                }

                

                ///////////

                //if (UsarAutenticacionDeWindows())
                //{
                //    tabl1 = base_1.Tablas(Servidor(), base_1.Nombre);
                //    tabl2 = base_2.Tablas(Servidor2(), base_2.Nombre);
                //}
                //else
                //{
                //    tabl1 = base_1.Tablas(Servidor(), base_1.Nombre, Usuario(), Password());
                //    tabl2 = base_2.Tablas(Servidor2(), base_2.Nombre, Usuario(), Password());
                //}


                var result = tabl2.Except(tabl1).Union(tabl1.Except(tabl2)).ToList();

                var result2 = tabl2.Except(tabl1).ToList();
                var result3 = tabl1.Except(tabl2).ToList();


                IEnumerable<Tabla> except = tabl2.Except(tabl1, new Tabla());
                IEnumerable<Tabla> except2 = tabl1.Except(tabl2, new Tabla());
                          

                dataGridView3.DataSource = except.ToList();
                dataGridView4.DataSource = except2.ToList();

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

                        if (UsarAutenticacionDeWindowsServer1())
                        {
                            tablas1 = base_1.ObtenerTextoDeTabla(item.Nombre, Servidor());
                          //  tablas2 = base_2.ObtenerTextoDeTabla(item.Nombre, Servidor2());
                        }
                          else
	                    {
                             tablas1 = base_1.ObtenerTextoDeTabla(item.Nombre, Servidor(), Usuario(), Password());
	                    }


                        if (UsarAutenticacionDeWindowsServer2())
                        {
                            tablas2 = base_2.ObtenerTextoDeTabla(item.Nombre, Servidor2());
                           // tablas1 = base_1.ObtenerTextoDeTabla(item.Nombre, Servidor(), Usuario(), Password());
                            //tablas2 = base_2.ObtenerTextoDeTabla(item.Nombre, Servidor2(), Usuario2(), Password2());
                        }
                        else
                        {
                            tablas2 = base_2.ObtenerTextoDeTabla(item.Nombre, Servidor2(), Usuario2(), Password2());
                        }

                        if (tablas1.ToUpper().Replace(@"\r\n?|\n", string.Empty).Replace(" ", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty) != tablas2.ToUpper().Replace(@"\r\n?|\n", string.Empty).Replace(" ", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty))
                        {
                            tabl_diferentes.Add(item);
                        }
                    }
                                                   

                }
                this.Cursor = Cursors.Default;
                gridview_tablas_diferentes.DataSource = null;
                gridview_tablas_diferentes.DataSource = tabl_diferentes;

                gridview_tablas_diferentes.AutoResizeColumns();

                lbl_tablas_diferentes.Text = tabl_diferentes.Count.ToString();

         
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
              
            }
            
        }


        private void DeterminarProcedimientosFaltantes()
        {
            BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
            BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());

            List<StoredProcedure> proc1 = new List<StoredProcedure>();
            List<StoredProcedure> proc2 = new List<StoredProcedure>();

            if (UsarAutenticacionDeWindowsServer1())
            {
                proc1 = base_1.Procedimientos(Servidor(), base_1.Nombre);
         
            }
            else
            {
                proc1 = base_1.Procedimientos(Servidor(), base_1.Nombre, Usuario(), Password());
         
            }


            if (UsarAutenticacionDeWindowsServer2())
            {
               proc2 = base_2.Procedimientos(Servidor2(), base_2.Nombre);
            }
            else
            {            
                proc2 = base_2.Procedimientos(Servidor2(), base_2.Nombre, Usuario2(), Password2());
            }



            var result = proc2.Except(proc1).Union(proc1.Except(proc2)).ToList();
            var result2 = proc2.Except(proc1).ToList();
            var result3 = proc1.Except(proc2).ToList();


            IEnumerable<StoredProcedure> except = proc2.Except(proc1, new StoredProcedure());
            IEnumerable<StoredProcedure> except2 = proc1.Except(proc2, new StoredProcedure());

            proc_faltantes_grilla1 = except;
            proc_faltantes_grilla2 = except2;

            gridview_proc_faltantes1.DataSource = except.ToList();
            gridview_proc_faltantes2.DataSource = except2.ToList();
            
            gridview_proc_faltantes1.AutoResizeColumns();
            gridview_proc_faltantes2.AutoResizeColumns();

            lbl_proc_faltantes_de_base_1.Text = except.Count().ToString();
            lbl_proc_faltantes_de_base_2.Text = except2.Count().ToString();

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

                if (UsarAutenticacionDeWindowsServer1())
                {
                    proc1 = base_1.Procedimientos(Servidor(), base_1.Nombre);
                }
                else
                {
                    proc1 = base_1.Procedimientos(Servidor(), base_1.Nombre, Usuario(), Password());
                }

                if (UsarAutenticacionDeWindowsServer2())
                {
                   proc2 = base_2.Procedimientos(Servidor2(), base_2.Nombre);
                }
                else
                {
                  proc2 = base_2.Procedimientos(Servidor2(), base_2.Nombre, Usuario2(), Password2());
                }
                
                var result = proc2.Except(proc1).Union(proc1.Except(proc2)).ToList();
                var result2 = proc2.Except(proc1).ToList();
                var result3 = proc1.Except(proc2).ToList();
                
                IEnumerable<StoredProcedure> except = proc2.Except(proc1, new StoredProcedure());
                IEnumerable<StoredProcedure> except2 = proc1.Except(proc2, new StoredProcedure());

              

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

                    if (!proc_faltantes.Exists(p => p.Nombre == item.Nombre))
                    {
                        if (UsarAutenticacionDeWindowsServer1())
                        {
                            proced1 = base_1.ObtenerTextoDeProcedimiento(item.Nombre, Servidor());
                           }
                        else
                        {
                            proced1 = base_1.ObtenerTextoDeProcedimiento(item.Nombre, Servidor(), Usuario(), Password());
                            }


                        if (UsarAutenticacionDeWindowsServer2())
                        {
                                  proced2 = base_2.ObtenerTextoDeProcedimiento(item.Nombre, Servidor2());
                        }
                        else
                        {
                                proced2 = base_2.ObtenerTextoDeProcedimiento(item.Nombre, Servidor2(), Usuario2(), Password2());
                        }

                        //if (proced1.ToUpper().Replace(@"\r\n?|\n", string.Empty).Replace(" ", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty).Replace(" ", "").Replace("   ", "").Replace("[", "").Replace("]", "").Replace(Environment.NewLine, "").Replace("-", "") != proced2.ToUpper().Replace(@"\r\n?|\n", string.Empty).Replace(" ", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty).Replace(" ", "").Replace("   ", "").Replace("[", "").Replace("]", "").Replace(Environment.NewLine, "").Replace("-", ""))
                        //{
                        if (DesestimarCaracteresDespreciables(proced1) != DesestimarCaracteresDespreciables(proced2))
                        {
                            procdiferentes.Add(item);
                        }
                    }

                }
                GridView_proc_diferentes.DataSource = null;
                GridView_proc_diferentes.DataSource = procdiferentes;

                GridView_proc_diferentes.AutoResizeColumns();

                lbl_proc_diferentes.Text = procdiferentes.Count.ToString();
                this.Cursor = Cursors.Default;
                return;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
               
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

                List<StoredProcedure> proc1 = new List<StoredProcedure>();
                List<StoredProcedure> proc2 = new List<StoredProcedure>();

                List<StoredProcedure> procdiferentes = new List<StoredProcedure>();

                string proced1 = "";
                string proced2 = "";
               
                        if (UsarAutenticacionDeWindowsServer1())
                        {
                            proced1 = base_1.ObtenerTextoDeProcedimiento(nombre_procedimiento, Servidor());
                            }
                        else
                        {    proced1 = base_1.ObtenerTextoDeProcedimiento(nombre_procedimiento, Servidor(), Usuario(), Password());
                              }


                        if (UsarAutenticacionDeWindowsServer2())
                        {
                            proced2 = base_2.ObtenerTextoDeProcedimiento(nombre_procedimiento, Servidor2());
                        }
                        else
                        {
                         
                            proced2 = base_2.ObtenerTextoDeProcedimiento(nombre_procedimiento, Servidor2(), Usuario2(), Password2());
                        }


                       
                        AbrirFormularioDeComparacion(proced1, proced2);     
                      
                        return;

                }
               
            
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
           
            }


        }


        private void AbrirFormularioDeScript(string script_generado)
        {

            FrmScriptGenerado form = new FrmScriptGenerado();

            form.MostrarElementos(script_generado);
            form.ShowDialog();
           


        }


        private void GenerarScriptProcedimientosFaltantesServidor1(List<StoredProcedure> lista_de_procedimientos)
        {
            try
            {
               
                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());
                List<StoredProcedure> procdiferentes = new List<StoredProcedure>();

                string script_generado = "";
              
                foreach (StoredProcedure procedimiento in lista_de_procedimientos)
                {   
                        if (UsarAutenticacionDeWindowsServer2())
                        {
                            script_generado = script_generado +"GO" + "\r\n" + "\r\n"  +base_2.ObtenerTextoDeProcedimiento(procedimiento.Nombre, Servidor2()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                        }
                        else                
                        {
                            script_generado = script_generado +  "GO" + "\r\n" + "\r\n"+ base_2.ObtenerTextoDeProcedimiento(procedimiento.Nombre, Servidor2(), Usuario2(), Password2()) + "\r\n" + "\r\n" + "GO" + "\r\n";
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






        private void GenerarScriptProcedimientosFaltantesServidor2(List<StoredProcedure> lista_de_procedimientos)
        {
            try
            {

                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                List<StoredProcedure> procdiferentes = new List<StoredProcedure>();

                string script_generado = "";

                foreach (StoredProcedure procedimiento in lista_de_procedimientos)
                {
                    if (UsarAutenticacionDeWindowsServer2())
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







        private void DeterminarTriggersDiferentes(string nombre_trigger)
        {
            try
            {
                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());

                string trigg1 = "";
                string trigg2 = "";

                if (UsarAutenticacionDeWindowsServer1())
                {
                    trigg1 = base_1.ObtenerTextoDeTrigger(nombre_trigger, Servidor());
                }
                else
                {
                    trigg1 = base_1.ObtenerTextoDeTrigger(nombre_trigger, Servidor(), Usuario(), Password());
                }


                if (UsarAutenticacionDeWindowsServer2())
                {
                    trigg2 = base_2.ObtenerTextoDeTrigger(nombre_trigger, Servidor2());
                }
                else
                {

                    trigg2 = base_2.ObtenerTextoDeTrigger(nombre_trigger, Servidor2(), Usuario2(), Password2());
                }
                
                AbrirFormularioDeComparacion(trigg1, trigg2);
                return;

            }


            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
              
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

                if (UsarAutenticacionDeWindowsServer1())
                {
                    tabl1 = base_1.ObtenerTextoDeTablaManeraLenta(nombre_tabla, Servidor());
                }
                else
                {
                    tabl1 = base_1.ObtenerTextoDeTabla(nombre_tabla, Servidor(), Usuario(), Password());
                }


                if (UsarAutenticacionDeWindowsServer2())
                {
                    tabl2 = base_2.ObtenerTextoDeTablaManeraLenta(nombre_tabla, Servidor2());
                }
                else
                {

                    tabl2 = base_2.ObtenerTextoDeTabla(nombre_tabla, Servidor2(), Usuario2(), Password2());
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




        private void DeterminarTablasDiferentes(string nombre_tabla)
        {
            try
            {
                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());

                string tabl1 = "";
                string tabl2 = "";

                if (UsarAutenticacionDeWindowsServer1())
                {
                    tabl1 = base_1.ObtenerTextoDeTabla(nombre_tabla, Servidor());
                }
                else
                {
                    tabl1 = base_1.ObtenerTextoDeTabla(nombre_tabla, Servidor(), Usuario(), Password());
                }


                if (UsarAutenticacionDeWindowsServer2())
                {
                    tabl2 = base_2.ObtenerTextoDeTabla(nombre_tabla, Servidor2());
                }
                else
                {

                    tabl2 = base_2.ObtenerTextoDeTabla(nombre_tabla, Servidor2(), Usuario2(), Password2());
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




        private void DeterminarVistasDiferentes(string nombre_vista)
        {
            try
            {
                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());

                string vist1 = "";
                string vist2 = "";

                if (UsarAutenticacionDeWindowsServer1())
                {
                    vist1 = base_1.ObtenerTextoDeVista(nombre_vista, Servidor());
                }
                else
                {
                    vist1 = base_1.ObtenerTextoDeVista(nombre_vista, Servidor(), Usuario(), Password());
                }


                if (UsarAutenticacionDeWindowsServer2())
                {
                    vist2 = base_2.ObtenerTextoDeVista(nombre_vista, Servidor2());
                }
                else
                {

                    vist2 = base_2.ObtenerTextoDeVista(nombre_vista, Servidor2(), Usuario2(), Password2());
                }

                AbrirFormularioDeComparacion(vist1, vist2);
                return;

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

                string func1 = "";
                string func2 = "";

                if (UsarAutenticacionDeWindowsServer1())
                {
                    func1 = base_1.ObtenerTextoDeFuncion(nombre_funcion, Servidor());
                }
                else
                {
                    func1 = base_1.ObtenerTextoDeFuncion(nombre_funcion, Servidor(), Usuario(), Password());
                }


                if (UsarAutenticacionDeWindowsServer2())
                {
                    func2 = base_2.ObtenerTextoDeFuncion(nombre_funcion, Servidor2());
                }
                else
                {

                    func2 = base_2.ObtenerTextoDeFuncion(nombre_funcion, Servidor2(), Usuario2(), Password2());
                }

                AbrirFormularioDeComparacion(func1, func2);
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
                DeterminarTablasDiferentesManeraVieja(gridview_tablas_diferentes.CurrentCell.Value.ToString());
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

        private void FrmComparacionServidores_Load(object sender, EventArgs e)
        {

        }

        private void btn_script_proc_faltantes_1_Click(object sender, EventArgs e)
        {

            if (gridview_proc_faltantes1.Rows.Count==0)
            {
                return;
            }
            
            List<StoredProcedure> lista_de_procedimientos = new List<StoredProcedure>();

                foreach (DataGridViewRow Fila in gridview_proc_faltantes1.Rows)
                {      

                StoredProcedure procedimiento_en_fila = new StoredProcedure(Fila.Cells[0].Value.ToString());
                lista_de_procedimientos.Add(procedimiento_en_fila);
                
                }

                GenerarScriptProcedimientosFaltantesServidor1(lista_de_procedimientos);


        }

        private void btn_script_proc_faltantes_2_Click(object sender, EventArgs e)
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

            GenerarScriptProcedimientosFaltantesServidor2(lista_de_procedimientos);




        }

        private void btn_script_trig_faltantes_1_Click(object sender, EventArgs e)
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

            GenerarScriptTriggersFaltantesServidor1(lista_de_triggers);




        }


        private void GenerarScriptTriggersFaltantesServidor1(List<Trigger> lista_de_triggers)
        {
            try
            {

                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());
              

                string script_generado ="";

                foreach (Trigger trigger in lista_de_triggers)
                {
                    if (UsarAutenticacionDeWindowsServer2())
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeTrigger(trigger.Nombre, Servidor2()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                    else
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeTrigger(trigger.Nombre, Servidor2(), Usuario2(), Password2()) + "\r\n" + "\r\n" + "GO" + "\r\n";
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


        private void GenerarScriptTriggersFaltantesServidor2(List<Trigger> lista_de_triggers)
        {
            try
            {

                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                //List<Trigger> trigdiferentes = new List<Trigger>();

                string script_generado = "";

                foreach (Trigger trigger in lista_de_triggers)
                {
                    if (UsarAutenticacionDeWindowsServer1())
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



        private void GenerarScriptVistasFaltantesServidor2(List<Vista> lista_de_vistas)
        {
            try
            {

                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                //List<Trigger> trigdiferentes = new List<Trigger>();

                string script_generado = "";

                foreach (Vista vista in lista_de_vistas)
                {
                    if (UsarAutenticacionDeWindowsServer1())
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


        private void GenerarScriptVistasFaltantesServidor1(List<Vista> lista_de_vistas)
        {
            try
            {

                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());
                //List<Trigger> trigdiferentes = new List<Trigger>();

                string script_generado = "";

                foreach (Vista vista in lista_de_vistas)
                {
                    if (UsarAutenticacionDeWindowsServer2())
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeVista(vista.Nombre, Servidor2()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                    else
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeVista(vista.Nombre, Servidor2(), Usuario2(), Password2()) + "\r\n" + "\r\n" + "GO" + "\r\n";
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

            GenerarScriptTriggersFaltantesServidor2(lista_de_triggers);




        }

        private void btn_script_tablas_faltantes_1_Click(object sender, EventArgs e)
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

            GenerarScriptTablasFaltantesServidor1(lista_de_tablas);
            



        }

        private void btn_script_vistas_faltantes_1_Click(object sender, EventArgs e)
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

            GenerarScriptVistasFaltantesServidor1(lista_de_vistas);

            

        }

        private void btn_script_vistas_faltantes_2_Click(object sender, EventArgs e)
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

            GenerarScriptVistasFaltantesServidor2(lista_de_vistas);

            
            

        }

        private void btn_script_func_faltantes_1_Click(object sender, EventArgs e)
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

            GenerarScriptFuncionesFaltantesServidor1(lista_de_funciones);
            


        }

        private void btn_script_func_faltantes_2_Click(object sender, EventArgs e)
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

            GenerarScriptFuncionesFaltantesServidor2(lista_de_funciones);
            

            


        }
        

        private void GenerarScriptFuncionesFaltantesServidor1(List<Funcion> lista_de_funciones)
        {
            try
            {

                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());
                //List<Trigger> trigdiferentes = new List<Trigger>();

                string script_generado = "";

                foreach (Funcion vista in lista_de_funciones)
                {
                    if (UsarAutenticacionDeWindowsServer2())
                    {
                        script_generado = script_generado +"GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeFuncion(vista.Nombre, Servidor2()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                    else
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeFuncion(vista.Nombre, Servidor2(), Usuario2(), Password2()) + "\r\n" + "\r\n" + "GO" + "\r\n";
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


        private void GenerarScriptFuncionesFaltantesServidor2(List<Funcion> lista_de_funciones)
        {
            try
            {

                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                //List<Trigger> trigdiferentes = new List<Trigger>();

                string script_generado = "";

                foreach (Funcion vista in lista_de_funciones)
                {
                    if (UsarAutenticacionDeWindowsServer1())
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




        private void GenerarScriptTablasFaltantesServidor2(List<Tabla> lista_de_tablas)
        {
            try
            {

                BaseDeDatos base_1 = new BaseDeDatos(NombreBase1());
                //List<Trigger> trigdiferentes = new List<Trigger>();

                string script_generado = "";

                foreach (Tabla tabla in lista_de_tablas)
                {
                    if (UsarAutenticacionDeWindowsServer1())
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



        private void GenerarScriptTablasFaltantesServidor1(List<Tabla> lista_de_tablas)
        {
            try
            {

                BaseDeDatos base_2 = new BaseDeDatos(NombreBase2());
                //List<Trigger> trigdiferentes = new List<Trigger>();

                string script_generado = "";

                foreach (Tabla tabla in lista_de_tablas)
                {
                    if (UsarAutenticacionDeWindowsServer1())
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeTablaManeraLenta(tabla.Nombre, Servidor2()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                    }
                    else
                    {
                        script_generado = script_generado + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeTablaManeraLenta(tabla.Nombre, Servidor2(), Usuario2(), Password2()) + "\r\n" + "\r\n" + "GO" + "\r\n";
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

        private void btn_script_tablas_faltantes_2_Click(object sender, EventArgs e)
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

            GenerarScriptTablasFaltantesServidor2(lista_de_tablas);
        }

        private void gridview_proc_faltantes1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridview_proc_faltantes1.Rows.Count==0)
            {
                return;
            }

            int li_index = 0;
            if (e.KeyCode == Keys.Delete) {
            e.Handled = true;
            li_index = ((DataGridView)sender).CurrentRow.Index;

            List<StoredProcedure> lista_proc = new List<StoredProcedure>();

            foreach (DataGridViewRow ROW in gridview_proc_faltantes1.Rows)
            {
                StoredProcedure stored = new StoredProcedure(ROW.Cells[0].Value.ToString());
                lista_proc.Add(stored);               
            }
                lista_proc.RemoveAll(p=>p.Nombre == gridview_proc_faltantes1.Rows[li_index].Cells[0].Value.ToString());

                gridview_proc_faltantes1.DataSource = null;
                gridview_proc_faltantes1.DataSource = lista_proc;
                gridview_proc_faltantes1.AutoResizeColumns();
                lbl_proc_faltantes_de_base_1.Text = gridview_proc_faltantes1.Rows.Count.ToString();
            }
        }


       private string DesestimarCaracteresDespreciables(string original)
       {
           return original.Replace(" ", "").Replace("   ", "").Replace("[", "").Replace("]", "").Replace(Environment.NewLine, "").Replace("-", "");

           //if (proced1.ToUpper().Replace(@"\r\n?|\n", string.Empty).Replace(" ", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty).Replace(" ", "").Replace("   ", "").Replace("[", "").Replace("]", "").Replace(Environment.NewLine, "").Replace("-", "") != proced2.ToUpper().Replace(@"\r\n?|\n", string.Empty).Replace(" ", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty).Replace(" ", "").Replace("   ", "").Replace("[", "").Replace("]", "").Replace(Environment.NewLine, "").Replace("-", ""))
                    
       
       }



        private void gridview_proc_faltantes2_KeyDown(object sender, KeyEventArgs e)
        {
          
                if (gridview_proc_faltantes2.Rows.Count == 0)
                {
                    return;
                }

                int li_index = 0;
                if (e.KeyCode == Keys.Delete)
                {
                    e.Handled = true;
                    li_index = ((DataGridView)sender).CurrentRow.Index;

                    List<StoredProcedure> lista_proc = new List<StoredProcedure>();

                    foreach (DataGridViewRow ROW in gridview_proc_faltantes2.Rows)
                    {
                        StoredProcedure stored = new StoredProcedure(ROW.Cells[0].Value.ToString());
                        lista_proc.Add(stored);
                    }
                    lista_proc.RemoveAll(p => p.Nombre == gridview_proc_faltantes2.Rows[li_index].Cells[0].Value.ToString());

                    gridview_proc_faltantes2.DataSource = null;
                    gridview_proc_faltantes2.DataSource = lista_proc;
                    gridview_proc_faltantes2.AutoResizeColumns();
                    lbl_proc_faltantes_de_base_2.Text = gridview_proc_faltantes2.Rows.Count.ToString();
                }
            
         }

        private void GridView_triggers_faltantes1_KeyDown(object sender, KeyEventArgs e)
        {
            if (GridView_triggers_faltantes1.Rows.Count == 0)
            {
                return;
            }
            int li_index = 0;
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                li_index = ((DataGridView)sender).CurrentRow.Index;

                List<Trigger> lista_proc = new List<Trigger>();

                foreach (DataGridViewRow ROW in GridView_triggers_faltantes1.Rows)
                {
                    Trigger stored = new Trigger(ROW.Cells[0].Value.ToString());
                    lista_proc.Add(stored);
                }
                lista_proc.RemoveAll(p => p.Nombre == GridView_triggers_faltantes1.Rows[li_index].Cells[0].Value.ToString());

                GridView_triggers_faltantes1.DataSource = null;
                GridView_triggers_faltantes1.DataSource = lista_proc;
                GridView_triggers_faltantes1.AutoResizeColumns();
                lbl_triggers_faltantes1.Text = GridView_triggers_faltantes1.Rows.Count.ToString();
            }
            
        }

        private void GridView_triggers_faltantes2_KeyDown(object sender, KeyEventArgs e)
        {

            if (GridView_triggers_faltantes2.Rows.Count == 0)
            {
                return;
            }
            int li_index = 0;
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                li_index = ((DataGridView)sender).CurrentRow.Index;

                List<Trigger> lista_triggers = new List<Trigger>();

                foreach (DataGridViewRow ROW in GridView_triggers_faltantes2.Rows)
                {
                    Trigger stored = new Trigger(ROW.Cells[0].Value.ToString());
                    lista_triggers.Add(stored);
                }
                lista_triggers.RemoveAll(p => p.Nombre == GridView_triggers_faltantes2.Rows[li_index].Cells[0].Value.ToString());

                GridView_triggers_faltantes2.DataSource = null;
                GridView_triggers_faltantes2.DataSource = lista_triggers;
                GridView_triggers_faltantes2.AutoResizeColumns();
                lbl_triggers_faltantes2.Text = GridView_triggers_faltantes2.Rows.Count.ToString();
            }


        }

        private void gridview_tablas_faltantes1_KeyDown(object sender, KeyEventArgs e)
        {

            if (gridview_tablas_faltantes1.Rows.Count == 0)
            {
                return;
            }
            int li_index = 0;
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                li_index = ((DataGridView)sender).CurrentRow.Index;

                List<Tabla> lista_tablas = new List<Tabla>();

                foreach (DataGridViewRow ROW in gridview_tablas_faltantes1.Rows)
                {
                    Tabla tabla = new Tabla(ROW.Cells[0].Value.ToString());
                    lista_tablas.Add(tabla);
                }
                lista_tablas.RemoveAll(p => p.Nombre == gridview_tablas_faltantes1.Rows[li_index].Cells[0].Value.ToString());

                gridview_tablas_faltantes1.DataSource = null;
                gridview_tablas_faltantes1.DataSource = lista_tablas;
                gridview_tablas_faltantes1.AutoResizeColumns();
                lbl_tablas_faltantes1.Text = gridview_tablas_faltantes1.Rows.Count.ToString();
            }

            


        }

        private void gridview_tablas_faltantes2_KeyDown(object sender, KeyEventArgs e)
        {

            if (gridview_tablas_faltantes2.Rows.Count == 0)
            {
                return;
            }
            int li_index = 0;
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                li_index = ((DataGridView)sender).CurrentRow.Index;

                List<Tabla> lista_tablas = new List<Tabla>();

                foreach (DataGridViewRow ROW in gridview_tablas_faltantes2.Rows)
                {
                    Tabla tabla = new Tabla(ROW.Cells[0].Value.ToString());
                    lista_tablas.Add(tabla);
                }
                lista_tablas.RemoveAll(p => p.Nombre == gridview_tablas_faltantes2.Rows[li_index].Cells[0].Value.ToString());

                gridview_tablas_faltantes2.DataSource = null;
                gridview_tablas_faltantes2.DataSource = lista_tablas;
                gridview_tablas_faltantes2.AutoResizeColumns();
                lbl_tablas_faltantes2.Text = gridview_tablas_faltantes2.Rows.Count.ToString();
            }


        }

        private void GridView_vistas_faltantes1_KeyDown(object sender, KeyEventArgs e)
        {
            if (GridView_vistas_faltantes1.Rows.Count == 0)
            {
                return;
            }
            int li_index = 0;
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                li_index = ((DataGridView)sender).CurrentRow.Index;

                List<Vista> lista_vistas = new List<Vista>();

                foreach (DataGridViewRow ROW in GridView_vistas_faltantes1.Rows)
                {
                    Vista vista = new Vista(ROW.Cells[0].Value.ToString());
                    lista_vistas.Add(vista);
                }
                lista_vistas.RemoveAll(p => p.Nombre == GridView_vistas_faltantes1.Rows[li_index].Cells[0].Value.ToString());

                GridView_vistas_faltantes1.DataSource = null;
                GridView_vistas_faltantes1.DataSource = lista_vistas;
                GridView_vistas_faltantes1.AutoResizeColumns();
                lbl_vistas_faltantes1.Text = GridView_vistas_faltantes1.Rows.Count.ToString();
            }

        }

        private void GridView_vistas_faltantes2_KeyDown(object sender, KeyEventArgs e)
        {
            if (GridView_vistas_faltantes2.Rows.Count == 0)
            {
                return;
            }
            int li_index = 0;
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                li_index = ((DataGridView)sender).CurrentRow.Index;

                List<Vista> lista_vistas = new List<Vista>();

                foreach (DataGridViewRow ROW in GridView_vistas_faltantes2.Rows)
                {
                    Vista vista = new Vista(ROW.Cells[0].Value.ToString());
                    lista_vistas.Add(vista);
                }
                lista_vistas.RemoveAll(p => p.Nombre == GridView_vistas_faltantes2.Rows[li_index].Cells[0].Value.ToString());

                GridView_vistas_faltantes2.DataSource = null;
                GridView_vistas_faltantes2.DataSource = lista_vistas;
                GridView_vistas_faltantes2.AutoResizeColumns();
                lbl_vistas_faltantes2.Text = GridView_vistas_faltantes2.Rows.Count.ToString();
            }
        }

        private void GridView_funciones_faltantes1_KeyDown(object sender, KeyEventArgs e)
        {

            if (GridView_funciones_faltantes1.Rows.Count == 0)
            {
                return;
            }
            int li_index = 0;
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                li_index = ((DataGridView)sender).CurrentRow.Index;

                List<Funcion> lista_funciones = new List<Funcion>();

                foreach (DataGridViewRow ROW in GridView_funciones_faltantes1.Rows)
                {
                    Funcion funcion = new Funcion(ROW.Cells[0].Value.ToString());
                    lista_funciones.Add(funcion);
                }
                lista_funciones.RemoveAll(p => p.Nombre == GridView_funciones_faltantes1.Rows[li_index].Cells[0].Value.ToString());

                GridView_funciones_faltantes1.DataSource = null;
                GridView_funciones_faltantes1.DataSource = lista_funciones;
                GridView_funciones_faltantes1.AutoResizeColumns();
                lbl_funciones_faltantes1.Text = GridView_funciones_faltantes1.Rows.Count.ToString();
            }



        }

        private void GridView_funciones_faltantes2_KeyDown(object sender, KeyEventArgs e)
        {

            if (GridView_funciones_faltantes2.Rows.Count == 0)
            {
                return;
            }
            int li_index = 0;
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
                li_index = ((DataGridView)sender).CurrentRow.Index;

                List<Funcion> lista_funciones = new List<Funcion>();

                foreach (DataGridViewRow ROW in GridView_funciones_faltantes2.Rows)
                {
                    Funcion funcion = new Funcion(ROW.Cells[0].Value.ToString());
                    lista_funciones.Add(funcion);
                }
                lista_funciones.RemoveAll(p => p.Nombre == GridView_funciones_faltantes2.Rows[li_index].Cells[0].Value.ToString());

                GridView_funciones_faltantes2.DataSource = null;
                GridView_funciones_faltantes2.DataSource = lista_funciones;
                GridView_funciones_faltantes2.AutoResizeColumns();
                lbl_funciones_faltantes2.Text = GridView_funciones_faltantes2.Rows.Count.ToString();
            }



        }

        private void gridview_tablas_diferentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                        script_generado1 = script_generado1 + "GO" + "\r\n" + "\r\n" + base_1.ObtenerTextoDeProcedimiento(procedimiento.Nombre, Servidor()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                        script_generado2 = script_generado2 + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeProcedimiento(procedimiento.Nombre, Servidor2()) + "\r\n" + "\r\n" + "GO" + "\r\n";

                    }
                    else
                    {
                        script_generado1 = script_generado1 + "GO" + "\r\n" + "\r\n" + base_1.ObtenerTextoDeProcedimiento(procedimiento.Nombre, Servidor(), Usuario(), Password()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                        script_generado2 = script_generado2 + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeProcedimiento(procedimiento.Nombre, Servidor2(), Usuario2(), Password2()) + "\r\n" + "\r\n" + "GO" + "\r\n";
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


        private void btn_script_proc_diferentes_Click(object sender, EventArgs e)
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
                        script_generado1 = script_generado1 + "GO" + "\r\n" + "\r\n" + base_1.ObtenerTextoDeTrigger(trigger.Nombre, Servidor()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                        script_generado2 = script_generado2 + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeTrigger(trigger.Nombre, Servidor2()) + "\r\n" + "\r\n" + "GO" + "\r\n";

                    }
                    else
                    {
                        script_generado1 = script_generado1 + "GO" + "\r\n" + "\r\n" + base_1.ObtenerTextoDeTrigger(trigger.Nombre, Servidor(), Usuario(), Password()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                        script_generado2 = script_generado2 + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeTrigger(trigger.Nombre, Servidor2(), Usuario2(), Password2()) + "\r\n" + "\r\n" + "GO" + "\r\n";
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
                        script_generado2 = script_generado2 + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeTablaManeraLenta(tabla.Nombre, Servidor2()) + "\r\n" + "\r\n" + "GO" + "\r\n";

                    }
                    else
                    {
                        script_generado1 = script_generado1 + "GO" + "\r\n" + "\r\n" + base_1.ObtenerTextoDeTablaManeraLenta(tabla.Nombre, Servidor(), Usuario(), Password()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                        script_generado2 = script_generado2 + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeTablaManeraLenta(tabla.Nombre, Servidor2(), Usuario2(), Password2()) + "\r\n" + "\r\n" + "GO" + "\r\n";
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
                        script_generado1 = script_generado1 + "GO" + "\r\n" + "\r\n" + base_1.ObtenerTextoDeVista(vista.Nombre, Servidor()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                        script_generado2 = script_generado2 + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeVista(vista.Nombre, Servidor2()) + "\r\n" + "\r\n" + "GO" + "\r\n";

                    }
                    else
                    {
                        script_generado1 = script_generado1 + "GO" + "\r\n" + "\r\n" + base_1.ObtenerTextoDeVista(vista.Nombre, Servidor(), Usuario(), Password()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                        script_generado2 = script_generado2 + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeVista(vista.Nombre, Servidor2(), Usuario2(), Password2()) + "\r\n" + "\r\n" + "GO" + "\r\n";
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


        private void btn_script_vistas_diferentes_Click(object sender, EventArgs e)
        {

            if (GridView_vistas_diferentes.Rows.Count == 0)
            {
                return;
            }

            List<Vista> lista_de_vistas = new List<Vista>();

            foreach (DataGridViewRow Fila in GridView_vistas_diferentes.Rows)
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

            foreach (DataGridViewRow Fila in GridView_funciones_diferentes.Rows)
            {
                Funcion funcion_en_fila = new Funcion(Fila.Cells[0].Value.ToString());
                lista_de_funciones.Add(funcion_en_fila);

            }

            GenerarScriptFuncionesDiferentesMerge(lista_de_funciones);
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
                        script_generado1 = script_generado1 + "GO" + "\r\n" + "\r\n" + base_1.ObtenerTextoDeFuncion(funcion.Nombre, Servidor()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                        script_generado2 = script_generado2 + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeFuncion(funcion.Nombre, Servidor2()) + "\r\n" + "\r\n" + "GO" + "\r\n";

                    }
                    else
                    {
                        script_generado1 = script_generado1 + "GO" + "\r\n" + "\r\n" + base_1.ObtenerTextoDeFuncion(funcion.Nombre, Servidor(), Usuario(), Password()) + "\r\n" + "\r\n" + "GO" + "\r\n";
                        script_generado2 = script_generado2 + "GO" + "\r\n" + "\r\n" + base_2.ObtenerTextoDeFuncion(funcion.Nombre, Servidor2(), Usuario2(), Password2()) + "\r\n" + "\r\n" + "GO" + "\r\n";
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

        private void GridView_proc_diferentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


           
    }
}

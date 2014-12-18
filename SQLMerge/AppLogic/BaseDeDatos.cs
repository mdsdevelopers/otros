using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLogic
{
   public class BaseDeDatos
    {

        private List<StoredProcedure> _storedProcedures;
        private string _nombre;

        private List<Tabla> _tablas;
        private List<Vista> _vistas;
        private List<Funcion> _funciones;
        public List<StoredProcedure> StoredProcedures { get { return _storedProcedures; } set { _storedProcedures = value; } }

        public List<Tabla> Tables { get { return _tablas; } set { _tablas = value; } }
        public List<Funcion> Funcions { get { return _funciones; } set { _funciones = value; } }
        public List<Vista> Views { get { return _vistas; } set { _vistas = value; } }

        public string Nombre { get { return _nombre; } set { _nombre = value; } }

        public BaseDeDatos()
        {
        }

        public BaseDeDatos(string nombre)
        {
            this._nombre = nombre;
        }

      
        public List<StoredProcedure> Procedimientos(string direccion_servidor, string base_datos,string usuario, string password)
        {
            List<StoredProcedure> lista_de_procedimientos = new List<StoredProcedure>();
            foreach (string procedimiento in DAL.DbSqlManager.ProcedimientosExistentes(direccion_servidor,this.Nombre,usuario,password))
            {
                StoredProcedure stored_procedure = new StoredProcedure(procedimiento);
                lista_de_procedimientos.Add(stored_procedure);
            }
            return lista_de_procedimientos;
        }


        public List<StoredProcedure> Procedimientos(string direccion_servidor, string base_datos)
        {
            List<StoredProcedure> lista_de_procedimientos = new List<StoredProcedure>();
            foreach (string procedimiento in DAL.DbSqlManager.ProcedimientosExistentes(direccion_servidor, this.Nombre))
            {
                StoredProcedure stored_procedure = new StoredProcedure(procedimiento);
                lista_de_procedimientos.Add(stored_procedure);
            }
            return lista_de_procedimientos;
        }
       

       /*tablas*/

        public List<Tabla> Tablas(string direccion_servidor, string base_datos, string usuario, string password)
        {
            List<Tabla> lista_de_tablas = new List<Tabla>();
            foreach (string tabla in DAL.DbSqlManager.TablasExistentes(direccion_servidor, this.Nombre, usuario, password))
            {
                Tabla table = new Tabla(tabla);
                lista_de_tablas.Add(table);
            }
            return lista_de_tablas;
        }


        public List<Tabla> Tablas(string direccion_servidor, string base_datos)
        {
            List<Tabla> lista_de_tablas = new List<Tabla>();
            foreach (string tabla in DAL.DbSqlManager.TablasExistentes(direccion_servidor, this.Nombre))
            {
                Tabla table = new Tabla(tabla);
                lista_de_tablas.Add(table);
            }
            return lista_de_tablas;
        }

             

        public string ObtenerTextoDeTabla(string nombre_tabla, string nombre_servidor, string usuario, string password)
        {
            try
            {
                return DAL.DbSqlManager.ObtenerTextoDeTabla(nombre_tabla, this._nombre, nombre_servidor, usuario, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }       




        public string ObtenerTextoDeTabla(string nombre_tabla, string nombre_servidor)
        {
            try
            {
                return DAL.DbSqlManager.ObtenerTextoDeTabla2(nombre_tabla, this._nombre, nombre_servidor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }


        public string ObtenerTextoDeTablaManeraLenta(string nombre_tabla, string nombre_servidor)
        {
            try
            {
                return DAL.DbSqlManager.ObtenerTextoDeTablaManeraLenta(nombre_tabla, this._nombre, nombre_servidor);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public string ObtenerTextoDeTablaManeraLenta(string nombre_tabla, string nombre_servidor,string usuario, string password)
        {
            try
            {
                return DAL.DbSqlManager.ObtenerTextoDeTablaManeraLenta(nombre_tabla, this._nombre, nombre_servidor,usuario, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       /*fin tablas*/


       /*funciones*/

        public List<Funcion> Funciones(string direccion_servidor, string base_datos, string usuario, string password)
        {
            List<Funcion> lista_de_funciones = new List<Funcion>();
            foreach (string funcion in DAL.DbSqlManager.FuncionesExistentes(direccion_servidor, this.Nombre, usuario, password))
            {
                Funcion una_funcion = new Funcion(funcion);
                lista_de_funciones.Add(una_funcion);
            }
            return lista_de_funciones;
        }


        public List<Funcion> Funciones(string direccion_servidor, string base_datos)
        {
            List<Funcion> lista_de_funciones = new List<Funcion>();
            foreach (string funcion in DAL.DbSqlManager.FuncionesExistentes(direccion_servidor, this.Nombre))
            {
                Funcion una_funcion = new Funcion(funcion);
                lista_de_funciones.Add(una_funcion);
            }
            return lista_de_funciones;
        }


        public string ObtenerTextoDeFuncion(string nombre_funcion, string nombre_servidor, string usuario, string password)
        {
            try
            {
                return QuitarEspaciosDeInicioYFinal(DAL.DbSqlManager.ObtenerTexto(nombre_funcion, this._nombre, nombre_servidor, usuario, password));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string ObtenerTextoDeFuncion(string nombre_funcion, string nombre_servidor)
        {
            try
            {
                return QuitarEspaciosDeInicioYFinal(DAL.DbSqlManager.ObtenerTexto(nombre_funcion, this._nombre, nombre_servidor));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
       

       /*fin funciones*/



       /*TRIGGERS*/



        public List<Trigger> Triggers(string direccion_servidor, string base_datos, string usuario, string password)
        {
            List<Trigger> lista_de_triggers = new List<Trigger>();
            foreach (string trigger in DAL.DbSqlManager.TriggersExistentes(direccion_servidor, this.Nombre, usuario, password))
            {
                Trigger un_trigger = new Trigger(trigger);
                lista_de_triggers.Add(un_trigger);
            }
            return lista_de_triggers;
        }


        public List<Trigger> Triggers(string direccion_servidor, string base_datos)
        {
            List<Trigger> lista_de_triggers = new List<Trigger>();
            foreach (string trigger in DAL.DbSqlManager.TriggersExistentes(direccion_servidor, this.Nombre))
            {
                Trigger un_trigger = new Trigger(trigger);
                lista_de_triggers.Add(un_trigger);
            }
            return lista_de_triggers;
        }
       

        public string ObtenerTextoDeTrigger(string nombre_trigger, string nombre_servidor, string usuario, string password)
        {
            try
            {
                return QuitarEspaciosDeInicioYFinal(DAL.DbSqlManager.ObtenerTexto(nombre_trigger, this._nombre, nombre_servidor, usuario, password));
            }
            catch (Exception ex)
            {

                throw ex;
            }            
        }
       
        public string ObtenerTextoDeTrigger(string nombre_trigger, string nombre_servidor)
        {
            try
            {
                return QuitarEspaciosDeInicioYFinal(DAL.DbSqlManager.ObtenerTexto(nombre_trigger, this._nombre, nombre_servidor));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        /*FIN TRIGGERS*/




       /*Vistas*/


        public List<Vista> Vistas(string direccion_servidor, string base_datos, string usuario, string password)
        {
            List<Vista> lista_de_vistas = new List<Vista>();
            foreach (string vista in DAL.DbSqlManager.VistasExistentes(direccion_servidor, this.Nombre, usuario, password))
            {
                Vista una_vista = new Vista(vista);
                lista_de_vistas.Add(una_vista);
            }
            return lista_de_vistas;
        }


        public List<Vista> Vistas(string direccion_servidor, string base_datos)
        {
            List<Vista> lista_de_vistas = new List<Vista>();
            foreach (string vista in DAL.DbSqlManager.VistasExistentes(direccion_servidor, this.Nombre))
            {
                Vista una_vista = new Vista(vista);
                lista_de_vistas.Add(una_vista);
            }
            return lista_de_vistas;
        }


        public string ObtenerTextoDeVista(string nombre_vista, string nombre_servidor, string usuario, string password)
        {
            try
            {
                return QuitarEspaciosDeInicioYFinal(DAL.DbSqlManager.ObtenerTexto(nombre_vista, this._nombre, nombre_servidor, usuario, password));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string ObtenerTextoDeVista(string nombre_vista, string nombre_servidor)
        {
            try
            {
                return QuitarEspaciosDeInicioYFinal(DAL.DbSqlManager.ObtenerTexto(nombre_vista, this._nombre, nombre_servidor));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


       /*Vistas*/
       
        public string ObtenerTextoDeProcedimiento(string nombre_procedimiento, string nombre_servidor,string usuario, string password)
        {
            try
            {
                return QuitarEspaciosDeInicioYFinal(DAL.DbSqlManager.ObtenerTexto(nombre_procedimiento, this._nombre, nombre_servidor,usuario,password)); 
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
       }
              
        public string ObtenerTextoDeProcedimiento(string nombre_procedimiento, string nombre_servidor)
        {
            try
            {
                return QuitarEspaciosDeInicioYFinal(DAL.DbSqlManager.ObtenerTexto(nombre_procedimiento, this._nombre, nombre_servidor));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private string QuitarEspaciosDeInicioYFinal(string texto_elemento)
        {

            return texto_elemento.Trim(new Char[] { ' ', '\n', '\r' });

        }



    }
}

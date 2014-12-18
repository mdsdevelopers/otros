using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppLogic
{
    public class Servidor
    {

        private string _nombre;
        private string _direccion;

        private List<BaseDeDatos> _basesDeDatos;


        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Direccion { get { return _direccion; } set { _direccion = value; } }

        public List<BaseDeDatos> BasesDeDatos { get{return _basesDeDatos;} set{_basesDeDatos = value;}}


        public Servidor()
        {


        }

        public Servidor(string direccion )
        {
            this._direccion = direccion;

        }


        public bool ConexionRealizada()
        {
            return DAL.DbSqlManager.ExisteServidor(this._direccion);
                       

        }

        public static string ObtenerProcedimiento(string nombre)
        {

            return DAL.DbSqlManager.ObtenerTexto(nombre);

        }
        public static string ObtenerProcedimiento2(string nombre)
        {

            return DAL.DbSqlManager.ObtenerTexto2(nombre);

        }


        public static void RealizarCopiaDeSeguridad(string nombre_de_base, string ruta_de_destino)
        {
            try
            {
                //DAL.DbSqlManager.GenerarCopiaDeBase(nombre_de_base, ruta_de_destino);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }





        public List<BaseDeDatos> BasesDeDatosExistentes()
        {
            List<string> nombres = DAL.DbSqlManager.BasesDeDatosExistentes(this._direccion);
            List<BaseDeDatos> Lista_de_base = new List<BaseDeDatos>();
            foreach (string un_nombre in nombres)
            {
                BaseDeDatos una_base = new BaseDeDatos(un_nombre);
                Lista_de_base.Add(una_base);

            }


            return Lista_de_base;

        }


    }
}

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


        public List<StoredProcedure> StoredProcedures { get { return _storedProcedures; } set { _storedProcedures = value; } }

        public string Nombre { get { return _nombre; } set { _nombre = value; } }

        public BaseDeDatos()
        {
        }

        public BaseDeDatos(string nombre)
        {
            this._nombre = nombre;
        }

        public List<StoredProcedure> Procedimientos()
        {
            List<StoredProcedure> lista_de_procedimientos = new List<StoredProcedure>();
            foreach (string  procedimiento in DAL.DbSqlManager.ProcedimientosExistentes(this.Nombre))
            {
                StoredProcedure stored_procedure = new StoredProcedure(procedimiento);
                lista_de_procedimientos.Add(stored_procedure);
            }
            return lista_de_procedimientos;       
        }



        public string ObtenerTextoDeProcedimiento(string nombre_procedimiento)
        {
            try
            {
                return DAL.DbSqlManager.ObtenerTexto(nombre_procedimiento, this._nombre); 
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

           

        }




    }
}

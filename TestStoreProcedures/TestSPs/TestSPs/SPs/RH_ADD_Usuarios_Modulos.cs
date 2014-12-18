using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class RH_ADD_Usuarios_Modulos:StoredProcedure
    {

        public RH_ADD_Usuarios_Modulos(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {

                case "@Id_Usuario_1":
                    parametro.Value = 2;
                    return true;

                case "@Id_Modulo_2":
                    parametro.Value = 2;
                    return true;
            
                default:
                    return false;

            }
        }
    }
}

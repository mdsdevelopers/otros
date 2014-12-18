using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class ESTR_ADD_Baja_En_Tramite_Areas:StoredProcedure
    {

        public ESTR_ADD_Baja_En_Tramite_Areas(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {

                case "@IdActoAdm":
                    parametro.Value = 1;
                    return true;

                case "@IdAreaMadre":
                    parametro.Value = 2;
                    return true;

                case "@IdUsuario":
                    parametro.Value = 18;
                    return true;

                default:
                    return false;
            }
        }
    }
}

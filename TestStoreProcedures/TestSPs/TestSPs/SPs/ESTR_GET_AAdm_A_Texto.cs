using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class ESTR_GET_AAdm_A_Texto:StoredProcedure
    {

        public ESTR_GET_AAdm_A_Texto(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {
                case "@IdActoAdm":
                    parametro.Value = 2;
                    return true;

                case "@IdArea":
                    parametro.Value = 2;
                    return true;

                default:
                    return false;
            }
        }
    }
}

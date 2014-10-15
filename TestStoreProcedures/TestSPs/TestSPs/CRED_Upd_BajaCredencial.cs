using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class CRED_Upd_BajaCredencial:StoredProcedure
    {
        public CRED_Upd_BajaCredencial(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {
                case "@IdBaja":
                    parametro.Value = 4207;
                    return true;

                case "@IdCredencial":
                    parametro.Value = 10356;
                    return true;

                default:
                    return false;
            }
        }
    }
}

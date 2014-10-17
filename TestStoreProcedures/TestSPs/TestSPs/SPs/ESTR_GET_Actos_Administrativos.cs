using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class ESTR_GET_Actos_Administrativos : StoredProcedure
    {

        public ESTR_GET_Actos_Administrativos(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {
                case "@Acto_Nro":
                    parametro.Value = 198;
                    return true;

                case "@Acto_Tipo":
                    parametro.Value = 4;
                    return true;

                case "@Acto_Fecha":
                    parametro.Value = 20140814;
                    return true;                

                default:
                    return false;
            }
        }
    }
}

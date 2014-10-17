using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class CRED_Ins_DatosPersonalesRelevados:StoredProcedure
    {
        public CRED_Ins_DatosPersonalesRelevados(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {
                case "@Dni":
                    parametro.Value = 29753915;
                    return true;
                default:
                    return false;
            }
        }
    }
}

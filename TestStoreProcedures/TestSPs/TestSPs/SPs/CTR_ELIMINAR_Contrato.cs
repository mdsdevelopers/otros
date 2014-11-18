using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class CTR_ELIMINAR_Contrato:StoredProcedure
    {
        public CTR_ELIMINAR_Contrato(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {
                case "@Id_Contrato":
                    parametro.Value = 1;
                    return true;
                default:
                    return false;
            }
        }
    
    }
}

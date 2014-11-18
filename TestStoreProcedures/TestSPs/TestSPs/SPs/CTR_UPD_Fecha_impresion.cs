using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class CTR_UPD_Fecha_impresion:StoredProcedure
    {

        public CTR_UPD_Fecha_impresion(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {
                case "@Id_Contrato":
                    parametro.Value = 2;
                    return true;

                case "@fecha":
                    parametro.Value = DateTime.Now;
                    return true;
                    
                default:
                    return false;
            }
        }
    }
}

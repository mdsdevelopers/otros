using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class ASIS_GET_Planillas_Firmas_Faltantes:StoredProcedure
    {

        public ASIS_GET_Planillas_Firmas_Faltantes(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {
                case "@PeriodoDesde":
                    parametro.Value = 072011;
                    return true;
                case "@PeriodoHasta":
                    parametro.Value = 072011;
                    return true;
                default:
                    return false;
            }
        }
    }
}

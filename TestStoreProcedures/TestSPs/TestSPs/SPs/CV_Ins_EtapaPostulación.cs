using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class CV_Ins_EtapaPostulación:StoredProcedure
    {

        public CV_Ins_EtapaPostulación(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {
                case "@IdPostulacion":
                    parametro.Value = 48;
                    return true;
                default:
                    return false;
            }
        }
    }
}

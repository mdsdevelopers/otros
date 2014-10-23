using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class LEG_DEL_Legajo:StoredProcedure
    {

        public LEG_DEL_Legajo(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {

            case "@Id_Interna":
                    parametro.Value = 200054;
                    return true;

            case "@Nro_Doc":
                    parametro.Value = 10198904;
                    return true;

            case "@Fecha_Baja":
                    parametro.Value = DateTime.Now;
                    return true;

            case "@Motivo_Baja":
                    parametro.Value = 1;
                    return true;
                     
            case "@usuario":
                    parametro.Value = 41;
                    return true;

            case "@acto":
                    parametro.Value = 1;
                    return true;

            case "@nro":
                    parametro.Value = 3149;
                    return true;

            case "@fecha_acto":
                    parametro.Value = DateTime.Now;
                    return true;
            
            case "@firmante":
                    parametro.Value = 58;
                    return true;
            
            default:
                    return false;
            }
        }
    }
}

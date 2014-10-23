using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class SACC_Ins_Evaluacion:StoredProcedure
    {

        public SACC_Ins_Evaluacion(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {

            case "@id_alumno":
                    parametro.Value = 41;
                    return true;
            
            case "@id_instancia_evaluacion":
                    parametro.Value = 1;
                    return true;
            
            case "@calificacion":
                    parametro.Value = "T";
                    return true;

            case "@fecha_evaluacion":
                    parametro.Value = DateTime.Now;
                    return true;
            
            case "@id_usuario":
                    parametro.Value = 306;
                    return true;

            case "@fecha":
                    parametro.Value = DateTime.Now;
                    return true;

            case "@baja":
                    parametro.Value = "";
                    return true;

                default:
                    return false;
            }
        }
    }
}

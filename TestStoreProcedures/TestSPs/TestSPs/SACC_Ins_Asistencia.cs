using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class SACC_Ins_Asistencia:StoredProcedure
    {

        public SACC_Ins_Asistencia(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {
                case "@id_alumno":
                    parametro.Value = 58142;
                    return true;

                case "@id_curso":
                    parametro.Value = 109;
                    return true;

                case "@fecha":
                    parametro.Value = "2011-10-10 00:00:00.000";
                    return true;

                case "@valor":
                    parametro.Value = 15092014;
                    return true;

                case "@id_usuario":
                    parametro.Value = 233;
                    return true;

                default:
                    return false;
            }
        }
    }
}
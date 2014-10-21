using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class SACC_Ins_Inscripcion:StoredProcedure
    {

        public SACC_Ins_Inscripcion(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {
 
                case "@idCurso":
                    parametro.Value = 76;
                    return true;
                    
                case "@idAlumno":
                    parametro.Value = 390;
                    return true;
            
                case "@IdUsuario":
                    parametro.Value = 18;
                    return true;

                case "@Fecha":
                    parametro.Value = DateTime.Now;
                    return true;

                case "@IdBaja":
                    parametro.Value = 1;
                    return true;

                default:
                    return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class SACC_Upd_Del_Docente:StoredProcedure
    {

        public SACC_Upd_Del_Docente(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {

                case "@IdDocente":
                    parametro.Value = 57590;
                    return true;

                case "@IdUsuario":
                    parametro.Value = 294;
                    return true;

                case "@Fecha":
                    parametro.Value = DateTime.Now;
                    return true;            

                case "@idBaja":
                    parametro.Value = "";
                    return true;

                default:
                    return false;
            }
        }
    }
}

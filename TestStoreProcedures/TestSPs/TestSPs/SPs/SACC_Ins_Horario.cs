using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class SACC_Ins_Horario:StoredProcedure
    {

        public SACC_Ins_Horario(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {
              
                case "@nro_dia_semana":
                    parametro.Value = 1;
                    return true;

                case "@id_curso":
                    parametro.Value = 84;
                    return true;            

                case "@desde":
                    parametro.Value = "1000";
                    return true;

                case "@hasta":
                    parametro.Value = "2000";
                    return true;
                
                case "@horas_catedra":
                    parametro.Value = 2;
                    return true;

                default:
                    return false;
            }
        }
    }
}

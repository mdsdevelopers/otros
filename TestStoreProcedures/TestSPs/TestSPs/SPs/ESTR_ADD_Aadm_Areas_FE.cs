using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class ESTR_ADD_Aadm_Areas_FE:StoredProcedure
    {

        public ESTR_ADD_Aadm_Areas_FE(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {
                case "@Id_Area":
                    parametro.Value = 640;
                    return true;

                case "@Id_Accion":
                    parametro.Value = 10;
                    return true;

                case "@Id_Nivel_FE":
                    parametro.Value = 4;
                    return true;

                case "@Id_Acto":
                    parametro.Value = 5;
                    return true;

                case "@Fecha_Desde":
                    parametro.Value = DateTime.Now;
                    return true;

                case "@Usuario":
                    parametro.Value = 8;
                    return true;

                case "@Id_Area_Anterior":
                    parametro.Value = 1;
                    return true;

                default:
                    return false;
            }
        }
    }
}

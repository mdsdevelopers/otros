using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class MAU_CrearPersona:StoredProcedure
    {

        public MAU_CrearPersona(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {

            case "@tipoDocumento":
                    parametro.Value = 1;
                    return true;

            case "@documento":
                    parametro.Value = 99999999;
                    return true;

            case "@nombre":
                    parametro.Value = "Prueba TestSPs";
                    return true;

            case "@apellido":
                    parametro.Value = "Prueba TestSPs";
                    return true;

                default:
                    return false;
            }
        }
    }
}

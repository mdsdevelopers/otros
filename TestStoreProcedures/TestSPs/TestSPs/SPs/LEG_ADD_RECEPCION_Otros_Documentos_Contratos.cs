using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class LEG_ADD_RECEPCION_Otros_Documentos_Contratos:StoredProcedure
    {

        public LEG_ADD_RECEPCION_Otros_Documentos_Contratos(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {
                case "@Tipo":
                    parametro.Value = "T";
                    return true;

                case "@Foja":
                    parametro.Value = "T";
                    return true;

                case "@idUsuario":
                    parametro.Value = 1;
                    return true;

                case "@idContrato":
                    parametro.Value = 2;
                    return true;

                default:
                    return false;


            }
        }
    }
}

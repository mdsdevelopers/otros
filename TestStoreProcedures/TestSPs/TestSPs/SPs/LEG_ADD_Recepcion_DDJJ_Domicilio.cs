using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class LEG_ADD_Recepcion_DDJJ_Domicilio:StoredProcedure
    {

        public LEG_ADD_Recepcion_DDJJ_Domicilio(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {

                case "@nro_documento":
                    parametro.Value = 6278699;
                    return true;

                case "@fecha_codigo_barra":
                    parametro.Value = DateTime.Now;
                    return true;

                case "@usuario":
                    parametro.Value = 1;
                    return true;

                case "@id_comprobante":
                    parametro.Value = 1;
                    return true;

                default:
                    return false;


            }
        }
    }
}

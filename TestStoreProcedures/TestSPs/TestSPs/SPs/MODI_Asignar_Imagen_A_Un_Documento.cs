using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class MODI_Asignar_Imagen_A_Un_Documento:StoredProcedure
    {

        public MODI_Asignar_Imagen_A_Un_Documento(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {
                
                case "@id_imagen":
                case "@id_documento":
                    parametro.Value = 1;
                    return true;
                
                case "@tabla":
                    parametro.Value = "T";
                    return true;

                default:
                    return false;
            }
        }
    }
}

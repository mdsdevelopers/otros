using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class CV_Ins_DatosPersonalesNoEmpleados1ravez:StoredProcedure
    {

        public CV_Ins_DatosPersonalesNoEmpleados1ravez(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {
                case "@Dni":
                    parametro.Value = 56654456;
                    return true;
                
                case "@IdPersona":
                    parametro.Value = 58978;
                    return true;

                case "@Apellido":
                case "@Cuil":
                case "@LugarDeNacimiento":
                    parametro.Value = "T";
                    return true;

                case "@TipoDocumento":
                case "@Nacionalidad":
                case "@Sexo":
                case "@usuario":
                    parametro.Value = 1;
                    return true;

                case "@FechaNacimiento":
                    parametro.Value = DateTime.Now;
                    return true;

                default:
                    return false;
            }
        }
    }
}
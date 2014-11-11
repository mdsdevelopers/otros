using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class CTR_ADD_Datos_Personales:StoredProcedure
    {
        public CTR_ADD_Datos_Personales(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {
                case "@Tipo_Documento":
                    parametro.Value = 1;
                    return true;

                case "@Nro_Documento":
                    parametro.Value = 26200965;
                    return true;

                case "@Id_Interna":
                    parametro.Value = 59120;
                    return true;

                case "@Apellido":
                    parametro.Value = "T";
                    return true;

                case "@Nombre":
                    parametro.Value = "T";
                    return true;

                case "@Cuil_Nro":
                    parametro.Value = "T";
                    return true;

                case "@Estado_Civil":
                    parametro.Value = 1;
                    return true;

                case "@Fecha_Nacimiento":
                    parametro.Value = DateTime.Now;
                    return true;

                case "@Sexo":
                    parametro.Value = 1;
                    return true;

                case "@Nacionalidad":
                    parametro.Value = 1;
                    return true;

                case "@Regimen_Jubilatorio":
                    parametro.Value = 1;
                    return true;

                case "@Denominacion":
                    parametro.Value = 1;
                    return true;

                case "@Prioridad":
                    parametro.Value = 1;
                    return true;

                default:
                    return false;
            }
        }
    
    }
}

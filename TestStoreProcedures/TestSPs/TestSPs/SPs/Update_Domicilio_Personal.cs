using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class Update_Domicilio_Personal:StoredProcedure
    {

        public Update_Domicilio_Personal(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {
                
                case "@Fecha_Comunicacion_21":
                    parametro.Value = DateTime.Now;
                    return true;

                case "@Calle_22":
                    parametro.Value = "T";
                    return true;

                case "@Número_23":
                    parametro.Value = 1;
                    return true;                

                case "@Piso_24":
                    parametro.Value = "T";
                    return true;

                case "@Dpto_25":
                    parametro.Value = "T";
                    return true;

                case "@Casa_26":
                    parametro.Value = "T";
                    return true;

                case "@Manzana_27":
                    parametro.Value = "T";
                    return true;

                case "@Barrio_28":
                    parametro.Value = "T";
                    return true;

                case "@Torre_29":
                    parametro.Value = "T";
                    return true;

                case "@UF_30":
                    parametro.Value = "T";
                    return true;

                case "@Localidad_31":
                    parametro.Value = 1;
                    return true;

                case "@Codigo_Postal_32":
                    parametro.Value = 1;
                    return true;
                
                case "@Partido_Dpto_33":
                    parametro.Value = "T";
                    return true;

                case "@Provincia_34":
                    parametro.Value = "T";
                    return true;
                
                case "@Telefono_35":
                    parametro.Value = "T";
                    return true;

                case "@Correo_Electronico_36":
                    parametro.Value = "PRUEBA@PRUEBA.COM";
                    return true;
                  
                case "@Folio_37":
                    parametro.Value = "T";
                    return true;

                case "@Id_Interna_38":
                    parametro.Value = 59120;
                    return true;

                case "@Nro_Doc_39":
                    parametro.Value = "12345678";
                    return true;

                case "@ID_Domicilio_40":
                    parametro.Value = 11;
                    return true;

                case "@baja":
                    parametro.Value = 1;
                    return true;

                case "@usuario":
                    parametro.Value = 1;
                    return true;
             
                default:
                    return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class CTR_ADD_Contrato_Certificado_Automatico_PASO3:StoredProcedure
    {

        public CTR_ADD_Contrato_Certificado_Automatico_PASO3(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {

                case "@Id_Domicilio_2":
                    parametro.Value = 4575;
                    return true;

                case "@Nro_Documento_3":
                    parametro.Value = 4198921;
                    return true;

                case "@Tipo_Contrato_4":
                    parametro.Value = 1;
                    return true;

                case "@Nro_Contrato_5":
                    parametro.Value = "T";
                    return true;

                case "@Desde_6":
                    parametro.Value = DateTime.Now;
                    return true;

                case "@Hasta_7":
                    parametro.Value = DateTime.Now;
                    return true;

                case "@Nivel_8":
                    parametro.Value = 0;
                    return true;

                case "@Grado_9":
                    parametro.Value = 1;
                    return true;

                case "@Funcion_10":
                    parametro.Value = 1;
                    return true;

                case "@Rango_11":
                    parametro.Value = 1;
                    return true;

                case "@Monto_12":
                    parametro.Value = 1;
                    return true;

                case "@Id_Area_13":
                    parametro.Value = 1;
                    return true;


                case "@Contrato_Firmante_24":
                    parametro.Value = 1;
                    return true;

                case "@Excepcion_26":
                    parametro.Value = 1;
                    return true;

                case "@Enmienda_27":
                    parametro.Value = 1;
                    return true;

                case "@Observacion_31":
                    parametro.Value = "T";
                    return true;

                case "@Estado_32":
                    parametro.Value = "T";
                    return true;

                case "@Usuario":
                    parametro.Value = 1;
                    return true;

                case "@Salvado":
                    parametro.Value = 1;
                    return true;

                case "@Nro_Contrato_Ant":
                    parametro.Value = "05-4198921";
                    return true;

                case "@Meses_Calculo_Antiguedad":
                    parametro.Value = 1;
                    return true;

                case "@hostId":
                    parametro.Value = "T";
                    return true;

                default:
                    return false;
            }
        }
    }
}

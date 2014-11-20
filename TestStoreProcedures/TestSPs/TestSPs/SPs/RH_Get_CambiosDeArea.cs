using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class CTR_DEL_Contratos:StoredProcedure
    {

        public CTR_DEL_Contratos(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {
                case "@Nro_Documento":
                    parametro.Value = 34415954 ;
                    return true;

                case "@Id_Contrato_2":
                    parametro.Value = 45504;
                    return true;

                case "@Acto_Tipo_3":
                    parametro.Value = 1;
                    return true;

                case "@Acto_Nro_4":
                    parametro.Value = "T";
                    return true;

                case "@Acto_Fecha_5":
                    parametro.Value = DateTime.Now;
                    return true;

                case "@Acto_Firmante_6":
                    parametro.Value = 1;
                    return true;

                case "@Motivo_Baja_7":
                    parametro.Value = 1;
                    return true;

                case "@Fecha_Baja_8":
                    parametro.Value = DateTime.Now;
                    return true;

                case "@Usuario_9":
                    parametro.Value = 1;
                    return true;

                default:
                    return false;
            }
        }
    }
}

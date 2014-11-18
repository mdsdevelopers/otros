using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class alta_Datos_Familiares:StoredProcedure
    {

        public alta_Datos_Familiares(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {
                case "@Apellido_1":
                    parametro.Value = "T";
                    return true;

                case "@Nombre_2":
                    parametro.Value = "T";
                    return true;

                case "@Parentesco_3":
                    parametro.Value = 1;
                    return true;

                case "@Sexo_4":
                    parametro.Value = 1;
                    return true;

                case "@Fecha_Nacimiento_5":
                    parametro.Value = DateTime.Now;
                    return true;

                case "@Nacionalidad_6":
                    parametro.Value = 1;
                    return true;

                case "@Fam_Docum_Tipo_7":
                    parametro.Value = 1;
                    return true;

                case "@Fam_Docum_Nrodoc_8":
                    parametro.Value = 12345678;
                    return true;

                case "@Fam_CI_9":
                    parametro.Value = 1;
                    return true;

                case "@Fam_CI_expedido_por_10":
                    parametro.Value = "T";
                    return true;

                case "@Fam_otrotipo_11":
                    parametro.Value = "T";
                    return true;

                case "@Fam_otrotipo_expedido_por_12":
                    parametro.Value = "T";
                    return true;


                case "@Tel1_13":
                    parametro.Value = "T";
                    return true;

                case "@Tel2_14":
                    parametro.Value = "T";
                    return true;

                case "@Tel2_15":
                    parametro.Value = "T";
                    return true;

                case "@Lugar_16":
                    parametro.Value = "T";
                    return true;

                case "@Fecha_17":
                    parametro.Value = DateTime.Now;
                    return true;

                case "@Fecha_Fallecimiento_18":
                    parametro.Value = DateTime.Now;
                    return true;

                case "@Lugar_Fallecimiento_informe_19":
                    parametro.Value = "T";
                    return true;

                case "@Fecha_Fallecimiento_informe_20":
                    parametro.Value = DateTime.Now;
                    return true;

                case "@Id_Interna_21":
                    parametro.Value = 94238403;
                    return true;

                case "@Doc_Titular_22":
                    parametro.Value = 94238403;
                    return true;

                case "@Escolaridad_23":
                    parametro.Value = 1;
                    return true;

                case "@ACargoDesde_24":
                    parametro.Value = DateTime.Now;
                    return true;

                case "@ACargoHasta_25":
                    parametro.Value = DateTime.Now;
                    return true;

                case "@discapacitado_26":
                    parametro.Value = 1;
                    return true;

                case "@adoptado_27":
                    parametro.Value = 1;
                    return true;

                case "@Cert_Nacimiento":
                    parametro.Value = 1;
                    return true;

                case "@Cert_Matrimonio":
                    parametro.Value = 1;
                    return true;

                case "@Usuario":
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

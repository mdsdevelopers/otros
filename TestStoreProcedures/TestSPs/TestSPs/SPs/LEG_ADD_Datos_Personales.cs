using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class LEG_ADD_Datos_Personales:StoredProcedure
    {

        public LEG_ADD_Datos_Personales(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {

                case "@Id_Interna_1":
                    parametro.Value = 88777;
                    return true;

                case "@Apellido_2":
                    parametro.Value = "T";
                    return true;

                case "@Nombre_3":
                    parametro.Value = "T";
                    return true;

                case "@Sexo_5":
                    parametro.Value = 1;
                    return true;

                case "@Fecha_Nacimiento_6":
                    parametro.Value = DateTime.Now;;
                    return true;

                case "@Lugar_Nacimiento_7":
                    parametro.Value = 'T';
                    return true;
                
                case "@Nacionalidad_8":
                    parametro.Value = 1;
                    return true;

                case "@Fecha_Ingreso_Pais_9":
                    parametro.Value = DateTime.Now;;
                    return true;

                case "@Carta_Ciudadania_10":
                    parametro.Value = "T";
                    return true;

                case "@Juzgado_11":
                    parametro.Value = "T";
                    return true;

                case "@Secretario_12":
                    parametro.Value = "T";
                    return true;

                case "@Fecha_Juzgado_13":
                    parametro.Value = DateTime.Now;;
                    return true;

                case "@Cuil_Nro_14":
                    parametro.Value = 'T';
                    return true;

                case "@Tipo_Documento_15":
                    parametro.Value = 1;
                    return true;

                case "@Nro_Documento_16":
                    parametro.Value = 26247028;
                    return true;

                case "@Distrito_Militar_17":
                    parametro.Value = 1;
                    return true;

                case "@Clase_18":
                    parametro.Value = 1;
                    return true;

                case "@Cedula_Identidad_19":
                    parametro.Value = 1;
                    return true;

                case "@Expedida_por_20":
                    parametro.Value = 'T';
                    return true;

                case "@Regimen_Jubilatorio_21":
                    parametro.Value = 1;
                    return true;

                case "@Estado_Civil_22":
                    parametro.Value = 1;
                    return true;

                case "@Fecha_Matrimonio_23":
                    parametro.Value = DateTime.Now;
                    return true;

                case "@Fecha_Matrimonio_2da_24":
                    parametro.Value = DateTime.Now;
                    return true;

                case "@Grupo_Sanguineo_25":
                    parametro.Value = 1;
                    return true;

                case "@Factor_Sanguineo_26":
                    parametro.Value = 'T';
                    return true;

                case "@Credencial_27":
                    parametro.Value = 1;
                    return true;

                case "@Obra_Social_28":
                    parametro.Value = 1;
                    return true;

                case "@Nro_Afiliado_29":
                    parametro.Value = 'T';
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


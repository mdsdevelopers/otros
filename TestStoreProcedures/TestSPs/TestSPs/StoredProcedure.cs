using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TestStoredProcedures
{
    public class StoredProcedure
    {
        protected string nombre_sp;
        protected SqlConnection conexion;
        protected LoggerEjecucionSps logger;

        public static StoredProcedure New(string nombre_sp_a_crear, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
        {
            switch (nombre_sp_a_crear)
            {
                case "ASIS_ALTA_Autorizaciones_Licencia":
                    return new ASIS_ALTA_Autorizaciones_Licencia(nombre_sp_a_crear, conexion_del_sp, logger_sp);

                case "CRED_Ins_DatosPersonalesRelevados":
                    return new CRED_Ins_DatosPersonalesRelevados(nombre_sp_a_crear, conexion_del_sp, logger_sp);
                
                case "CTR_ADD_Datos_Personales":
                    return new CTR_ADD_Datos_Personales(nombre_sp_a_crear, conexion_del_sp, logger_sp);
                
                case "MAU_CrearPersona":
                    return new MAU_CrearPersona(nombre_sp_a_crear, conexion_del_sp, logger_sp);

                case "PLA_get_firmantes_fecha":
                    return new PLA_get_firmantes_fecha(nombre_sp_a_crear, conexion_del_sp, logger_sp);

                case "SACC_Ins_Asistencia":
                    return new SACC_Ins_Asistencia(nombre_sp_a_crear, conexion_del_sp, logger_sp);
           
                case "ESTR_Copiar_Usuarios_Area_Anterior":
                    return new ESTR_Copiar_Usuarios_Area_Anterior(nombre_sp_a_crear, conexion_del_sp, logger_sp);

                default:
                    return new StoredProcedure(nombre_sp_a_crear, conexion_del_sp, logger_sp);
            }
        }

        public StoredProcedure(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
        {
            nombre_sp = nombre;
            conexion = conexion_del_sp;
            logger = logger_sp;
        }

        public void Ejecutar()
        {
            var resultado_un_sp = new DataTable();
            var comando_ejecutar_un_sp = conexion.CreateCommand();
            var transaction = conexion.BeginTransaction(IsolationLevel.Serializable);
            comando_ejecutar_un_sp.Transaction = transaction;

            comando_ejecutar_un_sp.CommandText = nombre_sp;
            comando_ejecutar_un_sp.Connection = conexion;
            comando_ejecutar_un_sp.CommandType = System.Data.CommandType.StoredProcedure;
            comando_ejecutar_un_sp.CommandTimeout = 2;

            SqlCommandBuilder.DeriveParameters(comando_ejecutar_un_sp);

            var adapter_cada_sp = new SqlDataAdapter();
            adapter_cada_sp.SelectCommand = comando_ejecutar_un_sp;

            for (int i = 1; i < comando_ejecutar_un_sp.Parameters.Count; i++)
            {
                CompletarParametro(comando_ejecutar_un_sp.Parameters[i]);
            }
            try
            {
                adapter_cada_sp.Fill(resultado_un_sp);
                logger.LogEjecucionCorrecta(nombre_sp);
            }
            catch (SqlException se)
            {
                HandlearError(comando_ejecutar_un_sp, se);
            }
            catch (ArgumentException ae)
            {
                HandlearError(comando_ejecutar_un_sp, ae);
            }
            catch (InvalidOperationException ioo)
            {
                HandlearError(comando_ejecutar_un_sp, ioo);
            }
            catch (OutOfMemoryException oom)
            {
                HandlearError(comando_ejecutar_un_sp, oom);
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                transaction.Rollback();
            }
        }

        public void CompletarParametro(SqlParameter parametro)
        {
            if (CompletarParametroEspecifico(parametro))
            {
                return;
            }
            CompletarParametroGenerico(parametro);
        }


        /// <summary>
        /// Posee la especificacion de valores para parametros con nombres específicos, utilizados por varios stored procedures. E.g. @IdInterna
        /// Tener en cuenta que si para un cierto stored procedure concreto, ese valor debe ser distinto, deberá entonces crearse una clase para 
        /// redefinir exclusivamente el valor para ese parametro en ese sp.
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        protected virtual bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            switch (parametro.ParameterName)
            {
                case "@Fam_Docum_Nrodoc_8":
                    parametro.Value = 12345678;
                    return true;
                
                // CTR_ADD_Contrato_Certificado_Automatico_PASO3
                case "@TipoCertificado":
                    parametro.Value = 3;
                    return true;
                
                case "@idPersona":
                    parametro.Value = 2559;
                    return true;
                //agregados por CV_Ins_EtapaPostulación
                case "@IdPostulaciona":
                    parametro.Value = 66;
                    return true;
                
                case "@idDomicilio":
                    parametro.Value = 14788;
                    return true;

                //agregados por LEG_ADD_RECEPCION_Otros_Documentos_Contratos
                // agregado por CRED_USUARIOS
                case "@IdUsuario":                
                case "@idusuario":
                    parametro.Value = 18;
                    //parametro.Value = 233;
                    return true;

                case "@idContrato":
                    parametro.Value = 01-26200965;
                    return true;

                //agregado por [ESTR_GET_Actos_Administrativos]
             //   case "@Acto_Fecha":
               //     parametro.Value = 20130101;
                 //   return true;

                // agregado por dbo.LEG_Ejecutar_SP
                case "@sql":
                    parametro.Value = "WEB_GetAmbitoLaboral";
                    return true;
                case "@id_alumno":
                    parametro.Value = 58142;
                    return true;         
                case "@id_espacioFisico":
                    parametro.Value = 11;
                    return true;
                
                //agregado por SAC_ins_Curso
                case "@IdMateria":
                case "@id_materia":
                    parametro.Value = 95;
                    return true;
                case "@IdDocente":
                    parametro.Value = 99999;
                    return true;
                case "@idCurso":
                case "@IdCurso":
                case "@id_curso":
                    parametro.Value = 109;
                    return true;
                case "@baja":
                case "@Baja":
                    parametro.Value = 2284;
                    return true;

                case "@idBaja":
                    parametro.Value = 4207;
                    return true;

                case "@Doc_Titular_22":
                case "@Dni":
                case "@Documento":
                case "@Nro_Doc":
                case "@Nro_Documento":
                case "@nro_documento":
                case "@Nro_Documento_16":
                case "@Nro_doc_6":
                    parametro.Value = 26200965;
                    return true;

                case "@documento":
                    parametro.Value = 99999990;
                    return true;

                case "@IdDocumento":
                case "@id_documento":
                    parametro.Value = 3;
                    return true;

                case "@Id_Interna_21":
                case "@Id_Interna_5":
                    parametro.Value = 201530;
                    return true;

                case "@id_autorizacion":
                    parametro.Value = 187578;
                    return true;

                case "@IdCredencial":
                    parametro.Value = 10356;
                    return true;

                case "@IdAutorizante":
                    parametro.Value = 2489;
                    return true;

                case "@Id_Domicilio_2":
                    parametro.Value = 14672;
                    return true;

                case "@Id_Ingreso":
                    parametro.Value = 4;
                    return true;

                case "@año":
                case "@Año":
                    parametro.Value = 2010;
                    return true;
                default:
                    return false;
            }
        }

        protected void CompletarParametroGenerico(SqlParameter parametro)
        {
            switch (parametro.SqlDbType)
            {
                case SqlDbType.Real:
                case SqlDbType.BigInt:
                case SqlDbType.Int:
                case SqlDbType.Bit:
                case SqlDbType.SmallInt:
                case SqlDbType.TinyInt:
                case SqlDbType.Decimal:
                case SqlDbType.Money:
                case SqlDbType.Float:
                case SqlDbType.SmallMoney:
                    parametro.Value = 1;
                    break;

                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.NText:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                case SqlDbType.VarChar:
                    parametro.Value = "T";
                    break;

                case SqlDbType.Time:
                case SqlDbType.Timestamp:
                case SqlDbType.Date:
                case SqlDbType.DateTime:
                case SqlDbType.DateTime2:
                case SqlDbType.SmallDateTime:
                    parametro.Value = DateTime.Now;
                    break;

                case SqlDbType.VarBinary:
                    parametro.Value = new byte[1];
                    break;

                default:
                    throw new Exception("No se ha especificado un valor por defecto para el tipo de parámetro");
            }
        }

        private void HandlearError(SqlCommand comando, Exception e)
        {
            logger.LogError(e, comando);
        }
    }
}

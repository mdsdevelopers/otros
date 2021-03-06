﻿using System;
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
                    parametro.Value = 29753915;
                    return true;
                case "@Doc_Titular_22":
                case "@Dni":
                case "@Documento":
                case "@Nro_Doc":
                case "@documento":
                case "@Nro_Documento":
                case "@nro_documento":
                case "@Nro_doc_6":
                    parametro.Value = 29753914;
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
                case "@año":
                    parametro.Value = 1999;
                    return true;
                case "@Año":
                    parametro.Value = 1999;
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

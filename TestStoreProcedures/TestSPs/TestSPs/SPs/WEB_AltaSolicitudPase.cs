using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class WEB_AltaSolicitudPase:StoredProcedure
    {

        public WEB_AltaSolicitudPase(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {
                case "@documento":
                    parametro.Value = 35567203;
                    return true;

                case "@idAreaActual":
                    parametro.Value = 1;
                    return true;

                case "@idAreaNueva":
                    parametro.Value = 54;
                    return true;

                case "@idUsuarioSolicito":
                    parametro.Value = 8;
                    return true;

                default:
                    return false;
            }
        }
    }
}

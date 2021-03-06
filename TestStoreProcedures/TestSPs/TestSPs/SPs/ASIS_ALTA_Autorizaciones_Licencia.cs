﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class ASIS_ALTA_Autorizaciones_Licencia:StoredProcedure
    {

        public ASIS_ALTA_Autorizaciones_Licencia(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {
                case "@año":
                    parametro.Value = 1999;
                    return true;
                default:
                    return false;
            }
        }
    }
}

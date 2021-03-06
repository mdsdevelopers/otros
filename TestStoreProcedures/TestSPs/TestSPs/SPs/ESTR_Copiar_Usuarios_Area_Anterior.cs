﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TestStoredProcedures
{
    public class ESTR_Copiar_Usuarios_Area_Anterior:StoredProcedure
    {

        public ESTR_Copiar_Usuarios_Area_Anterior(string nombre, SqlConnection conexion_del_sp, LoggerEjecucionSps logger_sp)
            : base(nombre, conexion_del_sp, logger_sp)
        {

        }

        protected override bool CompletarParametroEspecifico(SqlParameter parametro)
        {
            var result = base.CompletarParametroEspecifico(parametro);
            switch (parametro.ParameterName)
            {
                case "@IdAreaAnterior":
                    parametro.Value = 1316;
                    return true;
                case "@IdAreaNueva":
                    parametro.Value = 1315;
                    return true;
                default:
                    return false;
            }
        }
    }
}

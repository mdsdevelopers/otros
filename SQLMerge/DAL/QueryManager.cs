using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
  public static class QueryManager
    {
      
      public static string SentenciaTextoTabla()
      {
          return "sp_help ";
      }

      public static string SentenciaTexto()
      {
          return "sp_helptext ";
      }

      public static string SentenciaBasesExistentes()
      {
          return "select name from master..sysdatabases order by name asc";
      }


      public static string SentenciaFuncionesExistentes(string nombre_de_base)
      {

        return "select name from " + nombre_de_base + "..sysobjects where type = 'FN' and category <> 2 order by name asc";


      }


      public static string SentenciaVistasExistentes(string nombre_de_base)
      {
          return "select name from " + nombre_de_base + "..sysobjects where type = 'V' and category <> 2 order by name asc";
   
      }


      public static string SentenciaTriggersExistentes(string nombre_de_base)
      {
          return "select name from " + nombre_de_base + "..sysobjects where type = 'TR' and category <> 2 order by name asc";

      }


      public static string SentenciaTablasExistentes(string nombre_de_base)
      {
          return "select name from " + nombre_de_base + "..sysobjects where type = 'u' and category <> 2 order by name asc";
               
      }
      public static string SentenciaProcedimientosExistentes(string nombre_de_base)
      {
          return "select name from " + nombre_de_base + "..sysobjects where type = 'p' and category <> 2 order by name asc";

      }


      public static string SentenciaExisteElemento(string nombre_elemento)
      {

        return "SELECT OBJECT_ID('" + nombre_elemento + "') AS 'Object ID'";
      }



    }
}

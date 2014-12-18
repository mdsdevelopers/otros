using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuscadorConcursar
{
    public class Postulacion
    {
        public int NroDocumento;
        public string TipoDocumento;
        public string Apellido;
        public string Nombres;
        public string DescripcionPuesto;
        public string EstadoPostulacion;
        public string Observaciones;
        public string Acta;

        public Postulacion(int p, string p_2, string p_3, string p_4, string p_5, string p_6, string p_7, string p_8)
        {
            this.NroDocumento = p;
            this.TipoDocumento = p_2;
            this.Apellido = p_3;
            this.Nombres = p_4;
            this.DescripcionPuesto = p_5;
            this.EstadoPostulacion = p_6;
            this.Observaciones = p_7;
            this.Acta = p_8;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuscadorConcursar
{
    public class ActaPublicada
    {
        public int comite;
        public int perfil;
        public int acta;
        public string descripcion;
        public DateTime fecha;
        public string link;

        public ActaPublicada(int p, int p_2, int p_3, string p_4, DateTime p_5, string p_6)
        {
            this.comite = p;
            this.perfil = p_2;
            this.acta = p_3;
            this.descripcion = p_4;
            this.fecha = p_5;
            this.link = p_6;
        }
    }
}

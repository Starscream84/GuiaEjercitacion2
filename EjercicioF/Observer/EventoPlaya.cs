using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF.Observer
{
    public class EventoPlaya
    {
        public TipoEvento Tipo { get; }

        public string Patente { get; }

        public decimal Importe { get; }
        public int LugaresLibres { get; }

        public EventoPlaya(TipoEvento tipo, string patente, decimal importe, int lugaresLibres)
        {
            Tipo = tipo;
            Patente = patente;
            Importe = importe;
            LugaresLibres = lugaresLibres;
        }
    }
}

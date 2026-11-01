using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF.Observer
{
    public class CajaObserver : IPlayaObserver
    {
        public decimal Total { get; private set; }

        public void Actualizar(EventoPlaya evento)
        {
            if (evento.Tipo != TipoEvento.Egreso) return;

            Total += evento.Importe;
            Console.WriteLine($"[Caja] Cobro {evento.Patente}: {evento.Importe:N0} | Total: {Total:N0}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF.Observer
{
    public class PantallaLugares : IPlayaObserver
    {
        public void Actualizar(EventoPlaya evento)
        {
            Console.WriteLine($"[Pantalla] Lugares libres: {evento.LugaresLibres}");
        }
    }
}

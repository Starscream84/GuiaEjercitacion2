using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF.Observer
{
    public class AlertaOcupacionObserver : IPlayaObserver
    {
        private readonly int _umbral;

        public AlertaOcupacionObserver(int umbral = 1) => _umbral = umbral;

        public void Actualizar(EventoPlaya evento)
        {
            if (evento.LugaresLibres == 0)
                Console.WriteLine("[Alerta] ¡Playa llena!");
            else if (evento.LugaresLibres <= _umbral)
                Console.WriteLine($"[Alerta] Quedan solo {evento.LugaresLibres} lugares.");
        }
    }
}

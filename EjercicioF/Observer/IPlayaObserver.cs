using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF.Observer
{
    public interface IPlayaObserver
    {
        void Actualizar(EventoPlaya evento);
    }
}

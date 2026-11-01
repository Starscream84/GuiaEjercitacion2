using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiaEjercitacion2.EjercicioF.Singleton;

namespace GuiaEjercitacion2.EjercicioF.Observer
{
    public class BitacoraObserver : IPlayaObserver
    {
        public void Actualizar(EventoPlaya evento)
        {
            string texto = evento.Tipo == TipoEvento.Ingreso
                ? $"Ingreso"
                : $"Egreso";

            Bitacora.Instancia.Registrar(texto);
        }

    }
}

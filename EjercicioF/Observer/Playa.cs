using GuiaEjercitacion2.EjercicioF.Factory;
using GuiaEjercitacion2.EjercicioF.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF.Observer
{
    public class Playa
    {
        public int _capacidad;
        private readonly Dictionary<string, ITarifa> _vehiculos = new Dictionary<string, ITarifa>();
        private readonly List<IPlayaObserver> _observadores = new List<IPlayaObserver>();

        public Playa(int capacidad)
        {
            if (capacidad <= 0)
                throw new ArgumentException("La capacidad debe ser mayor a 0.");
            _capacidad = capacidad;
        }

        private int LugaresLibres => _capacidad - _vehiculos.Count;
        public void Suscribir(IPlayaObserver o) => _observadores.Add(o);
        public void Desuscribir(IPlayaObserver o) => _observadores.Remove(o);

        private void Notificar(EventoPlaya evento)
        {
            foreach (var o in _observadores.ToList())
                o.Actualizar(evento);
        }

        public void Ingresar(string patente, string codigoTarifa)
        {
            if (string.IsNullOrWhiteSpace(patente))
                throw new InvalidOperationException("La patente no puede estar vacia.");

            patente = patente.Trim().ToUpper();

            if (_vehiculos.ContainsKey(patente))
                throw new InvalidOperationException($"La patente {patente} ya esta en la playa.");

            if (_vehiculos.Count >= _capacidad)
                throw new InvalidOperationException("La playa esta llena.");

            ITarifa tarifa = TarifaFactory.Crear(codigoTarifa);
            _vehiculos.Add(patente, tarifa);

            Notificar(new EventoPlaya(TipoEvento.Ingreso, patente, 0, LugaresLibres));
        }

        public decimal Egresar(string patente, int minutos)
        {
            if (string.IsNullOrWhiteSpace(patente))
                throw new InvalidOperationException("La patente no puede estar vacia.");

            patente = patente.Trim().ToUpper();

            if (!_vehiculos.TryGetValue(patente, out ITarifa tarifa))
                throw new InvalidOperationException($"La patente {patente} ya esta en la playa.");

            decimal importe = tarifa.Calcular(minutos);
            _vehiculos.Remove(patente);

            Notificar(new EventoPlaya(TipoEvento.Egreso, patente, importe, LugaresLibres));
            return importe;
        }
    }
}

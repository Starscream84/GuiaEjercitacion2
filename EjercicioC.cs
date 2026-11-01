using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EjercicioC1
{
    public interface IAlarmaObserver
    {
        void Actualizar(Alarma alarma);
    }
    public class Alarma
    {
        private readonly List<IAlarmaObserver> _observadores = new List<IAlarmaObserver>();
        public void Suscribir(IAlarmaObserver o) => _observadores.Add(o);
        public void Desuscribir(IAlarmaObserver o) => _observadores.Remove(o);
        public void Sonar()
        {
            /*
            Console.WriteLine("¡Riiiing!");
            foreach (var o in _observadores) // ← algo está mal acá
                o.Actualizar(this);
            */

            // Solución
            Console.WriteLine("¡Riiiing!");
            foreach (var o in _observadores.ToList())
                o.Actualizar(this);
        }
    }
    public class AvisoUnico : IAlarmaObserver
    {
        public void Actualizar(Alarma alarma)
        {
            Console.WriteLine("Me avisaron una vez y me doy de baja");
            alarma.Desuscribir(this);
        }
    }
    public class Luz : IAlarmaObserver
    {
        public void Actualizar(Alarma alarma) => Console.WriteLine("Luz encendida");

    }

    // ¿Cuál es el error y de qué tipo es?: Error de ejecución.
    // ¿Por qué ocurre?: Porque el foreach esta recorriendo la lista original, si se modifica mientras se esta recorriendo se rompe.
}


namespace EjercicioC2
{
    public interface IEnvioStrategy
    {
        decimal Calcular(decimal pesoKg);
    }

    public class EnvioMoto : IEnvioStrategy
    {
        public decimal Calcular(decimal pesoKg) => 1500 + pesoKg * 100;
    }

    public class EnvioCamion : IEnvioStrategy
    {
        public decimal Calcular(decimal pesoKg) => 8000 + pesoKg * 40;
    }

    public class EnvioEstandar : IEnvioStrategy
    {
        public decimal Calcular(decimal pesoKg) => 3000 + pesoKg * 70;
    }

    public class CalculadoraEnvio
    {
        private readonly IEnvioStrategy _envio;

        public CalculadoraEnvio(IEnvioStrategy envio)
        {
            _envio = envio;
        }

        public decimal Calcular(decimal pesoKg) => _envio.Calcular(pesoKg);
    }

    /*
    public class EnvioStrategy : IEnvioStrategy
    {
        private readonly string _tipo;
        public EnvioStrategy(string tipo) => _tipo = tipo;
        public decimal Calcular(decimal pesoKg)
        {
            if (_tipo == "Moto") return 1500 + pesoKg * 100; // ← ¿esto es Strategy?
            if (_tipo == "Camion") return 8000 + pesoKg * 40;
            return 3000 + pesoKg * 70;
        }
    }
    */

    // ¿Cuál es el error y de qué tipo es?: Es un error de diseño, no implementa el patron Strategy. 
    // ¿Qué pasa cuando llega un tipo nuevo, por ejemplo "Bicicleta"?: En la version corregida solo se agrega una nueva clase EnvioBicicleta
    // que implemente IEnvioStrategy.
    // ¿Cómo se corrige? (escribí las clases): Agregando las clases EnvioMoto, EnvioCamion y EnvioEstandar que implementan IEnvioStrategy.
}


namespace EjercicioC3
{

    public interface INotificador
    {
        void Enviar(string destino, string mensaje);
    }
    public class NotificadorMail : INotificador
    {
        public void Enviar(string destino, string mensaje) => Console.WriteLine($"Mail: {destino} - Mensaje: {mensaje}");
    }

    public class NotificadorSms : INotificador {
        public void Enviar(string destino, string mensaje) => Console.WriteLine($"SMS: {destino} - Mensaje: {mensaje}");
    }
    public static class NotificadorFactory
    {
        public static INotificador Crear(string canal)
        {
            if (canal == "MAIL") return new NotificadorMail();
            if (canal == "SMS") return new NotificadorSms();

            throw new ArgumentException("Canal desconocido, use MAIL o SMS");
        } // ← algo está mal acá
    }
    
    // ¿Cuál es el error y de qué tipo es?: NotificadorMail y NotificadorSMS no implementan la interfaz INotificador, es un error de compilación. Tiene dos if pero no comtempla excepciones.
    // ¿Cómo se corrige?: Lanzando una excepcion con un mensaje.
    // ¿Por qué conviene lanzar una excepción con un mensaje claro y no devolver null?: Porque si devuelve null, no nos enteramos del error.
}



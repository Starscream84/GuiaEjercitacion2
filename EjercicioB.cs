using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioB1
{
        public class Contador
        {
            private static Contador _instancia;
            private int _valor = 0;
            private Contador() { Console.WriteLine("Creando contador"); }
            public static Contador Instancia
            {
                get
                {
                    if (_instancia == null)
                        _instancia = new Contador();
                    return _instancia;
                }
            }
            public int Siguiente()
            {
                _valor++;
                return _valor;
            }

        }

        // ============================================
        // SECCIÓN B — Ejercicio 1
        // Imprime: Creando contador, 1, 2, 3 y True (Demuestra que Contador.Instancia siempre devuelve el mismo objeto)
        // ¡Cuantas veces aparece creando contador y porque?: Aparece una sola vez. Contador Instancia es static, se guarda en un solo lugar. Siguiente trabaja con _valor,
        // que es un dato.
        // ¿Porque b.Siguiente() no devuelve 1?: Porque Siguiente() le suma _valor a cada _valor retornado. 
        // ============================================
}

namespace EjercicioB2
{
    public interface IPropina
    {
        string Nombre { get; }
        decimal Calcular(decimal total);
    }
    public class SinPropina : IPropina
    {
        public string Nombre => "Sin propina";
        public decimal Calcular(decimal total) => 0;
    }
    public class Propina10 : IPropina
    {
        public string Nombre => "10%";
        public decimal Calcular(decimal total) => total * 0.10m;
    }
    public class PropinaFija : IPropina
    {
        private readonly decimal _monto;
        public PropinaFija(decimal monto) => _monto = monto;
        public string Nombre => "Fija";
        public decimal Calcular(decimal total) => _monto;
    }
    public class Cuenta
    {
        private IPropina _propina;
        public Cuenta(IPropina propina) => _propina = propina;
        public void CambiarPropina(IPropina propina) => _propina = propina;
        public void Mostrar(decimal total)
        {
            decimal final = total + _propina.Calcular(total);
            Console.WriteLine($"{_propina.Nombre}: {final:0}");
        }
    }


    // ============================================
    // SECCIÓN B — Ejercicio 2
    //¿Qué imprime?: Sin propina: 20000, 10%: 22000 y Fija: 215000
    //En este código, ¿quién es el contexto y quiénes son las estrategias?: Cuenta es el contexto y los diferentes tipos de propinas las estrategias.
    //¿Qué hubo que modificar de Cuenta para poder usar PropinaFija? ¿Qué principio se cumple?: Nada, Cuenta no se modifica. Cada clase Propina
    // implementa Ipropina. Se cumple el principio Open/Close.
    // ============================================
}

namespace EjercicioB3
{
    public interface IObservador
    {
        void Actualizar(string video);
    }
    public class Canal
    {
        private readonly List<IObservador> _suscriptores = new List<IObservador>();
        public void Suscribir(IObservador o) => _suscriptores.Add(o);
        public void Desuscribir(IObservador o) => _suscriptores.Remove(o);
        public void Publicar(string video)
        {
            Console.WriteLine($"Nuevo video: {video}");
            foreach (var s in _suscriptores.ToList())
                s.Actualizar(video);
        }
    }
    public class Fan : IObservador
    {
        private readonly string _nombre;
        public Fan(string nombre) => _nombre = nombre;
        public void Actualizar(string video) => Console.WriteLine($" {_nombre} mira {video}");
    }
    public class Estadisticas : IObservador
    {
        private int _avisos = 0;
        public void Actualizar(string video)
        {
            _avisos++;
            Console.WriteLine($" Avisos registrados: {_avisos}");

        }
    }

    // ============================================
    // SECCIÓN B — Ejercicio 3
    // ¿Qué imprime?:
    // Nuevo video: Patrones en C#
    // Lu mira Patrones en C#
    // Tomi mira Patrones en C#
    // Avisos registrados: 1
    // Nuevo video: Observer en WinForms
    // Tomi mira Observer en WinForms
    // Avisos registrados: 2
    // ¿Por qué Lu no aparece en la segunda publicación?: Porque se desuscribio. 
    // ¿Canal conoce la clase Fan? ¿Cómo te das cuenta mirando el código?: Canal no conoce a Fan, te das cuenta simplemente porque Fan no
    // aparece en ninguna parte dentro de Canal.
    // ============================================
}


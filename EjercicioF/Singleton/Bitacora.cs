using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF.Singleton
{
    public class Bitacora
    {
        private static Bitacora _instancia;

        private readonly List<string> _entradas = new List<string>();
        private int _numeroOperacion = 0;
        private Bitacora() { }

        public static Bitacora Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new Bitacora();
                return _instancia;
            }
        }

        public void Registrar(string mensaje)
        {
            _numeroOperacion++;
            string linea = $"#{_numeroOperacion:000} [{DateTime.Now:dd/MM HH:mm:ss}] {mensaje}";
            _entradas.Add(linea);
        }

        public List<string> MostrarTodo()
        {
            return new List<string>(_entradas);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiaEjercitacion2.EjercicioF.Strategy;

namespace GuiaEjercitacion2.EjercicioF.Factory
{
    public static class TarifaFactory
    {
        public static ITarifa Crear(string codigo)
        {
            switch(codigo)
            {
                case "HORA": return new TarifaHora();
                case "ESTADIA": return new TarifaEstadia();
                case "NOCHE": return new TarifaNocturna();
                default: throw new ArgumentException(
                    $"Tarifa desconocida: '{codigo}'.");
            }
        }

        public static List<string> CodigosDisponibles()
            => new List<string> { "Hora", "Estadia", "Nocturna" };

    }
}

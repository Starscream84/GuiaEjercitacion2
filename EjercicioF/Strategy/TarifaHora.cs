using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF.Strategy
{
    public class TarifaHora : ITarifa
    {
        public string Nombre => "HORA";

        public decimal Calcular(int minutos)
        {
            return Math.Ceiling(minutos / 60m) * 1200;
        }
    }
}

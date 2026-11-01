using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF.Strategy
{
    public class TarifaNocturna : ITarifa
    {
        public string Nombre => "NOCHE";

        public decimal Calcular(int minutos)
        {
            return 4500;
        }
    }
}

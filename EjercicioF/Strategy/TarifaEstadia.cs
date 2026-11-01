using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiaEjercitacion2.EjercicioF.Strategy
{
    public class TarifaEstadia : ITarifa
    {
        public string Nombre => "ESTADIA";

        public decimal Calcular(int minutos)
        {
            const int limite = 12 * 60;
            if (minutos <= limite)
                return 6000;

            int extra = minutos - limite;
            return 6000 + Math.Ceiling(extra / 60m) * 1200;
        }
    }
}

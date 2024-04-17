using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivarium.Calculation
{

    /// <summary>
    /// Используется для вычислений 
    /// </summary>
    internal static class Calculator //надо ли
    {
       public static double? GetAverage(IEnumerable<int> values)
        {
            int count = values.Count();
            if (count == 0)
                return null;
            double sum = 0; 
            foreach (var value in values)
            {
                sum += value;
            }

            return sum / count;
        }
    }
}

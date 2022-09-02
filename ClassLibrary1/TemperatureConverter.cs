using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversion
{
    /// <summary>
    /// Implementation of TemperatureConverter class.
    /// 
    /// Provides conversion between celsius and farenheit.
    /// </summary>
    public class TemperatureConverter : UnitConverterBase
    {
        //Allowed units.
        private readonly UnitGroup[] knownUnits = new UnitGroup[]
        {
            new UnitGroup(new string[] { "celsius", "cels", "celzius" }, 1D),
            new UnitGroup(new string[] { "farenheit", "farenheits" }, 1D)
        };

        public TemperatureConverter()
        {
            Setup(knownUnits, true);
        }

        /// <summary>
        /// Final work with converted value to be printed. 
        /// </summary>
        /// <param name="value">Value after base conversion.</param>
        /// <param name="to">Unit to convert into.</param>
        /// <returns>Final converted value with unit.</returns>
        protected override string DoConvert(double value, string to)
        {
            double final = to.Contains("farenheit") ? (value * 1.8) + 32 : (value - 32) * 5D / 9D;
            return Math.Round(final, 5) + " " + to;
        }
    }
}

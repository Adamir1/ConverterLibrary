using System;
using System.Collections.Generic;
using System.Linq;

namespace Conversion
{
    /// <summary>
    /// Helper class for Unit conversion.
    /// </summary>
    internal static class UnitHelper
    {
        // Dictionary of all SI prefixes with their relative values.
        private static readonly Dictionary<string, double> prefs = new() {
            {"yotta", Math.Pow(10, 24)},
            {"yota", Math.Pow(10, 24)},
            {"zetta", Math.Pow(10, 21)},
            {"zeta", Math.Pow(10, 21)},
            {"exa", Math.Pow(10, 18)},
            {"peta", Math.Pow(10, 15)},
            {"tera", Math.Pow(10, 12)},
            {"giga", Math.Pow(10, 9)},
            {"mega", 1000000},
            {"kilo", 1000},
            {"hecto", 100},
            {"deca", 10},
            {"deci", 0.1},
            {"centi", 0.01},
            {"milli", 0.001},
            {"mili", 0.001},
            {"micro", Math.Pow(10, -6)},
            {"nano", Math.Pow(10, -9)},
            {"pico", Math.Pow(10, -12)},
            {"femto", Math.Pow(10, -15)},
            {"atto", Math.Pow(10, -18)},
            {"ato", Math.Pow(10, -18)},
            {"zepto", Math.Pow(10, -21)},
            {"yocto", Math.Pow(10, -24)}
        };

        /// <summary>
        /// Getter for relative value of prefix.
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns>Relative value of prefix.</returns>
        private static double GetMultiplier(string prefix)
        {
            return prefs.GetValueOrDefault(prefix);
        }

        /// <summary>
        /// Getter for prefix.
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>Name of prifix if found, null otherwise.</returns>
        internal static string GetPrefix(string unit)
        {
            return prefs.Keys.FirstOrDefault(x => unit.Contains(x));
        }

        /// <summary>
        /// Calculates relative value of combined prefixes.
        /// </summary>
        /// <param name="left">First prefix.</param>
        /// <param name="right">Second prefix.</param>
        /// <returns>Relative value of two prefixes.</returns>
        internal static double SettlePrefixMath(string left, string right)
        {
            double val = 1D;

            //Settles first prefix if exists.
            string prefixLeft = GetPrefix(left);
            if (prefixLeft != null)
                val *= GetMultiplier(prefixLeft);

            //Settle second prefix if exists.
            string prefixRight = GetPrefix(right);
            if (prefixRight != null)
                val /= GetMultiplier(prefixRight);

            return val;
        }
    }
}

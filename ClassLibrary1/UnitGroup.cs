using System;

namespace Conversion
{
    /// <summary>
    /// Class for varients of the same unit.
    /// </summary>
    public class UnitGroup
    {
        private readonly string[] variants;
        private readonly double value;

        /// <summary>
        /// Constructor for UnitGroup with normilized value.
        /// </summary>
        /// <param name="variants">Array of string varients of unit.</param>
        /// <param name="value">Normalized value.</param>
        internal UnitGroup(string[] variants, double value)
        {
            this.variants = variants;
            this.value = value;
        }

        /// <summary>
        /// Constructor for UnitGroup with method to calculate normalized value.
        /// </summary>
        /// <param name="variants">Array of string varients of unit.</param>
        /// <param name="func">Method to calculate normalized value.</param>
        internal UnitGroup(string[] variants, Func<double> func)
        {
            this.variants = variants;
            value = func();
        }

        /// <summary>
        /// Checks if unit is varient of allowed units.
        /// </summary>
        /// <param name="unit">Unit to be checked.</param>
        /// <returns>True if unit is varient of allowed units.</returns>
        public bool IsVariant(string unit)
        {
            //Deletes prefix if present
            var prefix = UnitHelper.GetPrefix(unit);
            string noPrefixUnit = prefix != null ? unit.Replace(prefix, "") : unit;

            foreach (string variant in variants)
            {
                if (noPrefixUnit.Equals(variant))
                    return true;
            }
            return false;
        }

        public double GetValue()
        {
            return value;
        }

        public string GetName()
        {
            return variants[0];
        }
    }
}

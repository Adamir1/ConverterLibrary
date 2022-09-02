using System;
using System.Collections.Generic;
using System.Linq;

namespace Conversion
{
    /// <summary>
    /// Base class for Unit converters.
    /// </summary>
    public abstract class UnitConverterBase : IUnitConverter
    {
        private UnitGroup[] units;
        private double value;
        private bool allowNeg = false;

        /// <summary>
        /// Basic setup for UnitConverter instance.
        /// </summary>
        /// <param name="knownUnits"> Array of allowed units to convert.</param>
        protected void Setup(UnitGroup[] knownUnits)
        {
            units = knownUnits;
        }

        /// <summary>
        /// Basic setup for UnitConverter instance.
        /// </summary>
        /// <param name="knownUnits">Array of allowed units to convert.</param>
        /// <param name="allowNeg">if true, negative values are allowed to convert.</param>
        protected void Setup(UnitGroup[] knownUnits, bool allowNeg)
        {
            units = knownUnits;
            this.allowNeg = allowNeg;
        }


        /// <summary>
        /// Convert units according to setup.
        /// </summary>
        /// <param name="from">Value and unit to convert.</param>
        /// <param name="to">Unit convert into.</param>
        /// <returns></returns>
        public string Convert(string from, string to)
        {
            if (from == null || to == null)
                throw new ArgumentException("null is not a valid unit format");

            Dictionary<string, double> fromParams = ValidateAndParseParams(from.ToLower(), to.ToLower());
            double finalVal = value * UnitHelper.SettlePrefixMath(from, to);
            finalVal *= fromParams["from"];
            finalVal /= fromParams["to"];

            return DoConvert(finalVal, to.ToLower());
        }

        /// <summary>
        /// Validates results and returns parsed values.
        /// </summary>
        /// <param name="from">Value and unit to convert.</param>
        /// <param name="to">Unit convert into.</param>
        /// <returns>Parsed parameter values.</returns>
        internal Dictionary<string, double> ValidateAndParseParams(string from, string to)
        {
            if (from == null || to == null)
                throw new ArgumentException("null is not a valid 'units from' format");

            string[] fromUnit = from.Split(" ");
            if (fromUnit.Length != 2)
                throw new ArgumentException(String.Format("{0} is not a valid 'units from' format", from), nameof(from));

            if (!double.TryParse(fromUnit[0], out value))
                throw new ArgumentException(String.Format("{0} is not a valid number format for units", fromUnit[0]), nameof(from));

            if (!allowNeg && value < 0)
                throw new ArgumentException(String.Format("{0} cannot be negative value", value), nameof(from));

            UnitGroup unitGroupFrom = units.FirstOrDefault(x => x.IsVariant(fromUnit[1]));
            if (unitGroupFrom == null)
                throw new ArgumentException(String.Format("{0} is not a valid unit", fromUnit[1]), nameof(from));

            UnitGroup unitGroupTo = units.FirstOrDefault(x => x.IsVariant(to));
            if (unitGroupTo == null)
                throw new ArgumentException(String.Format("{0} is not a valid unit", to), nameof(to));

            if (unitGroupTo.Equals(unitGroupFrom) && UnitHelper.SettlePrefixMath(from, to) == 1)
                throw new ArgumentException("Units have to be different");

            return new Dictionary<string, double>()
            { 
                { "from", unitGroupFrom.GetValue() }, 
                { "to", unitGroupTo.GetValue() } 
            };
        }

        /// <summary>
        /// Default implementation for final works on printed value.
        /// 
        /// Ovveride if needed special logic for converting units.
        /// </summary>
        /// <param name="value">Value after base conversion.</param>
        /// <param name="to">Unit convert into.</param>
        /// <returns></returns>
        protected virtual string DoConvert(double value, string to)
        {
            return Math.Round(value, 5) + " " + to;
        }

        /// <summary>
        /// Implementation of IUnitConverter DoConvert.
        /// </summary>
        /// <param name="value">Value after base conversion.</param>
        /// <param name="to">Unit convert into.</param>
        /// <returns></returns>
        string IUnitConverter.DoConvert(double value, string to)
        {
            return DoConvert(value, to);
        }
    }
}

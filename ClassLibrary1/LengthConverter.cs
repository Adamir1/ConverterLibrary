
namespace Conversion
{
    /// <summary>
    /// Implementation od LengthConverter.
    /// 
    /// Provides conversion between units of length (metric, feet, inch).
    /// </summary>
    public class LengthConverter : UnitConverterBase
    {
        //Allowed units.
        private static readonly UnitGroup[] knownUnits = new UnitGroup[]
        {
            new UnitGroup(new string[] { "meter", "meters"}, 1D),
            new UnitGroup(new string[] { "feet", "feets", "foot"}, 0.3048D),
            new UnitGroup(new string[] { "inches", "inch"}, 0.0254D)
        };

        public LengthConverter()
        {
            Setup(knownUnits);
        }
    }
}

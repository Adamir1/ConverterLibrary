
namespace Conversion
{
    /// <summary>
    /// Implementation of DataConverter.
    /// 
    /// Provides conversion between bits and bytes.
    /// </summary>
    public class DataConverter : UnitConverterBase
    {
        //Allowed units.
        private static readonly UnitGroup[] knownUnits = new UnitGroup[]
        {
            new UnitGroup(new string[] { "bit", "bits"}, 1D),
            new UnitGroup(new string[] { "byte", "bytes" }, 8D)
        };

        public DataConverter()
        {
            Setup(knownUnits);
        }

    }
}


namespace Conversion
{
    /// <summary>
    /// Interface for unit convertion.
    /// </summary>
    internal interface IUnitConverter
    {
        public string Convert(string from, string to);
        protected string DoConvert(double value, string to);
    }
}

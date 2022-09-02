using Conversion;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DataConverter dataConverter = new DataConverter();
            string val = dataConverter.Convert("256 bits", "bytes");
            LengthConverter lengthConverter = new LengthConverter();
            string val1 = lengthConverter.Convert("1234 centimeters", "foot");
            TemperatureConverter temperatureConverter = new TemperatureConverter();
            string val2 = temperatureConverter.Convert("", "");
        }
    }
}

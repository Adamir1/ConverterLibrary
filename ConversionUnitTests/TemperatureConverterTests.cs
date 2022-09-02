using System;
using Xunit;
using Conversion;

namespace ConversionUnitTests
{
    /// <summary>
    /// Unit test class for TemperatureConverter
    /// </summary>
    public class TemperatureConverterTests
    {
        private readonly TemperatureConverter temperatureConverter = new();

        [Fact]
        public void CeslsiusToFarenheitTest()
        {
            Assert.Equal("50 farenheit", temperatureConverter.Convert("10 celsius", "farenheit"));
            Assert.Equal("32 farenheit", temperatureConverter.Convert("0 celzius", "farenheit"));
            Assert.Equal("-22 farenheit", temperatureConverter.Convert("-30 celzius", "farenheit"));
        }

        [Fact]
        public void FarenheitToCeslsiusTest()
        {
            Assert.Equal("0 celsius", temperatureConverter.Convert("32 farenheit", "celsius"));
            Assert.Equal("-17.77778 celzius", temperatureConverter.Convert("0 farenheit", "celzius"));
            Assert.Equal("-30 celsius", temperatureConverter.Convert("-22 farenheit", "celsius"));
        }

        [Fact]
        public void NegativeTest()
        {
            Assert.Throws<ArgumentException>(() => temperatureConverter.Convert("", ""));
            Assert.Throws<ArgumentException>(() => temperatureConverter.Convert("farenheit", ""));
            Assert.Throws<ArgumentException>(() => temperatureConverter.Convert("", "celsius"));
            Assert.Throws<ArgumentException>(() => temperatureConverter.Convert("celsius", "farenheit"));
            Assert.Throws<ArgumentException>(() => temperatureConverter.Convert("1 celsius", ""));
            Assert.Throws<ArgumentException>(() => temperatureConverter.Convert("1 11", "celsius"));
            Assert.Throws<ArgumentException>(() => temperatureConverter.Convert(null, null));
            Assert.Throws<ArgumentException>(() => temperatureConverter.Convert(null, ""));
            Assert.Throws<ArgumentException>(() => temperatureConverter.Convert(null, ""));
            Assert.Throws<ArgumentException>(() => temperatureConverter.Convert("-12", "celsius"));
            Assert.Throws<ArgumentException>(() => temperatureConverter.Convert("-10 celzius", "celsius"));
            Assert.Throws<ArgumentException>(() => temperatureConverter.Convert("-10 ccelzius", "farenheit"));
            Assert.Throws<ArgumentException>(() => temperatureConverter.Convert("-10 celzius", "ffarenheit"));
        }
    }
}

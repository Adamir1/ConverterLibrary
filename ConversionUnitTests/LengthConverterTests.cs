using System;
using Xunit;
using Conversion;

namespace ConversionUnitTests
{
    /// <summary>
    /// Unit test class for LengthConverter.
    /// </summary>
    public class LengthConverterTests
    {
        private readonly LengthConverter lengthConverter = new();

        [Fact]
        public void MetersToFeetTest()
        {
            Assert.Equal("3.28084 feet", lengthConverter.Convert("1 Meters", "feet"));
            Assert.Equal("0 foot", lengthConverter.Convert("0 meteR", "foOt"));
            Assert.Equal("6561.67979 foot", lengthConverter.Convert("2 kilometeR", "foOt"));
        }

        [Fact]
        public void MetersToInchesTest()
        {
            Assert.Equal("39.37008 inches", lengthConverter.Convert("1 Meters", "Inches"));
            Assert.Equal("0 inch", lengthConverter.Convert("0 meteR", "inch"));
            Assert.Equal("393.70079 inch", lengthConverter.Convert("10000 millimeteR", "inch"));
        }

        [Fact]
        public void InchesToMeters()
        {
            Assert.Equal("0.0508 meters", lengthConverter.Convert("2 iNch", "meters"));
            Assert.Equal("0 meter", lengthConverter.Convert("0 incheS", "meter"));
            Assert.Equal("5.08 centimeter", lengthConverter.Convert("2 incheS", "centimeter"));
        }

        [Fact]
        public void InchesToFeetTest()
        {
            Assert.Equal("0.08333 feet", lengthConverter.Convert("1 inch", "feet"));
            Assert.Equal("0 feet", lengthConverter.Convert("0 inchEs", "feet"));
        }

        [Fact]
        public void MetersToMetersTest()
        {
            Assert.Equal("1 meter", lengthConverter.Convert("100 centiMeters", "meter"));
            Assert.Equal("30 hectometer", lengthConverter.Convert("3 kilometeR", "hectometer"));
        }

        [Fact]
        public void NegativeTest()
        {
            Assert.Throws<ArgumentException>(() => lengthConverter.Convert("", ""));
            Assert.Throws<ArgumentException>(() => lengthConverter.Convert("meter", ""));
            Assert.Throws<ArgumentException>(() => lengthConverter.Convert("", "feet"));
            Assert.Throws<ArgumentException>(() => lengthConverter.Convert("feet", "meter"));
            Assert.Throws<ArgumentException>(() => lengthConverter.Convert("1 inch", ""));
            Assert.Throws<ArgumentException>(() => lengthConverter.Convert("1 11", "feet"));
            Assert.Throws<ArgumentException>(() => lengthConverter.Convert(null, null));
            Assert.Throws<ArgumentException>(() => lengthConverter.Convert(null, ""));
            Assert.Throws<ArgumentException>(() => lengthConverter.Convert(null, ""));
            Assert.Throws<ArgumentException>(() => lengthConverter.Convert("-12", "feet"));
            Assert.Throws<ArgumentException>(() => lengthConverter.Convert("0 feet", "Feets"));
            Assert.Throws<ArgumentException>(() => lengthConverter.Convert("0 ffeet", "inch"));
            Assert.Throws<ArgumentException>(() => lengthConverter.Convert("0 feet", "iinch"));
        }
    }
}


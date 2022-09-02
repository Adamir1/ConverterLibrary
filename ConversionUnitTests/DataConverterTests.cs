using System;
using Xunit;
using Conversion;

namespace ConversionUnitTests
{
    /// <summary>
    /// Unit test class for DataConverter.
    /// </summary>
    public class DataConverterTests
    {
        private readonly DataConverter dataConverter = new();

        [Fact]
        public void BitsToBytesTest()
        {
            Assert.Equal("1 bytes", dataConverter.Convert("8 bits", "byTes"));
            Assert.Equal("0 bytes", dataConverter.Convert("0 bitS", "bytes"));
        }

        [Fact]
        public void BytesToBitsTest()
        {
            Assert.Equal("8 bit", dataConverter.Convert("1 Bytes", "bit"));
            Assert.Equal("0 bits", dataConverter.Convert("0 byte", "bIts"));
        }

        [Fact]
        public void NegativeTests()
        {
            Assert.Throws<ArgumentException>(() => dataConverter.Convert("", ""));
            Assert.Throws<ArgumentException>(() => dataConverter.Convert("bit", ""));
            Assert.Throws<ArgumentException>(() => dataConverter.Convert("", "bytes"));
            Assert.Throws<ArgumentException>(() => dataConverter.Convert("bit", "bytes"));
            Assert.Throws<ArgumentException>(() => dataConverter.Convert("1 bit", ""));
            Assert.Throws<ArgumentException>(() => dataConverter.Convert("1 11", "bit"));
            Assert.Throws<ArgumentException>(() => dataConverter.Convert(null, null));
            Assert.Throws<ArgumentException>(() => dataConverter.Convert(null, ""));
            Assert.Throws<ArgumentException>(() => dataConverter.Convert(null, ""));
            Assert.Throws<ArgumentException>(() => dataConverter.Convert("-12", "byte"));
            Assert.Throws<ArgumentException>(() => dataConverter.Convert("0 byte", "Bytes"));
            Assert.Throws<ArgumentException>(() => dataConverter.Convert("0 bbyte", "bit"));
            Assert.Throws<ArgumentException>(() => dataConverter.Convert("0 byte", "bbit"));
        }
    }
}

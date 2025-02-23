using System;
using Xunit;
using RomanNumeralsLib.Interfaces;
using RomanNumeralsLib.Services;

namespace RomanNumeralsLib.Tests
{
    public class RomanNumeralConverterTests
    {
        private readonly IRomanNumeralConverter _converter;

        public RomanNumeralConverterTests()
        {
            _converter = new RomanNumeralFacade();
        }

        [Theory]
        [InlineData("I", 1)]
        [InlineData("II", 2)]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("V", 5)]
        [InlineData("VI", 6)]
        [InlineData("IX", 9)]
        [InlineData("X", 10)]
        [InlineData("XL", 40)]
        [InlineData("L", 50)]
        [InlineData("XC", 90)]
        [InlineData("C", 100)]
        [InlineData("CD", 400)]
        [InlineData("D", 500)]
        [InlineData("CM", 900)]
        [InlineData("M", 1000)]
        [InlineData("MCMXCIX", 1999)]
        [InlineData("MMCDXLIV", 2444)]
        public void ToDecimal_ValidRoman_ReturnsExpectedValue(string roman, int expected)
        {
            int result = _converter.ToDecimal(roman);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(6, "VI")]
        [InlineData(9, "IX")]
        [InlineData(10, "X")]
        [InlineData(40, "XL")]
        [InlineData(50, "L")]
        [InlineData(90, "XC")]
        [InlineData(100, "C")]
        [InlineData(400, "CD")]
        [InlineData(500, "D")]
        [InlineData(900, "CM")]
        [InlineData(1000, "M")]
        [InlineData(1999, "MCMXCIX")]
        [InlineData(2444, "MMCDXLIV")]
        public void ToRoman_ValidNumber_ReturnsExpectedRoman(int number, string expectedRoman)
        {
            string result = _converter.ToRoman(number);
            Assert.Equal(expectedRoman, result);
        }

        [Theory]
        [InlineData("IIII")]
        [InlineData("VX")]
        [InlineData("ABC")]
        [InlineData("")]
        public void ToDecimal_InvalidRoman_ThrowsException(string roman)
        {
            Assert.Throws<ArgumentException>(() => _converter.ToDecimal(roman));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(3000)]
        [InlineData(-1)]
        public void ToRoman_InvalidNumber_ThrowsException(int number)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _converter.ToRoman(number));
        }
    }
}

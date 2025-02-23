using RomanNumeralsLib.Interfaces;

namespace RomanNumeralsLib.Services
{
    /// <summary>
    /// Facade, der kombinerer de to separate services for romertal-konvertering.
    /// </summary>
    public class RomanNumeralFacade : IRomanNumeralConverter
    {
        private readonly RomanToDecimal _romanToDecimalConverter;
        private readonly DecimalToRoman _decimalToRomanConverter;

        /// <summary>
        /// Opretter en ny instans af converter-facaden, der initialiserer de to underliggende services.
        /// </summary>
        public RomanNumeralFacade()
        {
            _romanToDecimalConverter = new RomanToDecimal();
            _decimalToRomanConverter = new DecimalToRoman();
        }

        /// <inheritdoc />
        public int ToDecimal(string roman)
        {
            return _romanToDecimalConverter.Convert(roman);
        }

        /// <inheritdoc />
        public string ToRoman(int number)
        {
            return _decimalToRomanConverter.Convert(number);
        }
    }
}

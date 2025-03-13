using RomanNumeralsLib.Interfaces;

namespace RomanNumeralsLib.Services
{
    /// <summary>
    /// Facade, der kombinerer de to separate services for romertal-konvertering.
    /// </summary>
    public class RomanNumeralFacade : IRomanNumeralConverter
    {
        private readonly ToDecimal _toDecimal;
        private readonly ToRoman _toRoman;

        /// <summary>
        /// Opretter en ny instans af converter-facaden, der initialiserer de to underliggende services.
        /// </summary>
        public RomanNumeralFacade()
        {
            _toDecimal = new ToDecimal();
            _toRoman = new ToRoman();
        }

        /// <inheritdoc />
        public int ToDecimal(string roman)
        {
            return _toDecimal.Convert(roman);
        }

        /// <inheritdoc />
        public string ToRoman(int number)
        {
            return _toRoman.Convert(number);
        }
    }
}

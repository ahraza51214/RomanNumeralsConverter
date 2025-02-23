using System;
using System.Collections.Generic;
using System.Text;

namespace RomanNumeralsLib.Services
{
    /// <summary>
    /// Service, der konverterer et decimaltal til et romertal.
    /// </summary>
    public class DecimalToRoman
    {
        /// <summary>
        /// Konverterer et decimaltal til et romertal.
        /// Kaster en ArgumentOutOfRangeException, hvis tallet ikke ligger mellem 1 og 2999.
        /// </summary>
        /// <param name="number">Et decimaltal.</param>
        /// <returns>Romertalsstreng.</returns>
        public string Convert(int number)
        {
            if (number <= 0 || number >= 3000)
                throw new ArgumentOutOfRangeException(nameof(number), "Værdien skal være mellem 1 og 2999.");

            var romanNumerals = new List<(int value, string numeral)>
            {
                (1000, "M"),
                (900, "CM"),
                (500, "D"),
                (400, "CD"),
                (100, "C"),
                (90, "XC"),
                (50, "L"),
                (40, "XL"),
                (10, "X"),
                (9, "IX"),
                (5, "V"),
                (4, "IV"),
                (1, "I")
            };

            var result = new StringBuilder();
            foreach (var (value, numeral) in romanNumerals)
            {
                while (number >= value)
                {
                    result.Append(numeral);
                    number -= value;
                }
            }
            return result.ToString();
        }
    }
}

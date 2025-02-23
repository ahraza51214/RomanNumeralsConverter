using System;
using System.Collections.Generic;
using RomanNumeralsLib.Validators;

namespace RomanNumeralsLib.Services
{
    /// <summary>
    /// Service, der konverterer et romertal til et decimaltal.
    /// </summary>
    public class RomanToDecimal
    {
        // Kortlægning af romertal til decimale værdier.
        private static readonly Dictionary<char, int> RomanMap = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        /// <summary>
        /// Konverterer et romertal til et decimaltal.
        /// Kaster en ArgumentException, hvis input ikke er gyldigt.
        /// </summary>
        /// <param name="roman">Romertalsstreng.</param>
        /// <returns>Det decimale tal.</returns>
        public int Convert(string roman)
        {
            // Validerer input ved hjælp af en separat validator.
            RomanNumeralValidator.Validate(roman);

            int i = 0, result = 0;
            while (i < roman.Length)
            {
                // Hvis et mindre tal står før et større, skal det trækkes fra.
                if (i + 1 < roman.Length && RomanMap[roman[i]] < RomanMap[roman[i + 1]])
                {
                    result += RomanMap[roman[i + 1]] - RomanMap[roman[i]];
                    i += 2;
                }
                else
                {
                    result += RomanMap[roman[i]];
                    i++;
                }
            }
            return result;
        }
    }
}

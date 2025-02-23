using System;
using System.Text.RegularExpressions;

namespace RomanNumeralsLib.Validators
{
    /// <summary>
    /// Ansvarlig for at validere, at et romertal opfylder de opstillede regler.
    /// </summary>
    public static class RomanNumeralValidator
    {
        /// <summary>
        /// Validerer, at input-strengen er et korrekt romertal.
        /// Kaster en ArgumentException, hvis input er ugyldigt.
        /// </summary>
        /// <param name="roman">Romertalsstreng.</param>
        public static void Validate(string roman)
        {
            if (string.IsNullOrEmpty(roman))
                throw new ArgumentException("Input må ikke være tomt.", nameof(roman));

            // Regex, der sikrer korrekt subtraktiv notation og begrænser gentagelser.
            var regex = new Regex("^M{0,2}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$");
            if (!regex.IsMatch(roman))
                throw new ArgumentException("Ugyldigt romertal.", nameof(roman));
        }
    }
}

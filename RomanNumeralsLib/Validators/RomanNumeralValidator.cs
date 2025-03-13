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
            // Tjekker om strengen er null eller tom
            if (string.IsNullOrEmpty(roman))
                throw new ArgumentException("Input må ikke være tomt.", nameof(roman));

            // Definerer et regex-mønster for at sikre, at romertallet er korrekt formatteret.
            // Forklaring af mønsteret:
            // ^           => Start af strengen.
            // (MA|MB|B?M{0,3}) => Tusindedelen: enten 9000 (MA), 4000 (MB),eller 0-3000/5000-8000 (en valgfri 'B' efterfulgt af 0 til 3 'M').
            // (CM|CD|D?C{0,3}) => Hundrededelen: enten 900 (CM), 400 (CD), eller 0-300/500-800 (en valgfri 'D' efterfulgt af 0 til 3 'C').
            // (XC|XL|L?X{0,3}) => Tiere: enten 90 (XC), 40 (XL), eller 0-30/50-80 (en valgfri 'L' efterfulgt af 0 til 3 'X').
            // (IX|IV|V?I{0,3}) => Enere: enten 9 (IX), 4 (IV), eller 0-3/5-8 (en valgfri 'V' efterfulgt af 0 til 3 'I').
            // $           => Slutningen af strengen.
            var regex = new Regex("^A{0,1}(MA|MB|B?M{0,3})(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$");

            // Hvis inputtet ikke matcher regex-mønsteret, kastes en undtagelse.
            if (!regex.IsMatch(roman))
                throw new ArgumentException("Ugyldigt romertal.", nameof(roman));
        }
    }
}

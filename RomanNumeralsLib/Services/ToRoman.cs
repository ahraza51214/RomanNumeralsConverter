using System;
using System.Collections.Generic;
using System.Text;
using RomanNumeralsLib.Validators;

namespace RomanNumeralsLib.Services
{
    /// <summary>
    /// Service, der konverterer et decimaltal til et romertal.
    /// </summary>
    public class ToRoman
    {
        /// <summary>
        /// Konverterer et decimaltal til et romertal.
        /// Kaster en ArgumentOutOfRangeException, hvis tallet ikke ligger mellem 1 og 2999.
        /// </summary>
        /// <param name="number">Et decimaltal.</param>
        /// <returns>Romertalsstreng.</returns>
        public string Convert(int number)
        {
            // Tjekker, om inputtet er inden for det gyldige interval.
            if (number <= 0 || number >= 10000)
            throw new ArgumentOutOfRangeException(nameof(number), "Værdien skal være mellem 1 og 2999.");

            var result = new StringBuilder();
            // Gennemløb alle regler fra den højeste værdi til den laveste.
            foreach (var rule in RomanNumeralRules.Rules)
            {
                // Så længe den indtastede værdi er større end eller lig med den aktuelle værdi,
                // tilføjes den tilsvarende romertal (bogstav) til stringen.
                while (number >= rule.Value)
                {
                    // tilføjer bogstavet til stringen result
                    result.Append(rule.Roman);
                    // Og vi trækker den tilsvarende bogstavs værdi fra vores indstastede værdi.
                    number -= rule.Value;
                }
            }
            return result.ToString();
        }
    }
}

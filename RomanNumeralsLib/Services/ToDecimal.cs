using System;
using System.Collections.Generic;
using RomanNumeralsLib.Validators;

namespace RomanNumeralsLib.Services
{
    /// <summary>
    /// Service, der konverterer et romertal til et decimaltal.
    /// </summary>
    public class ToDecimal
    {
        /// <summary>
        /// Konverterer et romertal til et decimaltal.
        /// Kaster en ArgumentException, hvis input ikke er gyldigt.
        /// </summary>
        /// <param name="roman">Romertalsstreng.</param>
        /// <returns>Det decimale tal.</returns>   
        public int Convert(string roman)
        {
            // Først validerer vi, at inputtet er et korrekt romertal.
            RomanNumeralValidator.Validate(roman);

            int i = 0, 
            result = 0;
            
            // Vi kører en while-løkke, der itererer gennem hele den indtastede romertal-streng.
            // Men her benytter vi den simple metode, hvor vi itererer gennem strengen.
            while (i < roman.Length)
            {
                // Prøv at matche et to-tegns symbol først (f.eks. "CM", "IV", osv.)
                bool matchFound = false;
                foreach (var rule in RomanNumeralRules.Rules)
                {
                    if (rule.Roman.Length == 2 && i + 1 < roman.Length && roman.Substring(i, 2) == rule.Roman)
                    {
                        result += rule.Value;
                        i += 2;
                        matchFound = true;
                        break;
                    }
                }
                if (matchFound) continue;

                // Hvis intet to-tegns match blev fundet, matcher vi et enkelt tegn.
                foreach (var rule in RomanNumeralRules.Rules)
                {
                    if (rule.Roman.Length == 1 && roman[i].ToString() == rule.Roman)
                    {
                        result += rule.Value;
                        i++;
                        break;
                    }
                }
            }
            return result;
        }
    }
}
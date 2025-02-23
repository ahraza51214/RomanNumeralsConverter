using System;
using RomanNumeralsLib.Interfaces;
using RomanNumeralsLib.Services;

namespace RomanNumeralsApp
{
    /// <summary>
    /// Console-applikation med en brugervenlig menu, der lader brugeren konvertere
    /// romertal til decimaltal og decimaltal til romertal.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Initialiser converter-facaden.
            IRomanNumeralConverter converter = new RomanNumeralFacade();
            bool continueProgram = true;

            while (continueProgram)
            {
                Console.Clear();
                Console.WriteLine("Velkommen til Romertalskonverteren!");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Vælg en funktion:");
                Console.WriteLine("1. Konverter romertal til decimaltal");
                Console.WriteLine("2. Konverter decimaltal til romertal");
                Console.WriteLine("0. Afslut programmet");
                Console.Write("Indtast dit valg (0, 1 eller 2): ");

                string choice = Console.ReadLine() ?? string.Empty;

                switch (choice)
                {
                    case "1":
                        ConvertRomanToDecimal(converter);
                        break;
                    case "2":
                        ConvertDecimalToRoman(converter);
                        break;
                    case "0":
                        continueProgram = false;
                        Console.WriteLine("Programmet afsluttes...");
                        break;
                    default:
                        Console.WriteLine("Ugyldigt valg! Prøv igen.");
                        WaitForUser();
                        break;
                }
            }
        }

        /// <summary>
        /// Håndterer konvertering fra romertal til decimal med validering.
        /// </summary>
        static void ConvertRomanToDecimal(IRomanNumeralConverter converter)
        {
            while (true)
            {
                Console.Write("Indtast venligst et romertal (f.eks. MCMXCIX): ");
                string romanInput =  Console.ReadLine() ?? string.Empty;

                try
                {
                    int decimalResult = converter.ToDecimal(romanInput);
                    Console.WriteLine($"Romertallet {romanInput} svarer til {decimalResult}.");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}. Prøv igen.");
                }
            }
            WaitForUser();
        }

        /// <summary>
        /// Håndterer konvertering fra decimal til romertal med validering.
        /// </summary>
        static void ConvertDecimalToRoman(IRomanNumeralConverter converter)
        {
            while (true)
            {
                Console.Write("Indtast venligst et decimaltal (mellem 1 og 2999): ");
                string decimalInput =  Console.ReadLine() ?? string.Empty;

                try
                {
                    int number = int.Parse(decimalInput);
                    string romanResult = converter.ToRoman(number);
                    Console.WriteLine($"{number} konverteret til romertal er: {romanResult}.");
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Indtast venligst et gyldigt tal.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}. Prøv igen.");
                }
            }
            WaitForUser();
        }

        /// <summary>
        /// Hjælper brugeren med at se resultatet, før programmet fortsætter.
        /// </summary>
        static void WaitForUser()
        {
            Console.WriteLine("\nTryk på en vilkårlig tast for at fortsætte...");
            Console.ReadKey();
        }
    }
}

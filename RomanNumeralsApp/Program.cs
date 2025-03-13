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
            // Initialiserer vores converter facade, som implementerer IRomanNumeralConverter.
            IRomanNumeralConverter converter = new RomanNumeralFacade();
            bool continueProgram = true;

            // Hovedløkke: Kører, indtil brugeren vælger at afslutte.
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

                // Læser brugerens valg og sikrer, at vi ikke får en null-reference.
                string choice = Console.ReadLine() ?? string.Empty;

                // Switch-case, der kalder den relevante funktion.
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

        // Metode, der håndterer konvertering af romertal til decimal med fejlbehandling.
        static void ConvertRomanToDecimal(IRomanNumeralConverter converter)
        {
            while (true)
            {
                Console.Write("Indtast venligst et romertal (f.eks. MCMXCIX): ");
                string romanInput = Console.ReadLine() ?? string.Empty;

                try
                {
                    int decimalResult = converter.ToDecimal(romanInput);
                    Console.WriteLine($"Romertallet {romanInput} svarer til {decimalResult}.");
                    break; // Hvis konverteringen lykkes, brydes løkken.
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fejl: {ex.Message}. Prøv igen.");
                }
            }
            WaitForUser();
        }

        // Metode, der håndterer konvertering af decimal til romertal med fejlbehandling.
        static void ConvertDecimalToRoman(IRomanNumeralConverter converter)
        {
            while (true)
            {
                Console.Write("Indtast venligst et decimaltal (mellem 1 og 10000): ");
                string decimalInput = Console.ReadLine() ?? string.Empty;

                try
                {
                    int number = int.Parse(decimalInput);
                    string romanResult = converter.ToRoman(number);
                    Console.WriteLine($"{number} konverteret til romertal er: {romanResult}.");
                    break; // Bryd løkken, når konverteringen lykkes.
                }
                catch (FormatException)
                {
                    Console.WriteLine("Fejl: Indtast venligst et gyldigt tal.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fejl: {ex.Message}. Prøv igen.");
                }
            }
            WaitForUser();
        }

        // Hjælpefunktion, der pauser programmet, så brugeren kan se resultatet.
        static void WaitForUser()
        {
            Console.WriteLine("\nTryk på en vilkårlig tast for at fortsætte...");
            Console.ReadKey();
        }
    }
}

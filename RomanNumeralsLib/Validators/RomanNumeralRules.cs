using System.Runtime.Intrinsics.X86;

namespace RomanNumeralsLib.Validators
{
    /// <summary>
    /// Repræsenterer en regel for konvertering af et romertalssymbol til en numerisk værdi.
    /// </summary>
    public class RomanNumeralRule
    {
        /// <summary>
        /// Det romerske symbol, fx "M", "CM", "I" osv.
        /// </summary>
        public string Roman { get; }
        
        /// <summary>
        /// Den decimale værdi, som symbolet repræsenterer.
        /// </summary>
        public int Value { get; }

        public RomanNumeralRule(string numeral, int value)
        {
            Roman = numeral;
            Value = value;
        }
    }

    /// <summary>
    /// Indeholder de centrale regler for romertal-konvertering.
    /// Denne klasse definerer en liste af RomanNumeralRule objekter, som parrer
    /// hvert romersk symbol med dets tilsvarende numeriske værdi.
    /// Listen er sorteret fra den højeste værdi til den laveste, hvilket gør den ideel til brug
    /// i en "greedy" algoritme for konvertering af decimaltal til romertal.
    /// </summary>
    public static class RomanNumeralRules
    {
        public static IReadOnlyList<RomanNumeralRule> Rules { get; } = new List<RomanNumeralRule>
        {
            new RomanNumeralRule("A", 10000),
            new RomanNumeralRule("MA",9000),
            new RomanNumeralRule("B", 5000),
            new RomanNumeralRule("MB",4000),
            new RomanNumeralRule("M", 1000),
            new RomanNumeralRule("CM", 900),
            new RomanNumeralRule("D", 500),
            new RomanNumeralRule("CD", 400),
            new RomanNumeralRule("C", 100),
            new RomanNumeralRule("XC", 90),
            new RomanNumeralRule("L", 50),
            new RomanNumeralRule("XL", 40),
            new RomanNumeralRule("X", 10),
            new RomanNumeralRule("IX", 9),
            new RomanNumeralRule("V", 5),
            new RomanNumeralRule("IV", 4),
            new RomanNumeralRule("I", 1)
        };
    }
}

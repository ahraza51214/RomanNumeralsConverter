namespace RomanNumeralsLib.Interfaces
{
    /// <summary>
    /// Interface for konvertering mellem romertal og decimaltal.
    /// </summary>
    public interface IRomanNumeralConverter
    {
        /// <summary>
        /// Konverterer et gyldigt romertal til et decimaltal.
        /// </summary>
        /// <param name="roman">Romertalsstreng fx "MCMXCIX".</param>
        /// <returns>Det decimale tal fx 1999.</returns>
        int ToDecimal(string roman);

        /// <summary>
        /// Konverterer et decimaltal til et romertal.
        /// </summary>
        /// <param name="number">Et tal mellem 1 og 2999.</param>
        /// <returns>Romertalsstreng.</returns>
        string ToRoman(int number);
    }
}
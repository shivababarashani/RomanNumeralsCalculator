using Calculator.Common.Helpers.Converter.RomanNumeral;

namespace Calculator.Common.Extentions
{
    public static class StringExtensions
    {
        public static int ConvertRomanNumeralToInt(this string input)
        {
            using (var converter = new RomanNumeralConverter())
            {
                return converter.ConvertRomanNumeralToInt(input);
            }
        }
    }
}

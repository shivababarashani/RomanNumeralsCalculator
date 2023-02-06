using Calculator.Common.Helpers.Converter.RomanNumeral;

namespace Calculator.Common.Extentions
{ 
    public static class IntExtensions
    {
        public static string ConvertIntToRomanNumeral(this int input)
        {
            using (var converter = new RomanNumeralConverter())
            {
                return converter.ConvertIntToRomanNumeral(input);
            }
        }
    }
}

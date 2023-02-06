namespace Calculator.Common.Helpers.Converter.RomanNumeral
{
    public class InvalidRomanNumeralException : Exception
    {
        public InvalidRomanNumeralException(string message)
            : base(message)
        {
        }
    }
}

using Calculator.Domain.Contracts;
using Calculator.Common.Extentions;

namespace Calculator.Service.Calculator
{
    public class CalculatorService : ICalculatorService
    {
        public string AddNumbers(string firstNumber, string secoundNumber)
        {
            int FirstNumber = firstNumber.ConvertRomanNumeralToInt();
            int SecoundNumber = secoundNumber.ConvertRomanNumeralToInt();
            var sum = FirstNumber + SecoundNumber;

            return sum.ConvertIntToRomanNumeral();
        }
    }
}

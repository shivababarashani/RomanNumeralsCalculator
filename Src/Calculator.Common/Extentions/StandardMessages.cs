using Calculator.Common.Helpers.Converter.RomanNumeral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Common.Extentions
{
    public class StandardMessages
    {
        public static void RomanNumeralIsNotValidMessage(string input)
        {
            throw new InvalidRomanNumeralException($"{input} is not valid");
        }
    }
}

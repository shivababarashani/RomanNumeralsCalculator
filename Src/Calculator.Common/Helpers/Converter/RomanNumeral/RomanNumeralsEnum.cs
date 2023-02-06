using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Common.Helpers.Converter.RomanNumeral
{
    public enum RomanNumeralsEnum
    {
        Default = 0, // can't parse this numeral (sentinel value)
        I = 1,
        V = 5,
        X = 10,
        L = 50,
        C = 100,
        D = 500,
        M = 1000
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Domain.Contracts
{
    public interface ICalculatorService
    {
        string AddNumbers(string firstNumber, string secoundNumber);
    }
}

using System.Collections.Specialized;

namespace Calculator.Common.Helpers.Converter.RomanNumeral
{
    public class RomanNumeralConverter :IDisposable
    {
        private static readonly OrderedDictionary RomanNumeralsDic = new OrderedDictionary()
        {
            {"I", 1}, {"V", 5}, {"X", 10}, {"L", 50}, {"C", 100}, {"D", 500}, {"M", 1000}, {"V`", 5000}, {"X`", 10000}, {"L`", 50000}, {"C`", 100000}, {"D`", 500000}, {"M`", 1000000}
        };
       
        public int ConvertRomanNumeralToInt(string input)
        {
            input.MustBeValid();
            var listOfValues = new List<int>();
            
            for (var index = 0; index < input.Length; index++)
            {
                // get character at position index
                var current = input[index];
               
                var currentAsEnum = (RomanNumeralsEnum)Enum.Parse(typeof(RomanNumeralsEnum), current.ToString(), true);
                var nextAsEnum = RomanNumeralsEnum.Default;

                if (index + 1 < input.Length)
                {
                    var next = input[index + 1];
                    nextAsEnum = (RomanNumeralsEnum)Enum.Parse(typeof(RomanNumeralsEnum), next.ToString(), true);
                }

                // do some maths
                if (nextAsEnum > currentAsEnum)
                {
                    listOfValues.Add(nextAsEnum - currentAsEnum);
                    index++;
                }
                else
                {
                    listOfValues.Add((int)currentAsEnum);
                }
            }

            return listOfValues.Sum();
        }
        public string ConvertIntToRomanNumeral(int currentInput)
        {
            string answer = "";


            if (IsInputEqualToOneOfTheRomanNumerals(currentInput))
            {
                string romanNumeral = GetRomanNumeralFromValue(currentInput);
                return romanNumeral;
            }
            int nextInput;
            if (IsInputLargerThanLargestRomanNumeralValue(currentInput))
            {
                int largestRomanNumeralValue = GetLargestRomanNumeralValue();
                string largestRomanNumeral = GetRomanNumeralFromValue(largestRomanNumeralValue);
                answer += largestRomanNumeral;
                nextInput = currentInput - largestRomanNumeralValue;
            }
            else
            {
                int lowerRomanNumeralValue = GetLowerRomanNumeralValue(currentInput);
                int upperRomanNumeralValue = GetUpperRomanNumeralValue(lowerRomanNumeralValue);
                int upperRomanNumeralValueMinusInput = upperRomanNumeralValue - currentInput;
                int lowerPowerOfTenRomanNumeralValue = GetLowerPowerOfTenRomanNumeralValue(lowerRomanNumeralValue, upperRomanNumeralValue);

                if (CanInputBeWrittenAsSmallerNumeralInFrontOfLargerNumeral(upperRomanNumeralValueMinusInput, lowerPowerOfTenRomanNumeralValue))
                {
                    string lowerPowerOfTenRomanNumeralInFrontOfUpperRomanNumeral = ConcatenateRomanNumeralsFromValues(lowerPowerOfTenRomanNumeralValue, upperRomanNumeralValue);
                    int lowerPowerOfTenRomanNumeralInFrontOfUpperRomanNumeralValue = upperRomanNumeralValue - lowerPowerOfTenRomanNumeralValue;
                    answer += lowerPowerOfTenRomanNumeralInFrontOfUpperRomanNumeral;
                    nextInput = currentInput - lowerPowerOfTenRomanNumeralInFrontOfUpperRomanNumeralValue;
                }
                else
                {
                    answer += GetRomanNumeralFromValue(lowerRomanNumeralValue);
                    nextInput = currentInput - lowerRomanNumeralValue;
                }
            }
            answer += ConvertIntToRomanNumeral(nextInput);

            return answer;
        }


        private static bool CanInputBeWrittenAsSmallerNumeralInFrontOfLargerNumeral(int upperRomanNumeralValueMinusInput, int lowerPowerOfTenRomanNumeralValue)
        {
            return upperRomanNumeralValueMinusInput <= lowerPowerOfTenRomanNumeralValue;
        }

        private static bool IsInputEqualToOneOfTheRomanNumerals(int currentInput)
        {
            return RomanNumeralsDic.ContainsValue(currentInput);
        }

        private static bool IsInputLargerThanLargestRomanNumeralValue(int input)
        {
            return input > GetLargestRomanNumeralValue();
        }

        private static int GetLargestRomanNumeralValue()
        {
            return GetRomanNumeralValueAtIndex(RomanNumeralsDic.Count - 1);
        }

        private static int GetLowerPowerOfTenRomanNumeralValue(int lowerRomanNumeralValue, int upperRomanNumeralValue)
        {
            int lowerPowerOfTenRomanNumeralValue = lowerRomanNumeralValue;

            if (MathCalculator.IsValuePowerOfTen(upperRomanNumeralValue))
            {
                lowerPowerOfTenRomanNumeralValue = GetNextLowerPowerOfTenRomanNumeral(lowerRomanNumeralValue);
            }
            return lowerPowerOfTenRomanNumeralValue;
        }

        private static string ConcatenateRomanNumeralsFromValues(int beforeRomanNumeralValue, int afterRomanNumeralValue)
        {
            string lowerRomanNumeralPowerOfTen = GetRomanNumeralFromValue(beforeRomanNumeralValue);
            string upperRomanNumeral = GetRomanNumeralFromValue(afterRomanNumeralValue);
            return lowerRomanNumeralPowerOfTen + upperRomanNumeral;
        }

        private static int GetNextLowerPowerOfTenRomanNumeral(int currentValue)
        {
            int lowerPowerOfTenRomanNumeralValue = 0;
            if (MathCalculator.IsValuePowerOfTen(currentValue))
            {
                lowerPowerOfTenRomanNumeralValue = currentValue;
            }
            else
            {
                int lowerRomanNumeralIndex = RomanNumeralsDic.IndexOfValue(currentValue);
                for (int i = lowerRomanNumeralIndex; i >= 0; i--)
                {
                    int currentRomanNumeralValue = GetRomanNumeralValueAtIndex(i);
                    if (MathCalculator.IsValuePowerOfTen(currentRomanNumeralValue))
                    {
                        lowerPowerOfTenRomanNumeralValue = currentRomanNumeralValue;
                        break;
                    }
                }
            }
            return lowerPowerOfTenRomanNumeralValue;
        }

        private static int GetUpperRomanNumeralValue(int lowerRomanNumeralValue)
        {
            int indexOfLowerRomanNumeral = RomanNumeralsDic.IndexOfValue(lowerRomanNumeralValue);
            int upperRomanNumeralValue = GetRomanNumeralValueAtIndex(indexOfLowerRomanNumeral + 1);
            return upperRomanNumeralValue;
        }

        private static int GetLowerRomanNumeralValue(int input)
        {
            for (int i = RomanNumeralsDic.Count - 1; i >= 0; i--)
            {
                int romanNumeralValue = GetRomanNumeralValueAtIndex(i);

                if (romanNumeralValue <= input)
                {
                    return romanNumeralValue;
                }
            }
            throw new Exception("Lower Roman Numeral Not Found");
        }

        private static int GetRomanNumeralValueAtIndex(int index)
        {
            return (int)RomanNumeralsDic[index];
        }

        private static string GetRomanNumeralFromValue(int value)
        {
            return (string)RomanNumeralsDic.GetKeyFromFirstElementWithValue(value);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
    }
}


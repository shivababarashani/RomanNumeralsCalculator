using Calculator.Common.Extentions;

namespace Calculator.Common.Helpers.Converter.RomanNumeral
{
    public static class RomanNumeralValidations
    {
        private static readonly List<string> _numerals = new List<string> { "I", "V", "X", "L", "C", "D", "M" };
        public static void MustBeValid(this string input)
        {
            // take ch and compare it to all of the characters in the list
            // all of these have to pass (return true) for the string to be valid
            if (!input.All(ch => _numerals.Contains(ch.ToString(), StringComparer.CurrentCultureIgnoreCase)))
            {
                StandardMessages.RomanNumeralIsNotValidMessage(input);
            }

            //'D', 'L', or 'V' may only appear at most once in the string
            if (input.Count(x => x == 'D') > 1 || input.Count(x => x == 'L') > 1 || input.Count(x => x == 'V') > 1)
            {
                //throw new InvalidRomanNumeralException("ffff");
                StandardMessages.RomanNumeralIsNotValidMessage(input);
            }

            // no more than 3 consecutive Ms, Cs, Xs or Is:
            if (input.IndexOf("MMMM") >= 0 || input.IndexOf("CCCC") >= 0 || input.IndexOf("XXXX") >= 0 || input.IndexOf("IIII") >= 0)
            {
                StandardMessages.RomanNumeralIsNotValidMessage(input);
            }

            //' Only I, X, and C can be used for subtraction (V, L, and D cannot). Therefore, the
            //' following pairs of letter are invalid: VX, VL, VC, VD, VM, LC, LD, LM, DM.
            //' When subtracting, the value of the letter being subtracted from cannot be more than
            //' 10 times the value of letter being used for subtraction. Therefore, the following pairs
            //' of letters are invalid: IL, IC, ID, IM, XD, XM.
            if (input.IndexOf("IL") >= 0
                || input.IndexOf("IC") >= 0
                || input.IndexOf("ID") >= 0
                || input.IndexOf("IM") >= 0
                || input.IndexOf("XD") >= 0
                || input.IndexOf("XM") >= 0
                || input.IndexOf("VX") >= 0
                || input.IndexOf("VL") >= 0
                || input.IndexOf("VC") >= 0
                || input.IndexOf("VD") >= 0
                || input.IndexOf("VM") >= 0
                || input.IndexOf("LC") >= 0
                || input.IndexOf("LD") >= 0
                || input.IndexOf("LM") >= 0
                || input.IndexOf("DM") >= 0)
            {
                StandardMessages.RomanNumeralIsNotValidMessage(input);
            }


            //' Once a letter has been used as a subtraction modifier, that letter cannot appear again
            //' in the string, unless that letter itself is subtracted from. For example, CDC is not
            //' valid (you would be subtracting 100 from 500, then adding it right back) -
            //' but CDXC (for 490) is valid. Similarly, XCX is not valid, but XCIX is.
            //' To summarize:
            //' C cannot follow CM or CD except in case of XC.
            //' X cannot follow XC or XL except in the case of IX.
            if (AFollowsBInCExceptD("C", "CD", input, "XC"))
            {
                StandardMessages.RomanNumeralIsNotValidMessage(input);
            }
            if (AFollowsBInCExceptD("C", "CM", input, "XC"))
            {
                //throw new ArgumentException("fff");
                StandardMessages.RomanNumeralIsNotValidMessage(input);
            }
            if (AFollowsBInCExceptD("X", "XL", input, "IX")) 
            {
                StandardMessages.RomanNumeralIsNotValidMessage(input);
            }
            if (AFollowsBInCExceptD("X", "XC", input, "IX")) 
            {
                StandardMessages.RomanNumeralIsNotValidMessage(input);
            }
            if (AFollowsBInC("I", "IV", input)) 
            {
                StandardMessages.RomanNumeralIsNotValidMessage(input);
            }
            if (AFollowsBInC("I", "IX", input)) 
            {
                StandardMessages.RomanNumeralIsNotValidMessage(input);
            }

            // Once a letter has been subtracted from, neither it nor the next lowest multiple of 5 may
            // appear again in the string - so neither X nor V can follow IX, neither C nor L may follow
            // XC, and neither M nor D may follow CM.
            if (AFollowsBInC("X", "IX", input))
            {
                StandardMessages.RomanNumeralIsNotValidMessage(input);
            }
            if (AFollowsBInC("V", "IX", input)) 
            {
                StandardMessages.RomanNumeralIsNotValidMessage(input);
            }
            if (AFollowsBInC("C", "XC", input)) 
            {
                StandardMessages.RomanNumeralIsNotValidMessage(input);
            }
            if (AFollowsBInC("L", "XC", input)) 
            {
                StandardMessages.RomanNumeralIsNotValidMessage(input);
            }
            if (AFollowsBInC("M", "CM", input)) 
            {
                StandardMessages.RomanNumeralIsNotValidMessage(input);
            }
            if (AFollowsBInC("D", "CM", input)) 
            {
                StandardMessages.RomanNumeralIsNotValidMessage(input);
            }

            //  A letter cannot be used as a subtraction modifier if that letter, or the next highest
            //' multiple of 5, appears previously in the string - so IV or IX cannot follow I or V,
            //' XL or XC cannot follow X or L, and CD or CM cannot follow C or D.
            if (AFollowsBInC("IV", "I", input)) 
            {
                StandardMessages.RomanNumeralIsNotValidMessage(input);
            }
            if (AFollowsBInC("IX", "I", input)) 
            {
                StandardMessages.RomanNumeralIsNotValidMessage(input);
            }
            if (AFollowsBInC("IX", "V", input)) 
            {
                StandardMessages.RomanNumeralIsNotValidMessage(input);
            }
            if (AFollowsBInC("XL", "X", input)) 
            {
                StandardMessages.RomanNumeralIsNotValidMessage(input); 
            }
            if (AFollowsBInC("XC", "X", input)) 
            {
                StandardMessages.RomanNumeralIsNotValidMessage(input);
            }
            if (AFollowsBInC("XC", "L", input)) 
            {
                StandardMessages.RomanNumeralIsNotValidMessage(input);
            }
            if (AFollowsBInC("CD", "C", input)) 
            {
                StandardMessages.RomanNumeralIsNotValidMessage(input);
            }
            if (AFollowsBInC("CM", "C", input)) 
            {
                StandardMessages.RomanNumeralIsNotValidMessage(input);
            }
            if (AFollowsBInC("CM", "D", input)) 
            {
                StandardMessages.RomanNumeralIsNotValidMessage(input);
            }


        }

        private static bool AFollowsBInCExceptD(string inputA, string inputB, string inputC, string inputD)
        {
            int lngTestPos;
            string strRemChars;

            lngTestPos = inputC.IndexOf(inputB);
            if (lngTestPos == -1)
            {
                return false;
            }
            strRemChars = inputC.Substring(lngTestPos + inputB.Length);
            strRemChars = strRemChars.Replace(inputD, "");
            if (strRemChars.IndexOf(inputA) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private static bool AFollowsBInC(string inputA, string inputB, string inputC)
        {
            int lngTestPos;

            lngTestPos = inputC.IndexOf(inputB);
            if (lngTestPos >= 0)
            {
                if (inputC.IndexOf(inputA, lngTestPos + inputB.Length, StringComparison.Ordinal) >= 0)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }

        }
    }
}

using System;
using Xunit;
using Calculator.Common.Helpers.Converter.RomanNumeral;


namespace Calculator.Test
{
    public class RomanNumeralValidationTests
    {
        

        [Theory]
        [InlineData("Shiva")]
        public void Should_Throw_InvalidRomanNumeralException_When_Input_Not_RomanNumeral(string input)
        {
            // Arrange
            var converter = new RomanNumeralConverter();

            // Act
            var responseException = Record.Exception(() => converter.ConvertRomanNumeralToInt(input));

            // Assert
            Assert.NotNull(responseException);
            Assert.IsAssignableFrom<InvalidRomanNumeralException>(responseException);
            Assert.NotEmpty(responseException.Message);
            Assert.Contains(input, responseException.Message);
        }

        [Theory]
        [InlineData("DID")]
        [InlineData("LIXL")]
        [InlineData("VIIV")]
        public void Should_Throw_InvalidRomanNumeralException_When_Specific_Numerals_Consecutive_More_Than_Three(string input)
        {
            // Arrange
            var converter = new RomanNumeralConverter();

            // Act
            var responseException = Record.Exception(() => converter.ConvertRomanNumeralToInt(input));

            // Assert
            Assert.NotNull(responseException);
            Assert.IsAssignableFrom<InvalidRomanNumeralException>(responseException);
            Assert.NotEmpty(responseException.Message);
            Assert.Contains(input, responseException.Message);
        }

        [Theory]
        [InlineData("IMMMM")]
        [InlineData("LICCCC")]
        [InlineData("VXXXX")]
        [InlineData("IIII")]
        public void Should_Throw_InvalidRomanNumeralException_When_Specific_Numerals_Appear_More_Than_Once(string input)
        {
            // Arrange
            var converter = new RomanNumeralConverter();

            // Act
            var responseException = Record.Exception(() => converter.ConvertRomanNumeralToInt(input));

            // Assert
            Assert.NotNull(responseException);
            Assert.IsAssignableFrom<InvalidRomanNumeralException>(responseException);
            Assert.NotEmpty(responseException.Message);
            Assert.Contains(input, responseException.Message);
        }

        [Theory]
        [InlineData("VX")]
        [InlineData("VL")]
        [InlineData("VC")]
        [InlineData("VD")]
        [InlineData("VM")]
        [InlineData("LC")]
        [InlineData("LM")]
        [InlineData("DM")]
        [InlineData("IL")]
        [InlineData("IC")]
        [InlineData("ID")]
        [InlineData("IM")]
        [InlineData("XD")]
        [InlineData("XM")]
        [InlineData("IVX")]
        public void Should_Throw_InvalidRomanNumeralException_When_Have_Wrong_Following_Pair(string input)
        {
            // Arrange
            var converter = new RomanNumeralConverter();

            // Act
            var responseException = Record.Exception(() => converter.ConvertRomanNumeralToInt(input));

            // Assert
            Assert.NotNull(responseException);
            Assert.IsAssignableFrom<InvalidRomanNumeralException>(responseException);
            Assert.NotEmpty(responseException.Message);
            Assert.Contains(input, responseException.Message);
        }

        [Theory]
        [InlineData("CMC")]
        [InlineData("CDC")]
        [InlineData("XLX")]
        [InlineData("XCX")]
        [InlineData("IVI")]
        [InlineData("IXI")]
        public void Should_Throw_InvalidRomanNumeralException_When_Numerals_Appear_Just_After_Subtraction(string input)
        {
            // Arrange
            var converter = new RomanNumeralConverter();

            // Act
            var responseException = Record.Exception(() => converter.ConvertRomanNumeralToInt(input));

            // Assert
            Assert.NotNull(responseException);
            Assert.IsType<InvalidRomanNumeralException>(responseException);
            Assert.NotEmpty(responseException.Message);
            Assert.Contains(input, responseException.Message);
        }

        [Theory]
        [InlineData("IXX")]
        [InlineData("IXV")]
        [InlineData("XCC")]
        [InlineData("XCL")]
        [InlineData("CMM")]
        [InlineData("CMD")]
        public void Should_Throw_InvalidRomanNumeralException_When_Numerals_Use_In_Subtraction_Then_Apper_Again_Just_After_That_Numeral(string input)
        {
            // Arrange
            var converter = new RomanNumeralConverter();

            // Act
            var responseException = Record.Exception(() => converter.ConvertRomanNumeralToInt(input));

            // Assert
            Assert.NotNull(responseException);
            Assert.IsType<InvalidRomanNumeralException>(responseException);
            Assert.NotEmpty(responseException.Message);
            Assert.Contains(input, responseException.Message);
        }

        [Theory]
        [InlineData("IIV")]
        [InlineData("IIX")]
        [InlineData("VIX")]
        [InlineData("XXC")]
        [InlineData("LXC")]
        [InlineData("CCD")]
        [InlineData("CCM")]
        [InlineData("DCM")]
        public void Should_Throw_InvalidRomanNumeralException_When_Numerals_Use_In_Subtraction_Then_Apper_Again_Privious_That_Numeral(string input)
        {
            // Arrange
            var converter = new RomanNumeralConverter();

            // Act
            var responseException = Record.Exception(() => converter.ConvertRomanNumeralToInt(input));

            // Assert
            Assert.NotNull(responseException);
            Assert.IsAssignableFrom<InvalidRomanNumeralException>(responseException);
            Assert.NotEmpty(responseException.Message);
            Assert.Contains(input, responseException.Message);
        }
    }
}





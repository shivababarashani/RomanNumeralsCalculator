using Calculator.Common.Helpers.Converter.RomanNumeral;
using Xunit;

namespace Calculator.Test
{
    public class RomanNumeralConverterTests
    {
        [Fact]
        public void Should_Exist()
        {
            // Arrange
            var converter = new RomanNumeralConverter();
            // Act
            // Assert
            Assert.NotNull(converter);
        }

        [Fact]
        public void Converter_ShouldTake_String_Return_Int()
        {
            // Arrange
            var converter = new RomanNumeralConverter();
            var input = "III"; // 3 in Roman Numerals

            // Act
            var response = converter.ConvertRomanNumeralToInt(input);

            // Assert
            Assert.NotNull(response);
            Assert.IsType<int>(response);
        }

        [Theory]
        [InlineData("III", 3)]
        [InlineData("I", 1)]
        [InlineData("IV", 4)]
        [InlineData("MCMLXXXVI", 1986)]
        [InlineData("MMXX", 2020)]
        [InlineData("MDC", 1600)]
        public void Parse_ShouldTake_String_Return_CorrectIntValue(string input, int targetOutput)
        {
            // Arrange
            var converter = new RomanNumeralConverter();

            // Act
            var response = converter.ConvertRomanNumeralToInt(input);

            // Assert
            Assert.NotNull(response);
            Assert.IsType<int>(response);
            Assert.Equal(targetOutput, response);
        }
        
    }
}

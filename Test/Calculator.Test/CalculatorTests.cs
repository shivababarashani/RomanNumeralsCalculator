using Calculator.Service.Calculator;
using Xunit;

namespace Calculator.Test
{
    public class CalculatorTests
    {
        [Fact]
        public void Should_Exist()
        {
            // Arrange
            var calculator = new CalculatorService();
            // Act
            // Assert
            Assert.NotNull(calculator);
        }

        [Trait("Math Ops", "Simple")]
        [Theory(DisplayName = "Add Numbers")]
        [InlineData("IV", "IV", "VIII")]
        [InlineData("MCLI", "DXV", "MDCLXVI")]
        public void Should_Add_Two_Numbers(string firstNumber, string secoundNumber, string expectedResult)
        {
            // Arrange
            var calculator = new CalculatorService();

            // Act 
            var result = calculator.AddNumbers(firstNumber, secoundNumber);

            // Assert 
            Assert.Equal(expectedResult, result);
        }
    }
}

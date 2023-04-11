using Xunit.Abstractions;

namespace Calculator.Domain.Test
{
    public class CalculatorTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public CalculatorTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        [Trait("Group","G1")]
        public void get_true_when_input_is_positive()
        {
            // Arrange
            Calculator calculator = new();

            // Act
            var PositiveResult = calculator.IsPositive(1);

            // Assert
            _testOutputHelper.WriteLine("This is a custom message");
            Assert.True(PositiveResult);
        }

        [Fact]
        [Trait("Group","G1")]
        public void get_four_for_sum_one_three()
        {
            // Arrange
            Calculator calculator = new();

            // Act
            var Result = calculator.Sum(1,3);

            // Assert
            Assert.Equal(4,Result);
        }

        [Fact(Skip = "Just for test")]
        public void divide_by_zero_test()
        {
            // Arrange
            Calculator calculator = new();

            // Act


            // Assert
            Assert.Throws<DivideByZeroException>(()=>calculator.Divide(1, 0));
        }
    }
}
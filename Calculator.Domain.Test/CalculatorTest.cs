using System.Reflection;
using System.Runtime.CompilerServices;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Calculator.Domain.Test
{

    public class TestCalculatorDataProviderAttribute:DataAttribute
    {

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var result = new List<object[]>()
            {
                new object[] { 2,1,2},
                new object[] { 1,1,1},
                new object[] { 2,-2,-1},
                new object[] { 0,1,0},
                new object[] { 3,2,1.5},
            };

            return result;
        }
    }
    public class TestCalculatorDataProvider
    {
        public static List<object[]> GetDataForSum()
        {
            var result = new List<object[]>() 
            {
                new object[] { 2,0,2},
                new object[] { 1,1,2},
                new object[] { 2,-2,0},
                new object[] { 0,0,0},
                new object[] { 1,2,3},
            };

            return result;
        }

    }
    public class CalculatorTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public CalculatorTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        [Trait("Group", "G1")]
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

        [Theory]
        [Trait("Group", "G1")]
        [InlineData(1, true)]
        [InlineData(0, false)]
        [InlineData(-1, false)]
        public void check_IsPositive_WorkCorrect_By_DataDrivenTest(int x, bool expectedResult)
        {
            // Arrange
            Calculator calculator = new();

            // Act
            var IsPositiveResult = calculator.IsPositive(x);

            // Assert
            Assert.Equal(expectedResult, IsPositiveResult);
        }

        [Fact]
        [Trait("Group", "G1")]
        public void get_four_for_sum_one_three()
        {
            // Arrange
            Calculator calculator = new();

            // Act
            var Result = calculator.Sum(1, 3);

            // Assert
            Assert.Equal(4, Result);
        }
        [Theory]
        [MemberData("GetDataForSum", MemberType = typeof(TestCalculatorDataProvider))]
        [Trait("Group", "G1")]
        public void sum_by_GetDataDriven(int x, int y, int result)
        {
            // Arrange
            Calculator calculator = new();

            // Act
            var R = calculator.Sum(x, y);

            // Assert
            Assert.Equal(result, R);
        }

        [Theory]
        [TestCalculatorDataProvider]
        public void divide_two_numbers(double x, double y,double expectedResult)
        {
            // Arrange
            Calculator calculator = new();

            // Act
            var result = calculator.Divide(x, y);

            // Assert
            Assert.Equal(expectedResult,result);
        }

        [Fact(Skip = "Just for test")]
        public void divide_by_zero_test()
        {
            // Arrange
            Calculator calculator = new();

            // Act


            // Assert
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(1, 0));
        }
    }
}
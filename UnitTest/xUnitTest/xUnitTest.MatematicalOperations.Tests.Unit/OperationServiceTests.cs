using FluentAssertions;
using Xunit.Abstractions;
using xUnitTest.MathematicalOperations;

namespace xUnitTest.MatematicalOperations.Tests.Unit;
public class OperationServiceTests
{
    private readonly OperationService _operationService;
    public OperationServiceTests(ITestOutputHelper outputHelper)
    {
        _operationService = new OperationService();
    }

    [Theory]
    [InlineData(5,4,9)]
    [InlineData(-5,3,-2)]
    [InlineData(5,-13,-8)]
    public void Add_ShouldAddTwoInteger(int a, int b, int expected)
    {
        // Arrange
        

        // Act
        var result = _operationService.Add(a, b);


        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void Subtract_ShouldSubtractTwoInteger()
    {
        // Act
        var result = _operationService.Subtract(2, 1);


        // Asert
        result.Should().Be(1);
    }

    [Theory]
    [InlineData(5,5,1)]
    [InlineData(25,5,5)]
    [InlineData(0,0,0, Skip = "0 0'a bölünememez!")]
    public void Divide_ShouldDivideTwoNumber(int a, int b, int expected)
    {
        // Act
        var result = _operationService.Divide(a, b);


        // Assert       
        result.Should().Be(expected);
    }
  
}

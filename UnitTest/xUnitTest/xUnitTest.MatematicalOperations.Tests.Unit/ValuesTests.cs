using FluentAssertions;
using NSubstitute;
using xUnitTest.MathematicalOperations;

namespace xUnitTest.MatematicalOperations.Tests.Unit;
public class ValuesTests
{
    private readonly Values _values;

    public ValuesTests()
    {
        _values = new Values();
    }

    [Fact]
    public void StringTest()
    {
        // Act 
        var name = _values.FullName;

        // Assert
        name.Should().Be("Taner Saydam");
        name.Should().NotBeEmpty();
        name.Should().NotBeNull();
        name.Should().StartWith("T");
        name.Should().EndWith("m");
        name.Should().HaveLength(12);
    }

    [Fact]
    public void NumberTest()
    {
        // Act
        var age = _values.Age;

        // Assert
        age.Should().Be(33);
        age.Should().NotBe(34);
        age.Should().NotBeInRange(34, 50);
    }

    [Fact]
    public void DateTest()
    {
        // Act
        var dateOfBirthDay = _values.DateOfBirthDay;

        // Assert
        dateOfBirthDay.Should().Be(new(1989, 09, 03));
        dateOfBirthDay.Should().BeOnOrBefore(new(2000, 01, 01));
        dateOfBirthDay.Should().BeAfter(new(1988, 01, 01));
    }

    [Fact]
    public void ObjectTest()
    {
        // Act
        var user = _values.User;

        // Assert
        user.Should().BeEquivalentTo(new User() { Id = 1, FullName = "Taner Saydam" });
    }

    [Fact]
    public void InternalNumberTest()
    {
        // Act
        var number = _values.Number;

        // Assert
        number.Should().Be(10);
    }

    [Fact]
    public void CheckNumberIfTheGreaterThanZero_ShouldThrowExceptionIfNumberLesstThanZero()
    {
        // Act
        Action result = () => _values.CheckNumberIfTheGreaterThanZero(-1);

        // Assert
        result.Should().Throw<ArgumentException>().WithMessage("Numara 0 dan küçük olamaz");
    }

    [Fact]
    public void AddUser_ShouldAddUserToDatabase()
    {
        // Arrange
        ApplicationDbContext context = Substitute.For<ApplicationDbContext>();
        UserRepository userRepository = new(context);
        context.SaveChanges().Returns(1); // Assuming save changes returns the number of affected rows

        // Act
        var result = userRepository.Add("Taner Saydam");

        // Assert
        result.Should().Be(true);
    }
}

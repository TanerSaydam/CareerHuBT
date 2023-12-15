using FluentAssertions;
using NSubstitute;
using OgrenciSinavSistemiServer.WebApi.DTOs;
using OgrenciSinavSistemiServer.WebApi.Models;
using OgrenciSinavSistemiServer.WebApi.Repositories;
using OgrenciSinavSistemiServer.WebApi.Services;
using Xunit;

namespace OgrenciSinavSistemiServer.WebApi.Tests.Unit;
public class UserServiceTests
{
    private readonly IUserRepository userRepository = Substitute.For<IUserRepository>();
    private readonly IJwtService jwtService = Substitute.For<IJwtService>();
    [Fact]
    public async Task LoginAsync_ShouldReturnToken_WhenUserExist()
    {
        // Arrange
        UserService userService = new(userRepository, jwtService);
        LoginDto request = new("taner");
        User user = new()
        {
            Id = Guid.NewGuid(),
            Name = "Taner Saydam",
            IsTeacher = true,
            UserName = "taner"
        };
        userRepository.GetByUserNameAsync(Arg.Any<string>()).Returns(user);
        jwtService.CreateToken(user).Returns("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c");

        // Act
        var result = await userService.LoginAsync(request);

        // Assert
        result.Should().NotBeEmpty();
    }
}

using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using OgrenciSinavSistemiServer.WebApi.Abstractions;
using OgrenciSinavSistemiServer.WebApi.DTOs;
using OgrenciSinavSistemiServer.WebApi.Models.Users;
using OgrenciSinavSistemiServer.WebApi.Services.Jwts;
using Xunit;

namespace OgrenciSinavSistemiServer.WebApi.Tests.Unit;
public class UserServiceTests
{
    private readonly IUserRepository userRepository = Substitute.For<IUserRepository>();
    private readonly IJwtService jwtService = Substitute.For<IJwtService>();
    private readonly IUnitOfWork unitOfWork = Substitute.For<IUnitOfWork>();
    private readonly AuthService userService;
    public UserServiceTests()
    {
        userService = new(userRepository, jwtService);
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnIsErrorTrue_WhenUserNotFound()
    {
        // Arrange        
        LoginDto request = new("taner");
        userRepository.GetByUserNameAsync(Arg.Any<string>(), default).ReturnsNull();

        // Act
        var response = await userService.LoginAsync(request,default);

        // Assert
        response.IsError.Should().BeTrue();
    }

    [Fact]
    public async Task LoginAsync_ShouldReturnToken_WhenUserExists()
    {
        // Arrange        
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
        result.Value.Should().NotBeEmpty();
    }    
}

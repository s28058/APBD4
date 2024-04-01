using JetBrains.Annotations;
using LegacyApp;

namespace LegacyApp.Tests;

[TestSubject(typeof(UserService))]
public class UserServiceTest
{

    [Fact]
    public void ShouldNotAddUserWithEmptyFirstName()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var success = userService.AddUser(null, "kowalski", "ja@tu.com", DateTime.Now, 100);

        // Assert
        Assert.False(success);
    }
    
    [Fact]
    public void ShouldNotAddUserWithEmptyLastName()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var success = userService.AddUser("Kazimierz", null, "ja@tu.com", DateTime.Now, 100);

        // Assert
        Assert.False(success);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData("wPracy")]
    [InlineData("Ja@tapczan")]
    [InlineData("www.cats.com")]
    public void ShouldNotAddUserWithInvalidEmail(string invalidEmail)
    {
        // Arrange
        var userService = new UserService();

        // Act
        var success = userService.AddUser("Kazimierz", "Wielki", invalidEmail, DateTime.Now, 100);

        // Assert
        Assert.False(success);
    }
}
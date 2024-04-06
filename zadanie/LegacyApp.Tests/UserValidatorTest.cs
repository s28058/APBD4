using JetBrains.Annotations;

namespace LegacyApp.Tests;

[TestSubject(typeof(UserValidator))]

public class UserValidatorTest
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
    
    [Fact]
    public void ShouldNotAddUserUnder21y()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var success = userService.AddUser("Kazimierz", "Wielki", "ja@tu.com", DateTime.Now.AddYears(-20), 100);

        // Assert
        Assert.False(success);
    }
}
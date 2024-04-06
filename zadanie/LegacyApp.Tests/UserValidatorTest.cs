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
    
    [Fact]
    public void ShouldAddUserWhenInputIsValid()
    {
        // Arrange
        var userService = new UserService();
        var firstName = "John";
        var lastName = "Doe";
        var email = "johndoe@gmail.com";
        var dateOfBirth = DateTime.Parse("1982-03-21");
        var clientId = 1;

        // Act
        var success = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        // Assert
        Assert.True(success);
    }
    
    [Fact]
    public void ShouldCalculateAgeCorrectlyWhenBirthdayHasNotOccuredYet()
    {
        // Arrange
        var userService = new UserService();
        var firstName = "John";
        var lastName = "Doe";
        var email = "johndoe@gmail.com";
        var dateOfBirth = new DateTime(DateTime.Now.AddYears(-21).Year, DateTime.Now.Month, DateTime.Now.AddDays(1).Day); 
        var clientId = 1;

        // Act
        var success = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        // Assert
        Assert.False(success); 
    }

    [Fact]
    public void ShouldCalculateAgeCorrectlyWhenBirthdayHasAlreadyOccured()
    {
        // Arrange
        var userService = new UserService();
        var firstName = "John";
        var lastName = "Doe";
        var email = "johndoe@gmail.com";
        var dateOfBirth = new DateTime(DateTime.Now.AddYears(-21).Year, DateTime.Now.Month, DateTime.Now.Day); 
        var clientId = 1;

        // Act
        var success = userService.AddUser(firstName, lastName, email, dateOfBirth, clientId);

        // Assert
        Assert.True(success); 
    }
}
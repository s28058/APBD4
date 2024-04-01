using JetBrains.Annotations;

namespace LegacyApp.Tests;

[TestSubject(typeof(Client))]
public class ClientTests
{
    [Fact]
    public void AfterSettingTypeItShouldBeSet()
    {
        // Arrange
        var client = new Client();
        
        // Act
        client.Type = "Test";
        // Assert
        Assert.Equal("Test", client.Type);
    }
    
    [Fact]
    public void TypeShouldBeNullWhenNotSet()
    {
        // Arrange
        var client = new Client();
        
        // Act
        
        // Assert
        Assert.Null(client.Type);
    }
}
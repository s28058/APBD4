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
        client.Type = ClientType.ImportantClient;
        // Assert
        Assert.Equal(ClientType.ImportantClient, client.Type);
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
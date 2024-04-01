using JetBrains.Annotations;
using LegacyApp;

namespace LegacyApp.Tests;

[TestSubject(typeof(InMemoryClientRepository))]
public class ClientRepositoryTests
{

    [Fact]
    public void ShouldReturnClientWhenExists()
    {
        // Arrange
        var clientRepository = new InMemoryClientRepository();

        // Act
        var client = clientRepository.GetById(1);

        // Assert
        Assert.NotNull(client);
    }

    [Fact]
    public void ShouldThrowExceptionWhenClientDoesntExists()
    {
        // Arrange
        var clientRepository = new InMemoryClientRepository();

        // Act
        var action = () => clientRepository.GetById(8);

        // Assert
        Assert.Throws<ArgumentException>(action);

    }
}
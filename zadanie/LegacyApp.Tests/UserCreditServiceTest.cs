

using JetBrains.Annotations;

namespace LegacyApp.Tests;

[TestSubject(typeof(UserCreditService))]

    public class UserCreditServiceTests
    {
        [Fact]
        public void ShouldReturnCreditLimitIfExists()
        {
            // Arrange
            var userCreditService = new UserCreditService();
            var lastName = "Doe";
            var dateOfBirth = DateTime.Now;

            // Act
            var creditLimit = userCreditService.GetCreditLimit(lastName);

            // Assert
            Assert.Equal(3000, creditLimit); // Zakładając, że limit kredytowy dla nazwiska "Doe" wynosi 3000
        }

        [Fact]
        public void ShouldThrowExceptionForNonExistingClient()
        {
            // Arrange
            var userCreditService = new UserCreditService();
            var lastName = "NonExisting";
            var dateOfBirth = DateTime.Now;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => userCreditService.GetCreditLimit(lastName));
        }
    }

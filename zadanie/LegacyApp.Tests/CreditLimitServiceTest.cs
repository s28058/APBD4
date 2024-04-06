using JetBrains.Annotations;
using LegacyApp;

namespace LegacyApp.Tests;
    
[TestSubject(typeof(CreditLimitService))]

public class CreditLimitServiceTests
    {
        [Fact]
        public void ShouldReturnZeroCreditLimitForVeryImportantClient()
        {
            // Arrange
            var userCreditService = new UserCreditService();
            var creditLimitService = new CreditLimitService(userCreditService);
            var lastName = "Doe";
            var dateOfBirth = DateTime.Parse("1982-03-21");
            var clientType = ClientType.VeryImportantClient;

            // Act
            var creditLimit = creditLimitService.GetCreditLimit(lastName, clientType);

            // Assert
            Assert.Equal(0, creditLimit);
        }

        [Fact]
        public void ShouldReturnCreditLimitDoubledForImportantClient()
        {
            // Arrange
            var userCreditService = new UserCreditService();
            var creditLimitService = new CreditLimitService(userCreditService);
            var lastName = "Doe";
            var dateOfBirth = DateTime.Parse("1982-03-21");
            var clientType = ClientType.ImportantClient;

            // Act
            var creditLimit = creditLimitService.GetCreditLimit(lastName, clientType);

            // Assert
            Assert.Equal(6000, creditLimit); // zakładając, że standardowy limit to 3000
        }

        [Fact]
        public void ShouldReturnNormalCreditLimitForNormalClient()
        {
            // Arrange
            var userCreditService = new UserCreditService();
            var creditLimitService = new CreditLimitService(userCreditService);
            var lastName = "Doe";
            var dateOfBirth = DateTime.Parse("1982-03-21");
            var clientType = ClientType.NormalClient;

            // Act
            var creditLimit = creditLimitService.GetCreditLimit(lastName, clientType);

            // Assert
            Assert.Equal(3000, creditLimit); // zakładając, że standardowy limit to 3000
        }
    }

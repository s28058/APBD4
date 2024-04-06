using System;

namespace LegacyApp
{
    public class UserService
    {
       
        private readonly IClientRepository _clientRepository;
        private readonly IUserValidator _userValidator;
        private readonly ICreditLimitService _creditLimitService;

        public UserService(IClientRepository clientRepository = null,
            IUserValidator userValidator = null,
            ICreditLimitService creditLimitService = null)
        {
            _clientRepository = clientRepository ?? new InMemoryClientRepository();
            _userValidator = userValidator ?? new UserValidator();
            _creditLimitService = creditLimitService ?? new CreditLimitService(new UserCreditService());
        }
        

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!_userValidator.ValidateUser(firstName,lastName,email,dateOfBirth))
            {
                return false;
            }

            var client = _clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            user.HasCreditLimit = client.Type != ClientType.VeryImportantClient;
            user.CreditLimit = _creditLimitService.GetCreditLimit(lastName, client.Type);

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}

using System;

namespace LegacyApp;

public interface ICreditLimitService
{
    int GetCreditLimit(string lastName, ClientType clientType);
}

public class CreditLimitService : ICreditLimitService
{
    private readonly UserCreditService _userCreditService;

    public CreditLimitService(UserCreditService userCreditService)
    {
        _userCreditService = userCreditService;
    }

    public int GetCreditLimit(string lastName, ClientType clientType)
    {
        if (clientType == ClientType.VeryImportantClient)
            return 0;

        int creditLimit = _userCreditService.GetCreditLimit(lastName);
        return clientType == ClientType.ImportantClient ? creditLimit * 2 : creditLimit;
    }
}

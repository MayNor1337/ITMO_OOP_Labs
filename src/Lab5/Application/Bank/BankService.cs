using Abstractions.Bank;
using Contracts.BankSystem;

namespace Application.Bank;

public class BankService : IBankService
{
    private readonly IBankManager _manager;

    public BankService(IBankManager manager)
    {
        _manager = manager;
    }

    public int CreateAccount(int pinCode)
    {
        return _manager.CreateAccount(pinCode).Result;
    }

    public LoginResult LoginToAdminPanel(int adminLogin, int adminPassword)
    {
        int password = _manager.GetAdminPin(adminLogin).Result;
        if (password == adminPassword)
            return new LoginResult.Success();

        return new LoginResult.InvalidPassword();
    }
}
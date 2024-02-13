namespace Abstractions.Bank;

public interface IBankManager
{
    public Task<int> CreateAccount(int pinCode);

    public Task<int> GetAdminPin(int adminLogin);
}
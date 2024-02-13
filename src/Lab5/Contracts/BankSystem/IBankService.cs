namespace Contracts.BankSystem;

public interface IBankService
{
    public int CreateAccount(int pinCode);

    public LoginResult LoginToAdminPanel(int adminLogin, int adminPassword);
}
namespace Abstractions.Account;

public interface IAccountManager
{
    public Task<double> GetAccountBalance(Models.Accounts.Account account);

    public void SetAccountBalance(Models.Accounts.Account account, double newBalance);

    public Task<IEnumerable<string>> GetAccountHistory(Models.Accounts.Account account);
}
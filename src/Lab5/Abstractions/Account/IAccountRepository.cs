namespace Abstractions.Account;

public interface IAccountRepository
{
    public Task<bool> IsAccountNotFound(int accountId);

    public Task<int> GetAccountPin(int accountId);
}
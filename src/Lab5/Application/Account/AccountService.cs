using Abstractions.Account;
using Contracts.Account;
using Contracts.BankSystem;

namespace Application.Account;

public class AccountService : IAccountsService
{
    private readonly IAccountRepository _repository;
    private readonly IAccountManager _manager;
    private Models.Accounts.Account _currentAccount = new Models.Accounts.Account(0);

    public AccountService(IAccountRepository repository, IAccountManager manager)
    {
        _repository = repository;
        _manager = manager;
    }

    public LoginResult Login(int accountId, int password)
    {
        if (_repository.IsAccountNotFound(accountId).Result)
            return new LoginResult.NotFound();

        if (password != _repository.GetAccountPin(accountId).Result)
            return new LoginResult.InvalidPassword();

        _currentAccount = new Models.Accounts.Account(accountId);

        return new LoginResult.Success();
    }

    public ViewBalanceResult ViewAccountBalance()
    {
        double sum = _manager.GetAccountBalance(_currentAccount).Result;
        return new ViewBalanceResult.Success(sum);
    }

    public WithdrawalsMoneyResult WithdrawMoney(double sum)
    {
        double balance = _manager.GetAccountBalance(_currentAccount).Result;

        if (balance < sum)
            return new WithdrawalsMoneyResult.NotEnoughMoney();

        _manager.SetAccountBalance(_currentAccount, balance - sum);
        return new WithdrawalsMoneyResult.Success();
    }

    public AddBalanceResult AddAccountBalance(double sum)
    {
        if (sum <= 0)
            return new AddBalanceResult.IncorrectDepositAmount();

        double balance = _manager.GetAccountBalance(_currentAccount).Result;

        _manager.SetAccountBalance(_currentAccount, balance + sum);
        return new AddBalanceResult.Success();
    }

    public IEnumerable<string> ViewHistoryOperations()
    {
        return _manager.GetAccountHistory(_currentAccount).Result;
    }
}
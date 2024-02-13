using Contracts.BankSystem;

namespace Contracts.Account;

public interface IAccountsService
{
    public LoginResult Login(int accountId, int password);

    public ViewBalanceResult ViewAccountBalance();

    public WithdrawalsMoneyResult WithdrawMoney(double sum);

    public AddBalanceResult AddAccountBalance(double sum);

    public IEnumerable<string> ViewHistoryOperations();
}
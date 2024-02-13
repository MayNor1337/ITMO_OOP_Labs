using Contracts.Account;
using Spectre.Console;

namespace Console.States.AccountStates;

public class AccountHistory : IState
{
    private readonly IAccountsService _accountsService;

    public AccountHistory(IAccountsService accountsService)
    {
        _accountsService = accountsService;
    }

    public string Name => "Account History";

    public StateExecuteResults Run()
    {
        IEnumerable<string> history = _accountsService.ViewHistoryOperations();
        foreach (string operation in history)
        {
            AnsiConsole.WriteLine(operation);
        }

        return new StateExecuteResults.RepeatYourState();
    }
}
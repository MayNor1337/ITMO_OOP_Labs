using System.Globalization;
using Contracts.Account;
using Spectre.Console;

namespace Console.States.AccountStates;

public class ViewAccountBalanceState : IState
{
    private readonly IAccountsService _accountsService;

    public ViewAccountBalanceState(IAccountsService accountsService)
    {
        _accountsService = accountsService;
    }

    public string Name => "View Account Balance";

    public StateExecuteResults Run()
    {
        ViewBalanceResult result = _accountsService.ViewAccountBalance();
        if (result is ViewBalanceResult.Success success)
        {
            AnsiConsole.WriteLine(CultureInfo.InvariantCulture, success.Balance);
            return new StateExecuteResults.RepeatYourState();
        }

        AnsiConsole.WriteLine("WRONG");
        return new StateExecuteResults.GoBackToPreviousState();
    }
}
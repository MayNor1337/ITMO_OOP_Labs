using Contracts.Account;
using Spectre.Console;

namespace Console.States.AccountStates;

public class WithdrawMoneyState : IState
{
    private readonly IAccountsService _accountsService;

    public WithdrawMoneyState(IAccountsService accountsService)
    {
        _accountsService = accountsService;
    }

    public string Name => "Withdraw Money";

    public StateExecuteResults Run()
    {
        double sum = AnsiConsole.Ask<double>("Enter the amount of the charge");
        WithdrawalsMoneyResult result = _accountsService.WithdrawMoney(sum);

        if (result is WithdrawalsMoneyResult.Success)
        {
            AnsiConsole.WriteLine("Take of your money");
            return new StateExecuteResults.RepeatYourState();
        }

        if (result is WithdrawalsMoneyResult.NotEnoughMoney)
        {
            AnsiConsole.WriteLine("Not enough money in the account");
            return new StateExecuteResults.RepeatYourState();
        }

        AnsiConsole.WriteLine("WRONG");
        return new StateExecuteResults.GoBackToPreviousState();
    }
}
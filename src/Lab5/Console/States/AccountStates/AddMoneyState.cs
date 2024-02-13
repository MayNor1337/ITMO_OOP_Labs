using Contracts.Account;
using Spectre.Console;

namespace Console.States.AccountStates;

public class AddMoneyState : IState
{
    private readonly IAccountsService _accountsService;

    public AddMoneyState(IAccountsService accountsService)
    {
        _accountsService = accountsService;
    }

    public string Name => "Add Money";

    public StateExecuteResults Run()
    {
        double sum = AnsiConsole.Ask<double>("Enter the amount of the charge");
        AddBalanceResult result = _accountsService.AddAccountBalance(sum);

        if (result is AddBalanceResult.IncorrectDepositAmount)
        {
            AnsiConsole.WriteLine("Incorrect Deposit Amount");
            return new StateExecuteResults.RepeatYourState();
        }

        if (result is AddBalanceResult.Success)
        {
            AnsiConsole.WriteLine("The money has been successfully credited");
            return new StateExecuteResults.RepeatYourState();
        }

        AnsiConsole.WriteLine("Wrong");
        return new StateExecuteResults.GoBackToPreviousState();
    }
}
using Contracts.BankSystem;
using Spectre.Console;

namespace Console.States.MainMenuStates;

public class CreateAccountState : IState
{
    private readonly IBankService _bankService;

    public CreateAccountState(IBankService bankService)
    {
        _bankService = bankService;
    }

    public string Name => "Create Account";

    public StateExecuteResults Run()
    {
        int password = AnsiConsole.Ask<int>("Enter your the future pin-code");
        int accountId = _bankService.CreateAccount(password);

        AnsiConsole.WriteLine($@"Your account ID {accountId}");
        return new StateExecuteResults.RepeatYourState();
    }
}
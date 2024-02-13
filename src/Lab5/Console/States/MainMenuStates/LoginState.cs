using Contracts.Account;
using Contracts.BankSystem;
using Spectre.Console;

namespace Console.States.MainMenuStates;

public class LoginState : IState
{
    private readonly IAccountsService _accountsService;
    private readonly IState _nextState;

    public LoginState(IAccountsService accountsService, IState nextState)
    {
        _accountsService = accountsService;
        _nextState = nextState;
    }

    public string Name => "Login in Account";

    public StateExecuteResults Run()
    {
        int username = AnsiConsole.Ask<int>("Enter your account ID");
        int password = AnsiConsole.Ask<int>("Enter your pin-code");

        LoginResult result = _accountsService.Login(username, password);

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.InvalidPassword => "InvalidPassword",
            LoginResult.NotFound => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        if (result is LoginResult.Success)
        {
            _nextState.Run();
        }

        return new StateExecuteResults.RepeatYourState();
    }
}
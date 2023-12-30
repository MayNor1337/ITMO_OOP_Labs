using Contracts.BankSystem;
using Spectre.Console;

namespace Console.States.MainMenuStates;

public class AdminLogin : IState
{
    private readonly IBankService _bankService;
    private readonly IState _nextState;

    public AdminLogin(IBankService bankService, IState nextState)
    {
        _bankService = bankService;
        _nextState = nextState;
    }

    public string Name => "Login in Admin";

    public StateExecuteResults Run()
    {
        int adminId = AnsiConsole.Ask<int>("Enter your admin ID");
        int password = AnsiConsole.Ask<int>("Enter your pin-code");

        LoginResult result = _bankService.LoginToAdminPanel(adminId, password);

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.InvalidPassword => "InvalidPassword",
            LoginResult.NotFound => "User not found",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        if (result is LoginResult.Success)
            _nextState.Run();

        return new StateExecuteResults.RepeatYourState();
    }
}
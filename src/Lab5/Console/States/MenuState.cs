using Spectre.Console;

namespace Console.States;

public abstract class MenuState : IState
{
    private readonly IEnumerable<IState> _nextStates;

    protected MenuState(IEnumerable<IState> nextStates)
    {
        _nextStates = nextStates;
    }

    public abstract string Name { get; }

    public StateExecuteResults Run()
    {
        SelectionPrompt<IState> selector = new SelectionPrompt<IState>()
            .Title("Select action")
            .AddChoices(_nextStates)
            .UseConverter(x => x.Name);

        IState state = AnsiConsole.Prompt(selector);
        StateExecuteResults results = state.Run();

        if (results is StateExecuteResults.RepeatYourState)
            return Run();

        return new StateExecuteResults.RepeatYourState();
    }
}
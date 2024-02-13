namespace Console.States;

public class ExitState : IState
{
    public string Name => "Exit";

    public StateExecuteResults Run()
    {
        return new StateExecuteResults.GoBackToPreviousState();
    }
}
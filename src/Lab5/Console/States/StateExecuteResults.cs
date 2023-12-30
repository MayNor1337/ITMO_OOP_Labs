namespace Console.States;

public abstract record StateExecuteResults
{
    private StateExecuteResults() { }

    public sealed record RepeatYourState : StateExecuteResults;

    public sealed record GoBackToPreviousState : StateExecuteResults;
}
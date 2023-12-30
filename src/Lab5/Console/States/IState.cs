namespace Console.States;

public interface IState
{
    string Name { get; }

    StateExecuteResults Run();
}
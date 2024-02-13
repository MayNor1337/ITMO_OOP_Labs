namespace Console.States.MainMenuStates;

public class MainMenuState : MenuState
{
    public MainMenuState(IEnumerable<IState> nextStates)
        : base(nextStates) { }

    public override string Name => "Main Menu";
}
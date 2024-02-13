namespace Console.States.AdminStates;

public class AdminMenuState : MenuState
{
    public AdminMenuState(IEnumerable<IState> nextStates)
        : base(nextStates) { }

    public override string Name => "AdminMenu";
}
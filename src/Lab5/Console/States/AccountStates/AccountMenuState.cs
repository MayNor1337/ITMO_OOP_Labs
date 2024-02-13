using Console.States.MainMenuStates;

namespace Console.States.AccountStates;

public class AccountMenuState : MainMenuState
{
    public AccountMenuState(IEnumerable<IState> nextStates)
        : base(nextStates) { }

    public override string Name => "Account Menu";
}
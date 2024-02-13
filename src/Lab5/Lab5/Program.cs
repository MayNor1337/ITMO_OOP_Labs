using Console.States;
using Console.States.Factory;

IState mainState = new StandardStatesFactory().CreateStateMachine();

mainState.Run();
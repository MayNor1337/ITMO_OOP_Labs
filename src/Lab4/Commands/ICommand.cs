using Itmo.ObjectOrientedProgramming.Lab4.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface ICommand
{
    ResultExecuteCommand Execute(Context context);
}
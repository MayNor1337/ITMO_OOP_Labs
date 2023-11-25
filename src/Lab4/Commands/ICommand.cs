using Itmo.ObjectOrientedProgramming.Lab4.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface ICommand
{
    ResultExecution Execute(Context context);
}
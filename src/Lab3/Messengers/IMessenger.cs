using Itmo.ObjectOrientedProgramming.Lab3.Outputters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public interface IMessenger : ISendMessage
{
    void Output(IOutputter outputter);
}
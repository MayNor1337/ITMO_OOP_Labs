using Itmo.ObjectOrientedProgramming.Lab3.Outputters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public interface IMessenger : ISendText
{
    void Output(IOutputter outputter);
}
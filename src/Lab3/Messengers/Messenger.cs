using Itmo.ObjectOrientedProgramming.Lab3.Outputters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class Messenger : IMessenger
{
    private string? _lastMessage;

    public void Output(IOutputter outputter)
    {
        if (_lastMessage is null)
            outputter.Output($"Messenger: no messages received");
        else
            outputter.Output($"Messenger: {_lastMessage}");
    }

    public void SendText(string text)
    {
        _lastMessage = text;
    }
}
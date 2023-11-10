using Itmo.ObjectOrientedProgramming.Lab3.Outputters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class Messenger : IMessenger
{
    private string? _lastMessage;

    public void Output(IPrinter printer)
    {
        if (_lastMessage is null)
            printer.Output($"Messenger: no messages received");
        else
            printer.Output($"Messenger: {_lastMessage}");
    }

    public void SendText(string text)
    {
        _lastMessage = text;
    }
}
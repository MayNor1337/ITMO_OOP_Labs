using Itmo.ObjectOrientedProgramming.Lab3.Outputters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class Messenger : IMessenger
{
    private string? _lastMessage;
    private IPrinter _printer;

    public Messenger(IPrinter printer)
    {
        _printer = printer;
    }

    public void Output()
    {
        if (_lastMessage is null)
            _printer.Output($"Messenger: no messages received");
        else
            _printer.Output($"Messenger: {_lastMessage}");
    }

    public void SendText(string text)
    {
        _lastMessage = text;
        _printer.Output(_lastMessage);
    }
}
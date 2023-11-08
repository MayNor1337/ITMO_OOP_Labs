using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Outputters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class Messenger : IMessenger
{
    private IMessage? _lastMessage;

    public void SendMessage(IMessage message)
    {
        _lastMessage = message;
    }

    public void Output(IOutputter outputter)
    {
        if (_lastMessage is null)
            outputter.Output($"Messenger: no messages received");
        else
            outputter.Output($"Messenger: {_lastMessage.Heading} \n {_lastMessage.Body}");
    }
}
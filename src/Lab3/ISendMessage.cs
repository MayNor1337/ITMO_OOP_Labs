using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public interface ISendMessage
{
    void SendMessage(IMessage message);
}
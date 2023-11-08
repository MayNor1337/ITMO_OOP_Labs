namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public interface IMessageStorage
{
    public void AddMessage(IMessage message);

    public void MarkAsRead(IMessage message);

    public FindMessageResult TryFindMessage(IMessage message);
}
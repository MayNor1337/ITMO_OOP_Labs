using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public interface IUser : ISendMessage
{
    public void MarkAsRead(IMessage message);

    public FindMessageResult TryFindMessage(IMessage message);
}
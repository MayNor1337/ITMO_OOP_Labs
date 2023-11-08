using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class User : IUser
{
    private IMessageStorage _messageStorage;

    public User(IMessageStorageCreator messageStorageCreator)
    {
        _messageStorage = messageStorageCreator.CreateNewStorage();
    }

    public void SendMessage(IMessage message)
    {
        _messageStorage.AddMessage(message);
    }

    public void MarkAsRead(IMessage message)
    {
        _messageStorage.MarkAsRead(message);
    }

    public FindMessageResult TryFindMessage(IMessage message)
    {
        return _messageStorage.TryFindMessage(message);
    }
}
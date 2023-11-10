using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class User
{
    private Dictionary<Message, MessageStatus> _messageStorage = new Dictionary<Message, MessageStatus>();

    public virtual void SendMessage(Message message)
    {
        _messageStorage.Add(message, MessageStatus.Unread);
    }

    public virtual ReadMessageResult MarkAsRead(Message message)
    {
        if (_messageStorage.ContainsKey(message) == false)
            return new ReadMessageResult.MessageNotFound();

        if (_messageStorage[message] == MessageStatus.Read)
            return new ReadMessageResult.Wrong();

        _messageStorage[message] = MessageStatus.Read;
        return new ReadMessageResult.MessageReadSuccessfully();
    }

    public virtual FindMessageResult TryFindMessage(Message message)
    {
        return _messageStorage.TryGetValue(message, value: out MessageStatus value)
            ? new FindMessageResult.MessageFoundSuccess(value)
            : new FindMessageResult.MessageNotFound();
    }
}

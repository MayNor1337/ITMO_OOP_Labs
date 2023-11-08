using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class MessageStorage : IMessageStorage
{
    private Dictionary<IMessage, MessageStatus> _messages = new Dictionary<IMessage, MessageStatus>();

    public void AddMessage(IMessage message)
    {
        _messages.Add(message, MessageStatus.Unread);
    }

    public void MarkAsRead(IMessage message)
    {
        if (_messages.ContainsKey(message) == false)
            throw new ArgumentNullException(nameof(message));

        if (_messages[message] is MessageStatus.Read)
            throw new ArgumentException(null, nameof(message));

        _messages[message] = MessageStatus.Read;
    }

    public FindMessageResult TryFindMessage(IMessage message)
    {
        if (_messages.TryGetValue(message, out MessageStatus value))
            return new FindMessageResult.MessageFoundSuccess(value);

        return new FindMessageResult.MessageNotFound();
    }
}
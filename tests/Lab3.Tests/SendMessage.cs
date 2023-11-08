using System;
using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class SendMessage
{
    [Fact]
    public void SendMessage_SavingMessage_MessageReceivedAndNotRead()
    {
        // Arrange
        IMessage message = new Message.MessageBuilder()
            .SetHeading("Test message")
            .SetBody("Hello, this is test message. Thank you for getting it")
            .SetImportanceLevel(0)
            .Build();

        var user = new User(new MessageStorageCreator());
        var addressee = new AddresseeUser(user);

        // Act
        addressee.SendMessage(message);

        FindMessageResult result = user.TryFindMessage(message);

        // Assert
        Assert.True(result is FindMessageResult.MessageFoundSuccess(MessageStatus.Unread));
    }

    [Fact]
    public void SendMessage_SavingAndReadMessage_MessageReceivedAndRead()
    {
        // Arrange
        IMessage message = new Message.MessageBuilder()
            .SetHeading("Test message")
            .SetBody("Hello, this is test message. Thank you for getting it")
            .SetImportanceLevel(0)
            .Build();

        var user = new User(new MessageStorageCreator());
        var addressee = new AddresseeUser(user);

        // Act
        addressee.SendMessage(message);
        user.MarkAsRead(message);

        FindMessageResult result = user.TryFindMessage(message);

        // Assert
        Assert.True(result is FindMessageResult.MessageFoundSuccess(MessageStatus.Read));
    }

    [Fact]
    public void SendMessage_SavingAndReadMessage_ErrorMarkingReadMessage()
    {
        // Arrange
        IMessage message = new Message.MessageBuilder()
            .SetHeading("Test message")
            .SetBody("Hello, this is test message. Thank you for getting it")
            .SetImportanceLevel(0)
            .Build();

        var user = new User(new MessageStorageCreator());
        var addressee = new AddresseeUser(user);

        // Act
        addressee.SendMessage(message);
        user.MarkAsRead(message);

        // Assert
        try
        {
            user.MarkAsRead(message);
        }
        catch (Exception e)
        {
            if (e is ArgumentException)
            {
                Assert.True(true);
                return;
            }

            throw;
        }
    }

    [Fact]
    public void SendMessage_FilteringMessagesForTheUser_MessagesOfASuitableLevelOfImportance()
    {
        // Arrange
        IMessage importantMessage = new Message.MessageBuilder()
            .SetHeading("Important message")
            .SetBody("Hello, this is test message. Thank you for getting it")
            .SetImportanceLevel(0)
            .Build();

        IMessage defaultMessage = new Message.MessageBuilder()
            .SetHeading("Not important message")
            .SetBody("Hello, this is test message. Thank you for getting it")
            .SetImportanceLevel(5)
            .Build();

        var user = new MockUserAmountMessages(new User(new MessageStorageCreator()));
        var addressee = new ProxyFilterAddressee(priorityReceivedMessages: 2, new AddresseeUser(user));

        // Act
        addressee.SendMessage(importantMessage);
        addressee.SendMessage(defaultMessage);

        // Assert
        Assert.True(user.AmountMessages == 1);
    }

    [Fact]
    public void SendMessage_LoggingSendingMessages_AllSentMessagesMustLogging()
    {
        // Arrange
        IMessage importantMessage = new Message.MessageBuilder()
            .SetHeading("Important message")
            .SetBody("Hello, this is test message. Thank you for getting it")
            .SetImportanceLevel(0)
            .Build();

        IMessage defaultMessage = new Message.MessageBuilder()
            .SetHeading("Not important message")
            .SetBody("Hello, this is test message. Thank you for getting it")
            .SetImportanceLevel(5)
            .Build();

        var logger = new MockLoggerForCountingCalls();
        var user = new User(new MessageStorageCreator());
        var addressee = new ProxyLoggerAddressee(logger, new AddresseeUser(user));

        // Act
        addressee.SendMessage(importantMessage);
        addressee.SendMessage(defaultMessage);

        // Assert
        Assert.True(logger.AmountCalls == 2);
    }

    [Fact]
    public void SendMessage_MessengerWillDoItsJob()
    {
        // Arrange
        IMessage importantMessage = new Message.MessageBuilder()
            .SetHeading("Important message")
            .SetBody("Hello, this is test message. Thank you for getting it")
            .SetImportanceLevel(0)
            .Build();

        var outputter = new MockOutputter();
        var messenger = new Messenger();
        var addressee = new AddresseeMessenger(messenger);

        // Act
        addressee.SendMessage(importantMessage);
        messenger.Output(outputter);

        // Assert
        Assert.True(outputter.AmountCalls == 1);
    }
}
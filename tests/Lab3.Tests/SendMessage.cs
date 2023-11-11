using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.Users;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class SendMessage
{
    [Fact]
    public void SendMessage_ShouldBeSaved_IfSend()
    {
        // Arrange
        var message = new Message(
            "Important message",
            "Hello, this is test message. Thank you for getting it",
            0);

        var user = new User();
        var addressee = new AddresseeUser(user);

        // Act
        addressee.SendMessage(message);

        FindMessageResult result = user.TryFindMessage(message);

        // Assert
        Assert.True(result is FindMessageResult.MessageFoundSuccess(MessageStatus.Unread));
    }

    [Fact]
    public void SendMessage_ShouldBeSavingAndRead_IfReadMessageOnce()
    {
        // Arrange
        var message = new Message(
            "Important message",
            "Hello, this is test message. Thank you for getting it",
            0);

        var user = new User();
        var addressee = new AddresseeUser(user);

        // Act
        addressee.SendMessage(message);
        user.MarkAsRead(message);

        FindMessageResult result = user.TryFindMessage(message);

        // Assert
        Assert.True(result is FindMessageResult.MessageFoundSuccess(MessageStatus.Read));
    }

    [Fact]
    public void SendMessage_ErrorShouldOccur_ReadMessageMoreThanOnce()
    {
        // Arrange
        var message = new Message(
            "Important message",
            "Hello, this is test message. Thank you for getting it",
            0);

        var user = new User();
        var addressee = new AddresseeUser(user);

        // Act
        addressee.SendMessage(message);
        user.MarkAsRead(message);

        // Assert
        ReadMessageResult result = user.MarkAsRead(message);
        Assert.True(result is ReadMessageResult.Wrong);
    }

    [Fact]
    public void SendMessage_ShouldBeIgnore_WhenPriorityIsLow()
    {
        // Arrange
        var importantMessage = new Message(
            "Important message",
            "Hello, this is test message. Thank you for getting it",
            0);

        var defaultMessage = new Message(
            "Not important message",
            "Hello, this is test message. Thank you for getting it",
            1);

        var user = new MockUserAmountMessages(new User());
        var addressee = new ProxyFilterAddressee(priorityReceivedMessages: 2, new AddresseeUser(user));

        // Act
        addressee.SendMessage(importantMessage);
        addressee.SendMessage(defaultMessage);

        // Assert
        Assert.True(user.AmountMessages == 0);
    }

    [Fact]
    public void SendMessage_AllMessagesWillBeLogging_WhenWeLoggingAllMessage()
    {
        // Arrange
        var importantMessage = new Message(
            "Important message",
            "Hello, this is test message. Thank you for getting it",
            0);

        var defaultMessage = new Message(
            "Not important message",
            "Hello, this is test message. Thank you for getting it",
            5);

        var logger = new MockLoggerForCountingCalls();
        var user = new User();
        var addressee = new AddresseeWithLogger(logger, new AddresseeUser(user));

        // Act
        addressee.SendMessage(importantMessage);
        addressee.SendMessage(defaultMessage);

        // Assert
        Assert.True(logger.AmountCalls == 2);
    }

    [Fact]
    public void Output_MessengerWillDisplayText_WhenExistingOutput()
    {
        // Arrange
        var importantMessage = new Message(
            "Important message",
            "Hello, this is test message. Thank you for getting it",
            0);
        string referenceString = "Messenger: Important message\nHello, this is test message. Thank you for getting it";

        var stream = new VirtualOutput();
        var outputter = new MockPrinter(stream);
        var messenger = new Messenger();
        var addressee = new AddresseeMessenger(messenger);

        // Act
        addressee.SendMessage(importantMessage);
        messenger.Output(outputter);

        // Assert
        Assert.True(stream.Output.Contains(referenceString));
    }
}
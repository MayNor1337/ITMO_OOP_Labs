using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MockUserAmountMessages : IUser
{
    private IUser _user;

    public MockUserAmountMessages(IUser user)
    {
        _user = user;
    }

    public int AmountMessages { get; private set; }

    public void SendMessage(IMessage message)
    {
        _user.SendMessage(message);
        AmountMessages++;
    }

    public void MarkAsRead(IMessage message)
    {
        _user.MarkAsRead(message);
    }

    public FindMessageResult TryFindMessage(IMessage message)
    {
        return _user.TryFindMessage(message);
    }
}
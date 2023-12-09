using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MockUserAmountMessages : User
{
    private readonly User _user;

    public MockUserAmountMessages(User user)
    {
        _user = user;
    }

    public int AmountMessages { get; private set; }

    public override void SendMessage(Message message)
    {
        _user.SendMessage(message);
        AmountMessages++;
    }

    public override ReadMessageResult MarkAsRead(Message message)
    {
        return _user.MarkAsRead(message);
    }

    public override FindMessageResult TryFindMessage(Message message)
    {
        return _user.TryFindMessage(message);
    }
}
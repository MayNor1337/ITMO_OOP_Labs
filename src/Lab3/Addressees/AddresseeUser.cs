using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class AddresseeUser : IAddressee
{
    private IUser _user;

    public AddresseeUser(IUser user)
    {
        _user = user;
    }

    public void SendMessage(IMessage message)
    {
        _user.SendMessage(message);
    }
}
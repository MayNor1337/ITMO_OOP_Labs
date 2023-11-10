using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class AddresseeGroup : IAddressee
{
    private readonly IEnumerable<IAddressee> _addressees;

    public AddresseeGroup(IEnumerable<IAddressee> addressees)
    {
        _addressees = addressees;
    }

    public void SendMessage(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.SendMessage(message);
        }
    }
}
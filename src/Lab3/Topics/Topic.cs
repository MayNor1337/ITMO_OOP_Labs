using Itmo.ObjectOrientedProgramming.Lab3.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class Topic : ITopic
{
    private readonly IAddressee _addressees;

    public Topic(IAddressee addressees)
    {
        _addressees = addressees;
    }

    public void SendMessage(Message message)
    {
        _addressees.SendMessage(message);
    }
}
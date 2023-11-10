using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class ProxyFilterAddressee : IAddressee
{
    private readonly int _priorityReceivedMessages;
    private readonly IAddressee _addressee;

    public ProxyFilterAddressee(int priorityReceivedMessages, IAddressee addressee)
    {
        _priorityReceivedMessages = priorityReceivedMessages;
        _addressee = addressee;
    }

    public void SendMessage(Message message)
    {
        if (message.ImportanceLevel >= _priorityReceivedMessages)
        {
            _addressee.SendMessage(message);
        }
    }
}
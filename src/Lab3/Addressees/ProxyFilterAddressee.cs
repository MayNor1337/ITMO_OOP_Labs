using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class ProxyFilterAddressee : IAddressee
{
    private int _priorityReceivedMessages;
    private IAddressee _addressee;

    public ProxyFilterAddressee(int priorityReceivedMessages, IAddressee addressee)
    {
        _priorityReceivedMessages = priorityReceivedMessages;
        _addressee = addressee;
    }

    public void SendMessage(IMessage message)
    {
        if (message.ImportanceLevel < _priorityReceivedMessages)
        {
            _addressee.SendMessage(message);
        }
    }
}
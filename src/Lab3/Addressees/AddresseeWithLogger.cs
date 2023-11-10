using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class AddresseeWithLogger : IAddressee
{
    private readonly ILogger _logger;
    private readonly IAddressee _addressee;

    public AddresseeWithLogger(ILogger logger, IAddressee addressee)
    {
        _logger = logger;
        _addressee = addressee;
    }

    public void SendMessage(Message message)
    {
        _addressee.SendMessage(message);
        _logger.Log($"{message.Heading}\n{message.Body}");
    }
}
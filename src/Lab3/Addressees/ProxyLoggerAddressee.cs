using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class ProxyLoggerAddressee : ISendMessage
{
    private ILogger _logger;
    private IAddressee _addressee;

    public ProxyLoggerAddressee(ILogger logger, IAddressee addressee)
    {
        _logger = logger;
        _addressee = addressee;
    }

    public void SendMessage(IMessage message)
    {
        _addressee.SendMessage(message);
        _logger.Log($"{message.Heading}\n{message.Body}");
    }
}
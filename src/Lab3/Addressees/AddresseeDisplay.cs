using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressees;

public class AddresseeDisplay : IAddressee
{
    private readonly IDisplay _display;

    public AddresseeDisplay(IDisplay display)
    {
        _display = display;
    }

    public void SendMessage(Message message)
    {
        _display.SendText($"{message.Heading}\n{message.Body}");
        _display.DisplayMessage();
    }
}
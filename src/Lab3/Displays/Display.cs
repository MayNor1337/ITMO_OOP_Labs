using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Outputters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display : IDisplay
{
    private IDisplayDriver _displayDriver;
    private IMessage? _lastMessage;

    public Display(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void SendMessage(IMessage message)
    {
        _lastMessage = message;
    }

    public void DisplayMessage(IOutputter outputter, Color color)
    {
        if (_lastMessage is null)
            throw new ArgumentException(nameof(_lastMessage));

        _displayDriver.Clear();
        _displayDriver.SetColor(color);
        _displayDriver.WriteText($"{_lastMessage.Heading}\n{_lastMessage.Body}", outputter);
    }
}
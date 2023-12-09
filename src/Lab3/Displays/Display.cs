using System;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display : IDisplay
{
    private readonly IDisplayDriver _displayDriver;
    private string? _lastMessage;

    public Display(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void SendText(string text)
    {
        _lastMessage = text;
    }

    public void DisplayMessage()
    {
        if (_lastMessage is null)
            throw new ArgumentException(nameof(_lastMessage));

        _displayDriver.Clear();
        _displayDriver.WriteText($"{_lastMessage}");
    }

    public void SetColor(Color color)
    {
        _displayDriver.SetColor(color);
    }
}
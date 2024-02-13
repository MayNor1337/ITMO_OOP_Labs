using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplay
{
    void DisplayMessage();

    void SetColor(Color color);

    public void SendText(string text);
}
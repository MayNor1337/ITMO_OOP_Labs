using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplay : ISendText
{
    void DisplayMessage();

    void SetColor(Color color);
}
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Outputters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplay : ISendMessage
{
    void DisplayMessage(IOutputter outputter, Color color);
}
using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Outputters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class DisplayDriver : IDisplayDriver
{
    private Color _color;
    public void Clear()
    {
        Console.Clear();
    }

    public void SetColor(Color color)
    {
        _color = color;
    }

    public void WriteText(string text, IOutputter outputter)
    {
        outputter.Output(Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(text));
    }
}
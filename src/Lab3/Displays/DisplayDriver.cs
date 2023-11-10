using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Outputters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class DisplayDriver : IDisplayDriver
{
    private readonly IOutputter _outputter;
    private Color _color;

    public DisplayDriver(IOutputter outputter, Color color)
    {
        _color = color;
        _outputter = outputter;
    }

    public void Clear()
    {
        Console.Clear();
    }

    public void SetColor(Color color)
    {
        _color = color;
    }

    public void WriteText(string text)
    {
        _outputter.Output(Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(text));
    }
}
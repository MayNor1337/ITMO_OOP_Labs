﻿using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public interface IDisplayDriver
{
    public void Clear();

    public void SetColor(Color color);

    public void WriteText(string text);
}
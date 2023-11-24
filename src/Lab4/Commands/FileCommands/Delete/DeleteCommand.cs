﻿using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.Delete;

public class DeleteCommand : ICommand
{
    private string _path;

    public DeleteCommand(string path)
    {
        _path = path;
    }

    public void Execute(IContext context)
    {
        string path = context.NowAddress + _path;
        File.Delete(path);
    }
}
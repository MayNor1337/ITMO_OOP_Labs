﻿using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.MoveCommands;

public class MoveCommand : ICommand
{
    private string _sourcePath;
    private string _destinationPath;

    public MoveCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public void Execute(IContext context)
    {
        string path = context.NowAddress + _sourcePath;
        string destinationPath = context.NowAddress + _destinationPath;

        File.Move(path, destinationPath);
    }
}
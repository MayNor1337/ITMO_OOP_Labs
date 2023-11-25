using System;
using System.IO;
using System.Linq;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.ShowCommands;

public class ShowConsoleModeCommand : ICommand
{
    private string _path;
    private string[] _supportedFileTypes = new[] { "txt" };

    public ShowConsoleModeCommand(string path)
    {
        _path = path;
    }

    public void Execute(Context context)
    {
        string path = context.NowAddress + _path;
        if (_supportedFileTypes.Contains(GetFileExtension(path)))
            return;

        if (context.FileSystem is null)
            return;

        StreamReader file = context.FileSystem.Open(path);

        while (file.EndOfStream == false)
        {
            string? line = file.ReadLine();
            Console.WriteLine(line);
        }

        context.FileSystem.Close(file);
    }

    private static string GetFileExtension(string path)
    {
        var sb = new StringBuilder(path);
        int count = sb.Length - 1;

        while (count != 0 && sb[count] != '.')
            count--;

        return sb.ToString(count + 1, sb.Length - count);
    }
}
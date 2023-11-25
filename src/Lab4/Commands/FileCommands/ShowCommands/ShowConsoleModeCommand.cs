using System;
using System.IO;
using System.Linq;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.ListCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Contexts;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands.ShowCommands;

public class ShowConsoleModeCommand : ICommand
{
    private string _path;
    private IPrinter _printer;
    private string[] _supportedFileTypes = new[] { "txt" };

    public ShowConsoleModeCommand(string path, IPrinter printer)
    {
        _path = path;
        _printer = printer;
    }

    public ResultExecuteCommand Execute(Context context)
    {
        string path = context.NowAddress + _path;

        if (context.FileSystem is null)
            return new ResultExecuteCommand.CommandExecutionError(ErrorDescriptions.NoConnection());

        if (_supportedFileTypes.Contains(context.FileSystem.GetFileExtension(path)) == false)
            return new ResultExecuteCommand.CommandExecutionError(ErrorDescriptions.FileFormatNotSupported());

        using var reader = new StreamReader(context.FileSystem.Open(path), Encoding.UTF8);

        string content = reader.ReadToEnd();
        _printer.Print(content);

        return new ResultExecuteCommand.CommandWasExecutedCorrectly();
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
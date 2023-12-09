using Itmo.ObjectOrientedProgramming.Lab4.Contexts.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Contexts;

public class Context
{
    public string NowAddress { get; set; } = string.Empty;

    public IFileSystem? FileSystem { get; set; }
}
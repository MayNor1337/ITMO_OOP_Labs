using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Contexts.FileSystems;

public interface IFileSystem
{
    bool Exists(string path);

    void Copy(string firstPath, string secondPath);

    void Delete(string path);

    void Move(string firstPath, string secondPath);

    StreamReader Open(string path);

    void Close(StreamReader file);
}
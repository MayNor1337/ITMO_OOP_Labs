using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Contexts.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public bool Exists(string path)
    {
        return File.Exists(path);
    }

    public void Copy(string firstPath, string secondPath)
    {
        File.Copy(firstPath, secondPath);
    }

    public void Delete(string path)
    {
        File.Delete(path);
    }

    public void Move(string firstPath, string secondPath)
    {
        File.Move(firstPath, secondPath);
    }

    public StreamReader Open(string path)
    {
        return new StreamReader(path);
    }

    public void Close(StreamReader file)
    {
        file.Close();
    }
}
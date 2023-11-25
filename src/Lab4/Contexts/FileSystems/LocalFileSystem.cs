using System.IO;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab4.Contexts.FileSystems;

public class LocalFileSystem : IFileSystem
{
    public bool ExistsFile(string path)
    {
        return File.Exists(path);
    }

    public bool ExistsDirectory(string path)
    {
        throw new System.NotImplementedException();
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

    public Stream Open(string path)
    {
        return new FileStream(path, FileMode.Open, FileAccess.Read);
    }

    public string[] GetFiles(string path)
    {
        return Directory.GetFiles(path);
    }

    public string[] GetDirectories(string path)
    {
        return Directory.GetDirectories(path);
    }

    public string MergePaths(string path, string folderName)
    {
        return path + '\\' + folderName;
    }

    public string GetDirectoryName(string path)
    {
        int i = path.Length - 1;
        var sb = new StringBuilder();
        while (path[i] != '\\' && path[i] != '/' && i != 0)
            sb.Append(path[i]);

        return sb.ToString();
    }

    public string GetFileExtension(string path)
    {
        int i = path.Length - 1;
        var sb = new StringBuilder();
        while (path[i] != '.' && i != 0)
            sb.Append(path[i]);

        return sb.ToString();
    }
}
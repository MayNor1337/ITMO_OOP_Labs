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
        return Directory.Exists(path);
    }

    public ResultExecution Copy(string firstPath, string secondPath)
    {
        if (File.Exists(firstPath) is false)
            return new ResultExecution.FileDoesNotExist();

        if (Directory.Exists(secondPath) is false)
            return new ResultExecution.DirectoryDoesNotExist();

        File.Copy(firstPath, secondPath);

        return new ResultExecution.Successes();
    }

    public ResultExecution Delete(string path)
    {
        if (File.Exists(path) is false)
            return new ResultExecution.FileDoesNotExist();

        File.Delete(path);

        return new ResultExecution.Successes();
    }

    public ResultExecution Move(string firstPath, string secondPath)
    {
        if (File.Exists(firstPath) is false)
            return new ResultExecution.FileDoesNotExist();

        if (Directory.Exists(secondPath) is false)
            return new ResultExecution.DirectoryDoesNotExist();

        File.Move(firstPath, secondPath);

        return new ResultExecution.Successes();
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
            sb.Append(path[i--]);

        return sb.ToString();
    }

    public string GetFileExtension(string path)
    {
        int i = path.Length - 1;
        var sb = new StringBuilder();
        while (path[i] != '.' && i != 0)
            sb.Append(path[i--]);

        return sb.ToString();
    }
}
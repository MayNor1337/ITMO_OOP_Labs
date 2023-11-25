﻿using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Contexts.FileSystems;

public interface IFileSystem
{
    bool ExistsFile(string path);

    bool ExistsDirectory(string path);

    void Copy(string firstPath, string secondPath);

    void Delete(string path);

    void Move(string firstPath, string secondPath);

    Stream Open(string path);

    string[] GetFiles(string path);

    string[] GetDirectories(string path);

    string MergePaths(string path, string folderName);

    string GetDirectoryName(string path);

    string GetFileExtension(string path);
}
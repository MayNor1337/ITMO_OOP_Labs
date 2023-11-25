using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Configs;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.Factory;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class CommandParser
{
    public static IEnumerable<object[]> LocalConnectCommand =>
        new List<object[]>
        {
            new object[]
            {
                @"connect ahuennieTest\SuperTest -m local",
            },
        };

    public static IEnumerable<object[]> DisconnectCommand =>
        new List<object[]>
        {
            new object[]
            {
                @"disconnect",
            },
        };

    public static IEnumerable<object[]> TreeGotoCommand =>
        new List<object[]>
        {
            new object[]
            {
                @"tree goto ahuennieTest\SuperTest",
            },
        };

    public static IEnumerable<object[]> TreeListCommand =>
        new List<object[]>
        {
            new object[]
            {
                @"tree list",
            },
        };

    public static IEnumerable<object[]> FileShowCommand =>
        new List<object[]>
        {
            new object[]
            {
                @"file show ahuennieTest\SuperTest -m console",
            },
        };

    public static IEnumerable<object[]> FileMoveCommand =>
        new List<object[]>
        {
            new object[]
            {
                @"file move ahuennieTest\SuperTest badTest\NeSuperTest",
            },
        };

    public static IEnumerable<object[]> FileCopyCommand =>
        new List<object[]>
        {
            new object[]
            {
                @"file copy ahuennieTest\SuperTest badTest\NeSuperTest",
            },
        };

    public static IEnumerable<object[]> FileDeleteCommand =>
        new List<object[]>
        {
            new object[]
            {
                @"file delete ahuennieTest\SuperTest",
            },
        };

    public static IEnumerable<object[]> FileRenameCommand =>
        new List<object[]>
        {
            new object[]
            {
                @"file delete ahuennieTest\SuperTest SuperFile",
            },
        };

    [Theory]
    [MemberData(nameof(LocalConnectCommand))]
    [MemberData(nameof(DisconnectCommand))]
    [MemberData(nameof(TreeGotoCommand))]
    [MemberData(nameof(TreeListCommand))]
    [MemberData(nameof(FileShowCommand))]
    [MemberData(nameof(FileMoveCommand))]
    [MemberData(nameof(FileDeleteCommand))]
    [MemberData(nameof(FileRenameCommand))]
    public void Handle_ShouldCreateCommand_WhenInputCorrect(string data)
    {
        // Arrange
        ICommandParser parser = new ParserFactory(new ConfigModel()).CreateParser();

        // Act
        CommandBuildResult commandBuildResult = parser.Handle(new StringIterator(data));

        // Assert
        Assert.IsType<CommandBuildResult.Successfully>(commandBuildResult);
    }
}
using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.ListCommands.Components;

public class FileComponent : IVisitorComponent
{
    public FileComponent(string name, int depth)
    {
        Name = name;
        Depth = depth;
    }

    public string Name { get; private set; }
    public int Depth { get; private set; }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
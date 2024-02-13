using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands.ListCommands.Components;

public class DirectoryComponent : IVisitorComponent
{
    private IVisitorComponent[] _children;

    public DirectoryComponent(IEnumerable<IVisitorComponent> children, string name, int depth)
    {
        _children = children.ToArray();
        Name = name;
        Depth = depth;
    }

    public string Name { get; private set; }
    public int Depth { get; private set; }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);

        foreach (IVisitorComponent child in _children)
        {
            child.Accept(visitor);
        }
    }
}
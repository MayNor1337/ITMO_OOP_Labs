namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor;

public interface IVisitorComponent
{
    void Accept(IVisitor visitor);
}
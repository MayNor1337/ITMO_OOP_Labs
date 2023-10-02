namespace Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

public interface IDeflector : IDamageable
{
    public bool IsWorks { get; protected set; }
}
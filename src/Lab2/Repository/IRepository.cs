using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public interface IRepository<T>
    where T : IComponent
{
    IEnumerable<T> Values { get; }

    void Add(T component);
}
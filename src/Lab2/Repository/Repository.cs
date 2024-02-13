using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repository;

public class Repository<T> : IRepository<T>
    where T : IComponent
{
    private readonly List<T> _components;

    public Repository()
    {
        _components = new List<T>();
    }

    public IEnumerable<T> Values => _components;

    public void Add(T component)
    {
        _components.Add(component);
    }
}
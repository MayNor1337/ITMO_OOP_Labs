using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public sealed class ResultsData
{
    public ResultsData()
    {
        Fuel = new Collection<Fuel>();
        Time = 0;
    }

    public Collection<Fuel> Fuel { get; }
    public float Time { get; set; }

    public void AddFuel(Fuel fuel)
    {
        if (fuel == null)
            return;

        Fuel.Add(fuel);
    }
}
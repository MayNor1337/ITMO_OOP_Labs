using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public record EngineOperationData
{
    public EngineOperationData(IFuel fuel, float time)
    {
        Fuel = fuel;
        Time = time;
    }

    public IFuel Fuel { get; private set; }
    public float Time { get; private set; }
}
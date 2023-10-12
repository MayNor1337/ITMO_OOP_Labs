using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Fuel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public interface IImpulsiveEngine
{
    public IFuel CalculatingCostsForPath(int length, out float time);
}
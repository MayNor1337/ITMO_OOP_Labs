using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;

public interface IPowerSupply : IPowerSupplyDebuilder, IComponent
{
    int PeakLoad { get; }
    int MaximumRcommendedLoad { get; }
}
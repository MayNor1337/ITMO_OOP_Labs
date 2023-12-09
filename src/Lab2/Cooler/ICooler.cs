using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Cooler;

public interface ICooler : ICoolerDebuilder, IComponent
{
    double Height { get; }
    IEnumerable<string> SupportedSocets { get; }
    int MaxTDP { get; }
}
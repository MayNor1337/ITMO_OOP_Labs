using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Cooler;

public interface ICoolerBuilder
{
    ICoolerBuilder SetHeight(double height);

    ICoolerBuilder SetSupportedSocets(IEnumerable<string> supportedSocets);

    ICoolerBuilder SetMaxTDP(int maxTDP);

    ICooler Build();
}
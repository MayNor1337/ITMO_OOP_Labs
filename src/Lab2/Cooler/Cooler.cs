using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Cooler;

public class Cooler : ICooler
{
    internal Cooler(double height, IEnumerable<string> supportedSocets, int maxTdp)
    {
        Height = height;
        SupportedSocets = supportedSocets.ToList();
        MaxTDP = maxTdp;
    }

    public double Height { get; }
    public IEnumerable<string> SupportedSocets { get; }
    public int MaxTDP { get; }

    public ICoolerBuilder Debuilder()
    {
        return new CoolerBuilder().SetHeight(Height)
            .SetSupportedSocets(SupportedSocets)
            .SetMaxTDP(MaxTDP);
    }
}
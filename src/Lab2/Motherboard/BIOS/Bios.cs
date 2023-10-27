using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard.BIOS;

public class Bios
{
    public Bios(string type, string version, IEnumerable<string> supportedCpu)
    {
        Type = type;
        Version = version;
        SupportedCpu = supportedCpu;
    }

    public string Type { get; }
    public string Version { get; }
    public IEnumerable<string> SupportedCpu { get; }
}
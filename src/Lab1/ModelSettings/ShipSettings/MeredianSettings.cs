using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships.Component;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

namespace Itmo.ObjectOrientedProgramming.Lab1.ModelSettings.ShipSettings;

public record MeredianSettings
{
    private const int DeflectorRang = 2;
    private const bool IsGavePhotonDeflector = false;
    private const int CaseRang = 2;
    private const bool HaveAntiNetrinEmmiter = true;

    public static bool AntiNetrinEmmiter { get; } = HaveAntiNetrinEmmiter;

    public static IEngine[] GetEngine()
    {
        var engines = new IEngine[] { new ImpulsiveEngineE() };
        return engines;
    }

    public static Deflector Deflector()
    {
        var deflector = new Deflector(DeflectorRang, IsGavePhotonDeflector);
        return deflector;
    }

    public static CaseStrength CaseStrength()
    {
        var caseStrength = new CaseStrength(CaseRang);
        return caseStrength;
    }
}
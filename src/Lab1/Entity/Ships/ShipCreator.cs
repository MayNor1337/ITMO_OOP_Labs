using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships.Component;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;

public static class ShipCreator
{
    public static Ship CreatePleasureShuttle()
    {
        var engines = new IEngine[] { new ImpulsiveEngineС() };
        int deflectorRang = 0;
        bool isGavePhotonDeflector = false;
        int caseRang = 1;
        bool haveAntiNetrinEmmiter = false;

        var deflector = new Deflector(deflectorRang, isGavePhotonDeflector);
        var corpus = new CaseStrength(caseRang);
        return new Ship(engines, deflector, corpus, haveAntiNetrinEmmiter);
    }

    public static Ship CreateVaclas()
    {
        var engines = new IEngine[] { new ImpulsiveEngineE(), new GammaEngine() };
        int deflectorRang = 1;
        bool isGavePhotonDeflector = false;
        int caseRang = 2;
        bool haveAntiNetrinEmmiter = false;

        var deflector = new Deflector(deflectorRang, isGavePhotonDeflector);
        var corpus = new CaseStrength(caseRang);
        return new Ship(engines, deflector, corpus, haveAntiNetrinEmmiter);
    }

    public static Ship CreateMerediane()
    {
        var engines = new IEngine[] { new ImpulsiveEngineE() };
        int deflectorRang = 2;
        bool havePhotonDeflector = false;
        int caseRang = 2;
        bool haveAntiNetrinEmmiter = true;

        var deflector = new Deflector(deflectorRang, havePhotonDeflector);
        var corpus = new CaseStrength(caseRang);
        return new Ship(engines, deflector, corpus, haveAntiNetrinEmmiter);
    }

    public static Ship CreateStella()
    {
        var engines = new IEngine[] { new ImpulsiveEngineС(), new OmegaEngine() };
        int deflectorRang = 1;
        bool havePhotonDeflector = false;
        int caseRang = 1;
        bool haveAntiNetrinEmmiter = false;

        var deflector = new Deflector(deflectorRang, havePhotonDeflector);
        var corpus = new CaseStrength(caseRang);
        return new Ship(engines, deflector, corpus, haveAntiNetrinEmmiter);
    }

    public static Ship CreateAvgur()
    {
        var engines = new IEngine[] { new ImpulsiveEngineС(), new AlphaEngine() };
        int deflectorRang = 3;
        bool havePhotonDeflector = false;
        int caseRang = 3;
        bool haveAntiNetrinEmmiter = false;

        var deflector = new Deflector(deflectorRang, havePhotonDeflector);
        var corpus = new CaseStrength(caseRang);
        return new Ship(engines, deflector, corpus, haveAntiNetrinEmmiter);
    }
}
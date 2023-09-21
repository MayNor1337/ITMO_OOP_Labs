using Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships.Component;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entity.Ships;

public static class ShipCreator
{
    public static Ship CreatePleasureShuttle(
        bool isGavePhotonDeflector = false)
    {
        var engines = new IEngine[] { new ImpulsiveEngineС() };
        int deflectorRang = 0;
        int caseRang = 1;
        bool haveAntiNetrinEmmiter = false;

        var deflector = new Deflector(deflectorRang, isGavePhotonDeflector);
        var corpus = new CaseStrength(caseRang);
        return new Ship(engines, deflector, corpus, haveAntiNetrinEmmiter);
    }

    public static Ship CreateVaclas(
        bool isGavePhotonDeflector = false)
    {
        var engines = new IEngine[] { new ImpulsiveEngineE(), new GammaEngine() };
        int deflectorRang = 1;
        int caseRang = 2;
        bool haveAntiNetrinEmmiter = false;

        var deflector = new Deflector(deflectorRang, isGavePhotonDeflector);
        var corpus = new CaseStrength(caseRang);
        return new Ship(engines, deflector, corpus, haveAntiNetrinEmmiter);
    }

    public static Ship CreateMerediane(
        bool havePhotonDeflector = false)
    {
        var engines = new IEngine[] { new ImpulsiveEngineE() };
        int deflectorRang = 2;
        int caseRang = 2;
        bool haveAntiNetrinEmmiter = true;

        var deflector = new Deflector(deflectorRang, havePhotonDeflector);
        var corpus = new CaseStrength(caseRang);
        return new Ship(engines, deflector, corpus, haveAntiNetrinEmmiter);
    }

    public static Ship CreateStella(
        bool havePhotonDeflector = false)
    {
        var engines = new IEngine[] { new ImpulsiveEngineС(), new OmegaEngine() };
        int deflectorRang = 1;
        int caseRang = 1;
        bool haveAntiNetrinEmmiter = false;

        var deflector = new Deflector(deflectorRang, havePhotonDeflector);
        var corpus = new CaseStrength(caseRang);
        return new Ship(engines, deflector, corpus, haveAntiNetrinEmmiter);
    }

    public static Ship CreateAvgur(
        bool havePhotonDeflector = false)
    {
        var engines = new IEngine[] { new ImpulsiveEngineС(), new AlphaEngine() };
        int deflectorRang = 3;
        int caseRang = 3;
        bool haveAntiNetrinEmmiter = false;

        var deflector = new Deflector(deflectorRang, havePhotonDeflector);
        var corpus = new CaseStrength(caseRang);
        return new Ship(engines, deflector, corpus, haveAntiNetrinEmmiter);
    }
}
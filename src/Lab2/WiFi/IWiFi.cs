using Itmo.ObjectOrientedProgramming.Lab2.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.WiFi;

public interface IWiFi : IConsumeEnergy, IWiFiDebuilder, IComponent
{
    double VersionWiFi { get; }
    double VersionPcie { get; }
}
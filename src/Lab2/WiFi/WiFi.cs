namespace Itmo.ObjectOrientedProgramming.Lab2.WiFi;

public class WiFi : IWiFi
{
    public WiFi(double versionWiFi, double versionPcie, int powerConsumption)
    {
        VersionWiFi = versionWiFi;
        VersionPcie = versionPcie;
        PowerConsumption = powerConsumption;
    }

    public double VersionWiFi { get; }
    public double VersionPcie { get; }
    public int PowerConsumption { get; }

    public IWiFiBuilder Debuild()
    {
        return new WiFiBuilder().SetVersionWiFi(VersionWiFi)
            .SetVersionPcie(VersionPcie)
            .SetPowerConsumption(PowerConsumption);
    }
}
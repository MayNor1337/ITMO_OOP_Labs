namespace Itmo.ObjectOrientedProgramming.Lab2.WiFi;

public interface IWiFiBuilder
{
    IWiFiBuilder SetVersionWiFi(double versionWiFi);

    IWiFiBuilder SetVersionPcie(double versionPcie);

    IWiFiBuilder SetPowerConsumption(int powerConsumption);

    IWiFi Build();
}
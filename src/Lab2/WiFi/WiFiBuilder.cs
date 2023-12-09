using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.WiFi;

public class WiFiBuilder : IWiFiBuilder
{
    private double? _versionWiFi;
    private double? _versionPcie;
    private int? _powerConsumption;

    public IWiFiBuilder SetVersionWiFi(double versionWiFi)
    {
        _versionWiFi = versionWiFi;
        return this;
    }

    public IWiFiBuilder SetVersionPcie(double versionPcie)
    {
        _versionPcie = versionPcie;
        return this;
    }

    public IWiFiBuilder SetPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public IWiFi Build()
    {
        return new WiFi(
            _versionWiFi ?? throw new ArgumentNullException(nameof(_versionWiFi)),
            _versionPcie ?? throw new ArgumentNullException(nameof(_versionPcie)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}
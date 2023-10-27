namespace Itmo.ObjectOrientedProgramming.Lab2.RAM.XMP;

public class Xmp : IXmp
{
    public Xmp(int cas, int precharge, int tras, int rc, int voltage, int frequency)
    {
        CAS = cas;
        Precharge = precharge;
        TRas = tras;
        RC = rc;
        Voltage = voltage;
        Frequency = frequency;
    }

    public int CAS { get; }
    public int Precharge { get; }
    public int TRas { get; }
    public int RC { get; }
    public int Voltage { get; }
    public int Frequency { get; }
}
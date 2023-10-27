namespace Itmo.ObjectOrientedProgramming.Lab2.RAM.XMP;

public interface IXmp
{
    public int CAS { get; }
    public int Precharge { get; }
    public int TRas { get; }
    public int RC { get; }
    public int Voltage { get; }
    public int Frequency { get; }
}
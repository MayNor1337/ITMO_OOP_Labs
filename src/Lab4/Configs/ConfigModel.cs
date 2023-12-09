namespace Itmo.ObjectOrientedProgramming.Lab4.Configs;

public class ConfigModel
{
    public string SymbolFolder { get; set; } = "[+]";
    public string SymbolFile { get; set; } = "[ ]";
    public char SymbolIndent { get; set; } = '\t';
    public int Depth { get; set; } = 1;
}
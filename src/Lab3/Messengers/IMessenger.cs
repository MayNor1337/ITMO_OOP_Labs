namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public interface IMessenger
{
    void Output();

    public void SendText(string text);
}
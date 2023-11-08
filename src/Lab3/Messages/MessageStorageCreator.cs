namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class MessageStorageCreator : IMessageStorageCreator
{
    public IMessageStorage CreateNewStorage()
    {
        return new MessageStorage();
    }
}
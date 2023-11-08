namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public interface IMessageBuilder
{
    public IMessageBuilder SetHeading(string heading);

    public IMessageBuilder SetBody(string body);

    public IMessageBuilder SetImportanceLevel(int importanceLevel);

    public IMessage Build();
}
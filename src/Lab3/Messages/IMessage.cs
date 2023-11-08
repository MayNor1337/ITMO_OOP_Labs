using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public interface IMessage : IEquatable<IMessage>
{
    public string Heading { get; }
    public string Body { get; }
    public int ImportanceLevel { get; }

    public DateTime DateOfCreation { get; }
}
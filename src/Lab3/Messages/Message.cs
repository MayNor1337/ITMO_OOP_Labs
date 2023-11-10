using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class Message : IEquatable<Message>
{
    public Message(string heading, string body, int importanceLevel)
    {
        Heading = heading;
        Body = body;
        ImportanceLevel = importanceLevel;
        DateOfCreation = DateTime.Now;
    }

    public string Heading { get; }
    public string Body { get; }
    public int ImportanceLevel { get; }
    public DateTime DateOfCreation { get; }

    public bool Equals(Message? other)
    {
        if (other is null)
            return false;

        return Heading == other.Heading
               && Body == other.Body
               && ImportanceLevel == other.ImportanceLevel
               && DateOfCreation == other.DateOfCreation;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Message message)
            return false;

        return Equals(message);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Heading, Body, ImportanceLevel);
    }
}
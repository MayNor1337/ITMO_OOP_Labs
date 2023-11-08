using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class Message : IMessage
{
    private Message(string heading, string body, int importanceLevel)
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

    public bool Equals(IMessage? other)
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
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Message)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Heading, Body, ImportanceLevel);
    }

    public class MessageBuilder : IMessageBuilder
    {
        private string? _heading;
        private string? _body;
        private int _importanceLevel;

        public IMessageBuilder SetHeading(string heading)
        {
            _heading = heading;
            return this;
        }

        public IMessageBuilder SetBody(string body)
        {
            _body = body;
            return this;
        }

        public IMessageBuilder SetImportanceLevel(int importanceLevel)
        {
            _importanceLevel = importanceLevel;
            return this;
        }

        public IMessage Build()
        {
            return new Message(
                _heading ?? throw new ArgumentNullException(nameof(_heading)),
                _body ?? throw new ArgumentNullException(nameof(_body)),
                _importanceLevel);
        }
    }
}
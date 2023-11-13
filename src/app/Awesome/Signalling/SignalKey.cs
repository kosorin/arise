namespace Awesome.Signalling;

internal readonly struct SignalKey : IEquatable<SignalKey>
{
    public SignalKey(Type sourceType, Type signalType, string name)
    {
        SourceType = sourceType;
        SignalType = signalType;
        Name = name;
    }

    public Type SourceType { get; }

    public Type SignalType { get; }

    public string Name { get; }

    public bool Equals(SignalKey other)
    {
        return Name == other.Name
            && SourceType == other.SourceType
            && SignalType == other.SignalType;
    }

    public override bool Equals(object obj)
    {
        return obj is SignalKey other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public static bool operator ==(SignalKey left, SignalKey right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(SignalKey left, SignalKey right)
    {
        return !Equals(left, right);
    }
}

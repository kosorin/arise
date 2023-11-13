namespace Awesome.Signalling;

public static class Signal
{
    private static readonly Dictionary<SignalKey, Delegate> Definitions = new();

    public static void Define<TSource, TSignal>(string name, Delegate definition)
        where TSource : ISignalSource
        where TSignal : ISignal
    {
        var key = new SignalKey(typeof(TSource), typeof(TSignal), name);
        Definitions.Add(key, definition);
    }

    public static void Define<TSource, TSignal>(string[] names, Delegate definition)
        where TSource : ISignalSource
        where TSignal : ISignal
    {
        foreach (var name in names)
        {
            var key = new SignalKey(typeof(TSource), typeof(TSignal), name);
            Definitions.Add(key, definition);
        }
    }

    public static Delegate Get<TSource, TSignal>(string name)
        where TSource : ISignalSource
        where TSignal : ISignal
    {
        var key = new SignalKey(typeof(TSource), typeof(TSignal), name);
        return Definitions.TryGetValue(key, out var definition)
            ? definition
            : null;
    }
}

namespace Awesome.Signal;

public class SignalDefinitionCollection
{
    private readonly Dictionary<string, Delegate> _transformers = new();

    public void Add(string name, Delegate transformer)
    {
        _transformers.Add(name, transformer);
    }

    public void AddRange(IEnumerable<string> names, Delegate transformer)
    {
        foreach (var name in names)
        {
            Add(name, transformer);
        }
    }

    public Delegate GetOrNull(string name)
    {
        return _transformers.TryGetValue(name, out var transformer)
            ? transformer
            : null;
    }
}

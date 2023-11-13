using System.Diagnostics.CodeAnalysis;

namespace Awesome.Signalling;

public class SignalManager
{
    private readonly ISignalSource _source;

    private Dictionary<string, HandlerCollection> _handlers;

    public SignalManager(ISignalSource source)
    {
        _source = source;
    }

    public void Connect<TSource, TSignal>(string name, SignalHandler<TSignal> handler)
        where TSource : ISignalSource
        where TSignal : ISignal
    {
        _handlers ??= new();

        if (!_handlers.TryGetValue(name, out var handlers))
        {
            var definition = Signal.Get<TSource, TSignal>(name);
            if (definition is null)
            {
                return;
            }
            _handlers.Add(name, handlers = new(_source, name, definition));
        }

        if (handlers.Add(handler) && handlers.Count == 1)
        {
            _source.Connect(name, handlers.RootHandler);
        }
    }

    public void Disconnect<TSource, TSignal>(string name, SignalHandler<TSignal> handler)
        where TSource : ISignalSource
        where TSignal : ISignal
    {
        if (_handlers is null)
        {
            return;
        }

        if (!_handlers.TryGetValue(name, out var handlers))
        {
            return;
        }

        if (handlers.Remove(handler) && handlers.Count == 0)
        {
            _source.Disconnect(name, handlers.RootHandler);
        }
    }

    private class HandlerCollection
    {
        private readonly ISignalSource _source;
        private readonly string _name;
        private readonly HashSet<Delegate> _handlers = new();

        public HandlerCollection(ISignalSource source, string name, [SuppressMessage("ReSharper", "UnusedParameter.Local")] Delegate definition)
        {
            _source = source;
            _name = name;
            /*[[
                this.RootHandler = function(...)
                    local signal = definition(...)
                    if signal then
                        for handler in pairs(this._handlers) do
                            handler(signal)
                        end
                    end
                end
            ]]*/
        }

        [SuppressMessage("ReSharper", "UnassignedGetOnlyAutoProperty")]
        public Delegate RootHandler { get; }

        public int Count => _handlers.Count;

        public bool Add(Delegate handler)
        {
            return _handlers.Add(handler);
        }

        public bool Remove(Delegate handler)
        {
            return _handlers.Remove(handler);
        }
    }
}

using System.Diagnostics.CodeAnalysis;

namespace Awesome.Signal;

public class SignalCollection
{
    private readonly ISignalEmitter _emitter;
    private readonly SignalDefinitionCollection _definitions;

    private Dictionary<string, Collection> _collections;

    public SignalCollection(ISignalEmitter emitter, SignalDefinitionCollection definitions)
    {
        _emitter = emitter;
        _definitions = definitions;
    }

    public void Connect<TSignal>(string name, SignalHandler<TSignal> handler)
        where TSignal : ISignal
    {
        _collections ??= new();

        if (!_collections.TryGetValue(name, out var collection))
        {
            var transformer = _definitions.GetOrNull(name);
            if (transformer is null)
            {
                return;
            }
            _collections.Add(name, collection = new(name, transformer));
        }

        if (collection.Add(handler))
        {
            collection.Connect(_emitter);
        }
    }

    public void Disconnect<TSignal>(string name, SignalHandler<TSignal> handler)
        where TSignal : ISignal
    {
        if (_collections is null)
        {
            return;
        }

        if (!_collections.TryGetValue(name, out var collection))
        {
            return;
        }

        if (collection.Remove(handler))
        {
            collection.Disconnect(_emitter);
        }
    }

    private class Collection
    {
        private readonly string _name;
        private readonly Delegate _rootHandler = default;
        private readonly HashSet<Delegate> _handlers = new();

        public Collection(string name, [SuppressMessage("ReSharper", "UnusedParameter.Local")] Delegate transformer)
        {
            _name = name;
            /*[[
                this._rootHandler = function(...)
                    local signal = transformer(...)
                    if signal then
                        for handler in pairs(this._handlers) do
                            handler(signal)
                        end
                    end
                end
            ]]*/
        }

        public void Connect(ISignalEmitter emitter)
        {
            ConnectRaw(emitter.Raw, _name, _rootHandler);
        }

        public void Disconnect(ISignalEmitter emitter)
        {
            DisconnectRaw(emitter.Raw, _name, _rootHandler);
        }

        public bool Add(Delegate handler)
        {
            return _handlers.Add(handler) && _handlers.Count == 1;
        }

        public bool Remove(Delegate handler)
        {
            return _handlers.Remove(handler) && _handlers.Count == 0;
        }

        /// <summary>
        /// @CSharpLua.Template = "{0}:connect_signal({1}, {2})"
        /// </summary>
        private static extern void ConnectRaw(LuaObject rawEmitter, string name, Delegate rawHandler);

        /// <summary>
        /// @CSharpLua.Template = "{0}:disconnect_signal({1}, {2})"
        /// </summary>
        private static extern void DisconnectRaw(LuaObject rawEmitter, string name, Delegate rawHandler);
    }
}

using System.Diagnostics;
using Awesome.Signalling;

namespace Awesome;

public abstract class AwesomeObject : ISignalSource
{
    protected AwesomeObject()
    {
        Signals = new(this);
    }

    public virtual LuaObject Raw => throw new UnreachableException("Property should be abstract (CSharpLua workaround)");

    protected SignalManager Signals { get; }

    void ISignalSource.Connect(string name, Delegate handler)
    {
        ConnectRaw(Raw, name, handler);
    }

    void ISignalSource.Disconnect(string name, Delegate handler)
    {
        DisconnectRaw(Raw, name, handler);
    }

    /// <summary>
    /// @CSharpLua.Template = "{0}:connect_signal({1}, {2})"
    /// </summary>
    private static extern void ConnectRaw(LuaObject raw, string name, Delegate handler);

    /// <summary>
    /// @CSharpLua.Template = "{0}:disconnect_signal({1}, {2})"
    /// </summary>
    private static extern void DisconnectRaw(LuaObject raw, string name, Delegate handler);
}

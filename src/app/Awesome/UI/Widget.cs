using Awesome.Signal;

namespace Awesome.UI;

public abstract class Widget : IWidgetTemplate, ISignalEmitter
{
    protected static SignalDefinitionCollection SignalDefinitions = new();

    private readonly LuaObject _raw;

    static Widget()
    {
        SignalDefinitions.AddRange(new[] { "button::press", "button::release" }, (LuaObject rawWidget, float x, float y, Button button, LuaArray<string> rawModifiers) =>
        {
            return new MouseButtonSignal
            {
                Widget = ObjectManager.Unwrap<Widget>(rawWidget),
                X = x,
                Y = y,
                Button = button,
                Modifiers = rawModifiers.ToList(),
            };
        });
        SignalDefinitions.AddRange(new[] { "mouse::enter", "mouse::leave" }, (LuaObject rawWidget) =>
        {
            return new WidgetSignal
            {
                Widget = ObjectManager.Unwrap<Widget>(rawWidget),
            };
        });
    }

    protected Widget(WidgetTemplate template)
    {
        _raw = CreateRaw(template.ToRaw());

        Signals = new(this, SignalDefinitions);

        ObjectManager.Wrap(_raw, this);
    }

    protected SignalCollection Signals { get; }

    LuaObject ISignalEmitter.Raw => _raw;

    /// <summary>
    /// @CSharpLua.Template = "Lapi.wibox.widget({0})"
    /// </summary>
    private static extern LuaObject CreateRaw(LuaObject rawTemplate);

    LuaObject IWidgetTemplate.ToRaw()
    {
        return _raw;
    }

    public event SignalHandler<MouseButtonSignal> MouseButtonPress
    {
        add => Signals.Connect("button::press", value);
        remove => Signals.Disconnect("button::press", value);
    }

    public event SignalHandler<MouseButtonSignal> MouseButtonRelease
    {
        add => Signals.Connect("button::release", value);
        remove => Signals.Disconnect("button::release", value);
    }

    public event SignalHandler<WidgetSignal> MouseEnter
    {
        add => Signals.Connect("mouse::enter", value);
        remove => Signals.Disconnect("mouse::enter", value);
    }

    public event SignalHandler<WidgetSignal> MouseLeave
    {
        add => Signals.Connect("mouse::leave", value);
        remove => Signals.Disconnect("mouse::leave", value);
    }
}

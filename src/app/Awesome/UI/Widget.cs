using Awesome.Signalling;

namespace Awesome.UI;

public abstract class Widget : AwesomeObject, IWidgetTemplate
{
    private readonly LuaObject _raw;

    static Widget()
    {
        Signal.Define<Widget, MouseButtonSignal>(new[] { "button::press", "button::release" }, (LuaObject rawWidget, float x, float y, Button button, LuaArray<string> rawModifiers) =>
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
        Signal.Define<Widget, WidgetSignal>(new[] { "mouse::enter", "mouse::leave" }, (LuaObject rawWidget) =>
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

        ObjectManager.Wrap(_raw, this);
    }

    public override LuaObject Raw => _raw;

    WidgetTemplateType IWidgetTemplate.Type => WidgetTemplateType.Widget;

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
        add => Signals.Connect<Widget, MouseButtonSignal>("button::press", value);
        remove => Signals.Disconnect<Widget, MouseButtonSignal>("button::press", value);
    }

    public event SignalHandler<MouseButtonSignal> MouseButtonRelease
    {
        add => Signals.Connect<Widget, MouseButtonSignal>("button::release", value);
        remove => Signals.Disconnect<Widget, MouseButtonSignal>("button::release", value);
    }

    public event SignalHandler<WidgetSignal> MouseEnter
    {
        add => Signals.Connect<Widget, WidgetSignal>("mouse::enter", value);
        remove => Signals.Disconnect<Widget, WidgetSignal>("mouse::enter", value);
    }

    public event SignalHandler<WidgetSignal> MouseLeave
    {
        add => Signals.Connect<Widget, WidgetSignal>("mouse::leave", value);
        remove => Signals.Disconnect<Widget, WidgetSignal>("mouse::leave", value);
    }
}

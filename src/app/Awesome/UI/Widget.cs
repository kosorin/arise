using System.Diagnostics.CodeAnalysis;
using Awesome.Input;
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
                Widget = ObjectManager.Resolve<Widget>(rawWidget),
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
                Widget = ObjectManager.Resolve<Widget>(rawWidget),
            };
        });
    }

    protected Widget(LuaObject raw) : base(false)
    {
        _raw = raw;
        ObjectManager.Register(_raw, this);
    }

    protected Widget(WidgetTemplate template) : base(true)
    {
        _raw = CreateRaw(template.ToRaw());
        ObjectManager.Register(_raw, this);
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

    public TWidget GetWidget<TWidget>(string id)
        where TWidget : class
    {
        return GetWidget<TWidget>(id, 0);
    }

    public TWidget GetWidget<TWidget>(string id, int index)
        where TWidget : class
    {
        return TryGetWidget<TWidget>(id, index, out var widget)
            ? widget
            : null;
    }

    public bool TryGetWidget<TWidget>([SuppressMessage("ReSharper", "UnusedParameter.Global")] string id, [MaybeNullWhen(false)] out TWidget widget)
        where TWidget : class
    {
        return TryGetWidget(id, 0, out widget);
    }

    public bool TryGetWidget<TWidget>([SuppressMessage("ReSharper", "UnusedParameter.Global")] string id, int index, [MaybeNullWhen(false)] out TWidget widget)
        where TWidget : class
    {
        LuaObject rawWidget = null;
        /*[[
            local rawWidgets = this._raw:get_children_by_id(id)
            if not rawWidgets then
                return false
            end
            rawWidget = rawWidgets[index + 1]
            if not rawWidget then
                return false
            end
        ]]*/
        // ReSharper disable once ExpressionIsAlwaysNull
        return ObjectManager.TryResolve(rawWidget, out widget);
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

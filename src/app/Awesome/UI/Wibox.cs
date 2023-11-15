using System.Diagnostics.CodeAnalysis;

namespace Awesome.UI;

public class Wibox : AwesomeObject
{
    private readonly LuaObject _raw;

    public Wibox(LuaObject raw) : base(false)
    {
        _raw = raw;
        ObjectManager.Register(_raw, this);
    }

    public Wibox(WiboxTemplate template) : base(true)
    {
        _raw = CreateRaw(template.ToRaw());
        ObjectManager.Register(_raw, this);
    }

    protected virtual LuaObject CreateRaw(LuaObject rawTemplate)
    {
        return CreateRawCore(rawTemplate);
    }

    /// <summary>
    /// @CSharpLua.Template = "Lapi.wibox({0})"
    /// </summary>
    private static extern LuaObject CreateRawCore(LuaObject rawTemplate);

    public void Hide()
    {
        _raw.Set("visible", false);
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
            local rawRootWidget = this._raw.widget
            local rawWidgets = rawRootWidget and rawRootWidget:get_children_by_id(id)
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
}

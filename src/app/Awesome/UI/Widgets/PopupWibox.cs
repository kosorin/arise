using Awesome.UI.Templates;

namespace Awesome.UI.Widgets;

public class PopupWibox : Wibox
{
    public PopupWibox(PopupTemplate template) : base(template)
    {
    }

    protected override LuaObject CreateRaw(LuaObject rawTemplate)
    {
        return CreateRawCore(rawTemplate);
    }

    /// <summary>
    /// @CSharpLua.Template = "Lapi.awful.popup({0})"
    /// </summary>
    private static extern LuaObject CreateRawCore(LuaObject rawTemplate);
}

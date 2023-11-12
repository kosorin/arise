namespace Awesome.UI;

public class Wibox
{
    private readonly LuaObject _raw;

    public Wibox(WiboxTemplate template)
    {
        _raw = CreateRaw(template.ToRaw());

        ObjectManager.Wrap(_raw, this);
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
}

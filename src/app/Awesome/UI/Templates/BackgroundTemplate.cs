namespace Awesome.UI.Templates;

public class BackgroundTemplate : ContainerTemplate
{
    #pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

    /// <summary>
    /// @CSharpLua.Template = "Lapi.wibox.container.background"
    /// </summary>
    private static readonly LuaObject Factory;

    #pragma warning restore CS0649 // Field is never assigned to, and will always have its default value

    public string Background { get; set; }

    public string Foreground { get; set; }

    public override LuaObject ToRaw()
    {
        var raw = base.ToRaw();

        raw.Set("layout", Factory);
        raw.Set("bg", Background);
        raw.Set("fg", Foreground);

        return raw;
    }
}

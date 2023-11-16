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

    public string BorderColor { get; set; }

    public float BorderWidth { get; set; }

    public BorderStrategy BorderStrategy { get; set; }

    public ShapeHandler Shape { get; set; }

    public override LuaObject ToRaw()
    {
        var raw = base.ToRaw();

        raw.Set("layout", Factory);
        raw.Set("bg", Background);
        raw.Set("fg", Foreground);
        raw.Set("border_color", BorderColor);
        raw.Set("border_width", BorderWidth);
        raw.Set("border_strategy", BorderStrategy switch
        {
            BorderStrategy.None => "none",
            BorderStrategy.Inner => "inner",
            _ => throw new ArgumentOutOfRangeException(),
        });
        raw.Set("shape", Shape);

        return raw;
    }
}

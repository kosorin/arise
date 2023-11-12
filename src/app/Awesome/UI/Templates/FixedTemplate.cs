namespace Awesome.UI.Templates;

public class FixedTemplate : LayoutWidgetTemplate
{
    public Orientation Orientation { get; set; }

    public bool FillSpace { get; set; } = false;

    public float Spacing { get; set; } = 0;

    public override LuaObject ToRaw()
    {
        var raw = base.ToRaw();

        raw.Set("layout", Orientation switch
        {
            Orientation.Horizontal => HorizontalFactory,
            Orientation.Vertical => VerticalFactory,
            _ => throw new ArgumentOutOfRangeException(nameof(Orientation)),
        });
        raw.Set("fill_space", FillSpace);
        raw.Set("spacing", Spacing);

        return raw;
    }

    #pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

    /// <summary>
    /// @CSharpLua.Template = "Lapi.wibox.layout.fixed.horizontal"
    /// </summary>
    private static readonly LuaObject HorizontalFactory;

    /// <summary>
    /// @CSharpLua.Template = "Lapi.wibox.layout.fixed.vertical"
    /// </summary>
    private static readonly LuaObject VerticalFactory;

    #pragma warning restore CS0649 // Field is never assigned to, and will always have its default value
}

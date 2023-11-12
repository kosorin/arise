namespace Awesome.UI.Templates;

public class AlignTemplate : LayoutWidgetTemplate
{
    public Orientation Orientation { get; set; }

    public ExpandStrategy ExpandStrategy { get; set; } = ExpandStrategy.Inside;

    public IWidgetTemplate Front
    {
        get => Children.Count > 0 ? Children[0] : null;
        set
        {
            EnsureChildren(1);
            Children[0] = value;
        }
    }

    public IWidgetTemplate Middle
    {
        get => Children.Count > 1 ? Children[1] : null;
        set
        {
            EnsureChildren(2);
            Children[1] = value;
        }
    }

    public IWidgetTemplate Back
    {
        get => Children.Count > 2 ? Children[2] : null;
        set
        {
            EnsureChildren(3);
            Children[2] = value;
        }
    }

    private void EnsureChildren(int count)
    {
        Children ??= new();
        while (Children.Count < count)
        {
            Children.Add(null);
        }
    }

    public override LuaObject ToRaw()
    {
        var raw = base.ToRaw();

        raw.Set("layout", Orientation switch
        {
            Orientation.Horizontal => HorizontalFactory,
            Orientation.Vertical => VerticalFactory,
            _ => throw new ArgumentOutOfRangeException(nameof(Orientation)),
        });
        raw.Set("expand", ExpandStrategy switch
        {
            ExpandStrategy.Inside => "inside",
            ExpandStrategy.Outside => "outside",
            _ => "none",
        });

        return raw;
    }

    #pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

    /// <summary>
    /// @CSharpLua.Template = "Lapi.wibox.layout.align.horizontal"
    /// </summary>
    private static readonly LuaObject HorizontalFactory;

    /// <summary>
    /// @CSharpLua.Template = "Lapi.wibox.layout.align.vertical"
    /// </summary>
    private static readonly LuaObject VerticalFactory;

    #pragma warning restore CS0649 // Field is never assigned to, and will always have its default value
}

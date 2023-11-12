namespace Awesome.UI.Templates;

public class TextBoxTemplate : WidgetTemplate
{
    #pragma warning disable CS0649 // Field is never assigned to, and will always have its default value

    /// <summary>
    /// @CSharpLua.Template = "Lapi.wibox.widget.textbox"
    /// </summary>
    private static readonly LuaObject Factory;

    #pragma warning restore CS0649 // Field is never assigned to, and will always have its default value

    public TextBoxTemplate()
    {
    }

    public TextBoxTemplate(string text, bool useMarkup = true)
    {
        Text = text;
        UseMarkup = useMarkup;
    }

    public string Text { get; set; } = string.Empty;

    public bool UseMarkup { get; set; } = true;

    public VerticalAlignment VerticalAlignment { get; set; } = VerticalAlignment.Center;

    public HorizontalAlignment HorizontalAlignment { get; set; } = HorizontalAlignment.Left;

    public override LuaObject ToRaw()
    {
        var raw = base.ToRaw();

        raw.Set("layout", Factory);
        raw.Set(UseMarkup ? "markup" : "text", Text);
        raw.Set("valign", VerticalAlignment switch
        {
            VerticalAlignment.Top => "top",
            VerticalAlignment.Center => "center",
            VerticalAlignment.Bottom => "bottom",
            _ => throw new ArgumentOutOfRangeException(),
        });
        raw.Set("halign", HorizontalAlignment switch
        {
            HorizontalAlignment.Left => "left",
            HorizontalAlignment.Center => "center",
            HorizontalAlignment.Right => "right",
            _ => throw new ArgumentOutOfRangeException(),
        });

        return raw;
    }
}

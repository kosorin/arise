namespace Awesome.UI;

public abstract class WidgetTemplate : IWidgetTemplate
{
    WidgetTemplateType IWidgetTemplate.Type => WidgetTemplateType.Template;

    public string Id { get; set; } = null;

    public bool Visible { get; set; } = true;

    public float Opacity { get; set; } = 1;

    public float? ForcedWidth { get; set; } = null;

    public float? ForcedHeight { get; set; } = null;

    public virtual LuaObject ToRaw()
    {
        var raw = new LuaObject();

        raw.Set("id", Id);
        raw.Set("visible", Visible);
        raw.Set("opacity", Opacity);
        raw.Set("forced_width", ForcedWidth);
        raw.Set("forced_height", ForcedHeight);

        return raw;
    }
}

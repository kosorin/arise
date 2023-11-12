namespace Awesome.UI;

public class WiboxTemplate
{
    public bool Visible { get; set; } = true;

    public float Opacity { get; set; } = 1;

    public int X { get; set; } = 0;

    public int Y { get; set; } = 0;

    public int Width { get; set; } = 1;

    public int Height { get; set; } = 1;

    public IWidgetTemplate Content { get; set; }

    public virtual LuaObject ToRaw()
    {
        var raw = new LuaObject();

        raw.Set("visible", Visible);
        raw.Set("opacity", Opacity);
        raw.Set("x", X);
        raw.Set("y", Y);
        raw.Set("width", Math.Max(1, Width));
        raw.Set("height", Math.Max(1, Height));
        raw.Set("widget", Content?.ToRaw());

        return raw;
    }
}

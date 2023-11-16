using Awesome.UI.Templates;

namespace Awesome.UI.Widgets;

public class BackgroundWidget : ContainerWidget
{
    public BackgroundWidget(LuaObject raw) : base(raw)
    {
    }

    public BackgroundWidget(BackgroundTemplate template) : base(template)
    {
    }

    public string Background
    {
        get => Raw.Get("bg");
        set => Raw.Set("bg", value);
    }

    public string Foreground
    {
        get => Raw.Get("fg");
        set => Raw.Set("fg", value);
    }

    public string BorderColor
    {
        get => Raw.Get("border_color");
        set => Raw.Set("border_color", value);
    }

    public float BorderWidth
    {
        get => Raw.Get("border_width");
        set => Raw.Set("border_width", value);
    }

    public BorderStrategy BorderStrategy
    {
        get =>
            Raw.Get("border_strategy") switch
            {
                "none" => BorderStrategy.None,
                "inner" => BorderStrategy.Inner,
                _ => throw new ArgumentOutOfRangeException(),
            };
        set =>
            Raw.Set("border_strategy", value switch
            {
                BorderStrategy.None => "none",
                BorderStrategy.Inner => "inner",
                _ => throw new ArgumentOutOfRangeException(),
            });
    }

    public ShapeHandler Shape
    {
        get => Raw.Get("shape");
        set => Raw.Set("shape", value);
    }
}

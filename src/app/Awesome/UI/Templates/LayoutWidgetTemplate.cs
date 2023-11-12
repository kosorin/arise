namespace Awesome.UI.Templates;

public abstract class LayoutWidgetTemplate : WidgetTemplate
{
    public List<IWidgetTemplate> Children { get; set; }

    public override LuaObject ToRaw()
    {
        var raw = base.ToRaw().AsArray<LuaObject>();

        if (Children is not null)
        {
            foreach (var child in Children)
            {
                if (child?.ToRaw() is { } rawChild)
                {
                    raw.Add(rawChild);
                }
            }
        }

        return raw;
    }
}

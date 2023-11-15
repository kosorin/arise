namespace Awesome.UI.Templates;

public abstract class ContainerTemplate : WidgetTemplate
{
    public IWidgetTemplate Content { get; set; }

    public override LuaObject ToRaw()
    {
        var raw = base.ToRaw().AsArray<LuaObject>();

        if (Content?.ToRaw() is { } rawContent)
        {
            raw.Add(rawContent);
        }

        return raw;
    }
}

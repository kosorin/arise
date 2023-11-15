namespace Awesome.UI;

public interface IWidgetTemplate
{
    WidgetTemplateType Type { get; }

    LuaObject ToRaw();
}

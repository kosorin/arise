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
}

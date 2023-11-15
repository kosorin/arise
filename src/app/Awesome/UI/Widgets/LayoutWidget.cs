using Awesome.UI.Templates;

namespace Awesome.UI.Widgets;

public abstract class LayoutWidget : Widget
{
    protected LayoutWidget(LuaObject raw) : base(raw)
    {
    }

    protected LayoutWidget(LayoutTemplate template) : base(template)
    {
    }

    public IList<Widget> Children { get; set; }
}

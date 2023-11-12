using Awesome.UI.Templates;

namespace Awesome.UI.Widgets;

public abstract class LayoutWidget : Widget
{
    protected LayoutWidget(LayoutWidgetTemplate template) : base(template)
    {
    }

    public IList<Widget> Children { get; set; }
}

using Awesome.UI.Templates;

namespace Awesome.UI.Widgets;

public abstract class ContainerWidget : Widget
{
    protected ContainerWidget(ContainerTemplate template) : base(template)
    {
    }

    public Widget Content { get; set; }
}

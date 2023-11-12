using Awesome.UI.Templates;

namespace Awesome.UI.Widgets;

public class ContainerWidget : Widget
{
    public ContainerWidget(ContainerWidgetTemplate template) : base(template)
    {
    }

    public Widget Content { get; set; }
}

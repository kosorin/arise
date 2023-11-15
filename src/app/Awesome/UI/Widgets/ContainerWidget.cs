using Awesome.UI.Templates;

namespace Awesome.UI.Widgets;

public class ContainerWidget : Widget
{
    public ContainerWidget(ContainerTemplate template) : base(template)
    {
    }

    public Widget Content { get; set; }
}

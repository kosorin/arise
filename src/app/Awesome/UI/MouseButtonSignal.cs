namespace Awesome.UI;

public class MouseButtonSignal : WidgetSignal
{
    public required float X { get; init; }

    public required float Y { get; init; }

    public required Button Button { get; init; }

    public required List<string> Modifiers { get; init; }
}

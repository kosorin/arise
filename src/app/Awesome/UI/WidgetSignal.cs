using Awesome.Signalling;

namespace Awesome.UI;

public class WidgetSignal : ISignal
{
    public required Widget Widget { get; init; }
}

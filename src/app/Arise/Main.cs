using System.Diagnostics.CodeAnalysis;
using Awesome.UI;
using Awesome.UI.Templates;
using Awesome.UI.Widgets;

namespace Arise;

[SuppressMessage("ReSharper", "UnusedType.Global")]
public static class Main
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static void Run()
    {
        var loremWidget = new TextBox(new()
        {
            Text = "<big>Lorem ipsum dolor sit amet.</big>",
            HorizontalAlignment = HorizontalAlignment.Right,
        });

        var wibox = new Wibox(new()
        {
            X = 100,
            Y = 50,
            Width = 500,
            Height = 200,
            Content = new BackgroundTemplate
            {
                Background = "#006600",
                Foreground = "#ffffcc",
                Content = new FixedTemplate
                {
                    Orientation = Orientation.Vertical,
                    Children = new()
                    {
                        new TextBoxTemplate("<span size='300%'>Hello Awesome!</span>"),
                        loremWidget,
                    },
                },
            },
        });

        loremWidget.MouseButtonPress += signal =>
        {
            Console.WriteLine($"==> click: {signal.Button}");
            wibox.Hide();
        };
    }
}

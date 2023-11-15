using System.Diagnostics.CodeAnalysis;
using Awesome.UI;
using Awesome.UI.Widgets;

namespace Awesome;

public static class ObjectManager
{
    private static readonly LuaObject Data = new("kv");
    private static readonly LuaObject Factories = new();

    static ObjectManager()
    {
        RegisterWidgetTypes();
    }

    public static void Register<T>(LuaObject raw, T @object)
        where T : class
    {
        Data.Set(raw, @object);
    }

    public static T Resolve<T>(LuaObject raw)
        where T : class
    {
        if (Data.Get(raw) is T @object)
        {
            return @object;
        }

        if (Factories.Get(typeof(T)) is Func<LuaObject, T> factory)
        {
            return factory.Invoke(raw);
        }

        return null;
    }

    public static bool TryResolve<T>(LuaObject raw, [MaybeNullWhen(false)] out T @object)
        where T : class
    {
        @object = Resolve<T>(raw);
        return @object is not null;
    }

    public static void RegisterType<T>(Func<LuaObject, T> factory)
        where T : class
    {
        Factories.Set(typeof(T), factory);
    }

    internal static void RegisterWidgetTypes()
    {
        RegisterType(raw => new Wibox(raw));
        RegisterType(raw => new PopupWibox(raw));
        RegisterType(raw => new BackgroundWidget(raw));
        RegisterType(raw => new AlignWidget(raw));
        RegisterType(raw => new FixedWidget(raw));
        RegisterType(raw => new TextBoxWidget(raw));
    }
}

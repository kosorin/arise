namespace Awesome;

public static class ObjectManager
{
    private static readonly LuaObject Map = new("kv");

    public static void Wrap<T>(LuaObject raw, T @object)
        where T : class
    {
        Map.Set(raw, @object);
    }

    public static T Unwrap<T>(LuaObject raw)
        where T : class
    {
        return Map.Get(raw) as T;
    }

    public static bool TryUnwrap<T>(LuaObject raw, out T @object)
        where T : class
    {
        @object = Map.Get(raw) as T;
        return @object is not null;
    }
}

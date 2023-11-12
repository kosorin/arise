using System.Diagnostics.CodeAnalysis;

namespace Lua;

public static class LuaLinqExtensions
{
    public static List<T> ToList<T>([SuppressMessage("ReSharper", "UnusedParameter.Global")] this LuaArray<T> raw)
    {
        var list = new List<T>();
        /*[[
            for _, v in ipairs(raw) do
                list:Add(v)
            end
        ]]*/
        return list;
    }
}

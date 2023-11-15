using System.Diagnostics.CodeAnalysis;

namespace Lua;

public static class LuaTable
{
    /// <summary>
    /// @CSharpLua.Template = "{0}"
    /// </summary>
    public static extern LuaTable<TNewKey, TNewValue> From<TNewKey, TNewValue>(dynamic raw);
}

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public class LuaTable<TKey, TValue> : LuaObject
{
    /// <summary>
    /// @CSharpLua.Template = "{}"
    /// </summary>
    public extern LuaTable();

    /// <summary>
    /// @CSharpLua.Template = "setmetatable({}, { __mode = {0} })"
    /// </summary>
    public extern LuaTable(string mode);

    /// <summary>
    /// @CSharpLua.Template = "#{this}"
    /// </summary>
    public extern int Count();

    /// <summary>
    /// @CSharpLua.Template = "{this}[{0}] ~= nil"
    /// </summary>
    public extern bool ContainsKey(TKey key);

    /// <summary>
    /// @CSharpLua.Template = "{this}[{0}]"
    /// </summary>
    public extern TValue GetValue(TKey key);

    /// <summary>
    /// @CSharpLua.Template = "{this}[{0}] = {1}"
    /// </summary>
    public extern void SetValue(TKey key, TValue value);

    /// <summary>
    /// @CSharpLua.Template = "{this}[{0}] = nil"
    /// </summary>
    public extern void Remove(TKey key);

    /// <summary>
    /// @CSharpLua.Template = "do local each = {0}; for k, v in pairs({this}) do each(k, v) end end"
    /// </summary>
    public extern void ForEach(Action<TKey, TValue> action);

    public Dictionary<TKey, TValue> ToDictionary()
    {
        var dictionary = new Dictionary<TKey, TValue>();
        /*[[
            for k, v in pairs({this}) do
                dictionary:Add(k, v)
            end
        ]]*/
        return dictionary;
    }
}

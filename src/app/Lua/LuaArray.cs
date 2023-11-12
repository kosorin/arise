using System.Diagnostics.CodeAnalysis;

namespace Lua;

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public class LuaArray<TValue> : LuaObject
{
    /// <summary>
    /// @CSharpLua.Template = "{}"
    /// </summary>
    public extern LuaArray();

    /// <summary>
    /// @CSharpLua.Template = "setmetatable({}, { __mode = {0} })"
    /// </summary>
    public extern LuaArray(string mode);

    /// <summary>
    /// @CSharpLua.Template = "#{this}"
    /// </summary>
    public extern int Count();

    /// <summary>
    /// @CSharpLua.Template = "{this}[{0} + 1]"
    /// </summary>
    public extern TValue Get(int index);

    /// <summary>
    /// @CSharpLua.Template = "{this}[{0} + 1] = {1}"
    /// </summary>
    public extern void Set(int index, TValue value);

    /// <summary>
    /// @CSharpLua.Template = "{this}[#{this} + 1] = {0}"
    /// </summary>
    public extern void Add(TValue value);

    /// <summary>
    /// @CSharpLua.Template = "table.insert({this}, {0} + 1, {1})"
    /// </summary>
    public extern void Insert(int index, TValue value);

    /// <summary>
    /// @CSharpLua.Template = "{this}[#{this}] = nil"
    /// </summary>
    public extern void Remove();

    /// <summary>
    /// @CSharpLua.Template = "table.remove({this}, {0} + 1)"
    /// </summary>
    public extern void Remove(int index);

    /// <summary>
    /// @CSharpLua.Template = "do local each = {0}; for i, v in ipairs({this}) do each(i - 1, v) end end"
    /// </summary>
    public extern void ForEach(Action<int, TValue> action);

    /// <summary>
    /// @CSharpLua.Template = "{0}"
    /// </summary>
    public static extern LuaArray<TNewValue> From<TNewValue>(dynamic raw);
}

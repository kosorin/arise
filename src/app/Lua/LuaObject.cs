using System.Diagnostics.CodeAnalysis;

namespace Lua;

[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public class LuaObject
{
    /// <summary>
    /// @CSharpLua.Template = "{}"
    /// </summary>
    public extern LuaObject();

    /// <summary>
    /// @CSharpLua.Template = "setmetatable({}, { __mode = {0} })"
    /// </summary>
    public extern LuaObject(string mode);

    /// <summary>
    /// @CSharpLua.Template = "{this}[{0}]"
    /// </summary>
    public extern dynamic Get(dynamic key);

    /// <summary>
    /// @CSharpLua.Template = "{this}[{0}] = {1}"
    /// </summary>
    public extern void Set(dynamic key, dynamic value);

    /// <summary>
    /// @CSharpLua.Template = "{0}"
    /// </summary>
    public static extern LuaObject From(dynamic raw);

    /// <summary>
    /// @CSharpLua.Template = "{this}"
    /// </summary>
    public extern LuaArray<TNewValue> AsArray<TNewValue>();

    /// <summary>
    /// @CSharpLua.Template = "{this}"
    /// </summary>
    public extern LuaTable<TNewKey, TNewValue> AsTable<TNewKey, TNewValue>();
}

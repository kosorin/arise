namespace Awesome;

public static class Debug
{
    /// <summary>
    /// @CSharpLua.Template = "Lapi.gears.debug.dump_return({0}, {1}, {2})"
    /// </summary>
    public static extern string Dump(object data, string key = null, int? depth = null);

    /// <summary>
    /// @CSharpLua.Template = "Lapi.gears.debug.dump({0}, {1}, {2})"
    /// </summary>
    public static extern void PrintDump(object value, string key = null, int? depth = null);

    /// <summary>
    /// @CSharpLua.Template = "Lapi.gears.debug.print_warning({0})"
    /// </summary>
    public static extern void PrintWarning(string message);

    /// <summary>
    /// @CSharpLua.Template = "Lapi.gears.debug.print_error({0})"
    /// </summary>
    public static extern void PrintError(string message);
}

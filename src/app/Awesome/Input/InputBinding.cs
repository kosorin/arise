namespace Awesome.Input;

public abstract class InputData
{
}

public delegate void InputHandler<in TData>(TData data)
    where TData : InputData;

public delegate void InputHandler<in TData, in T1>(TData data, T1 a1)
    where TData : InputData;

public delegate void InputHandler<in TData, in T1, in T2>(TData data, T1 a1, T2 a2)
    where TData : InputData;

public delegate void InputHandler<in TData, in T1, in T2, in T3>(TData data, T1 a1, T2 a2, T3 a3)
    where TData : InputData;

public delegate void InputHandler<in TData, in T1, in T2, in T3, in T4>(TData data, T1 a1, T2 a2, T3 a3, T4 a4)
    where TData : InputData;

public class KeyBinding
{
    public KeyBinding(string[] modifiers, string key, InputHandler<TData> handler)
    {
    }
    
    public KeyBinding(string[] modifiers, string key, InputHandler<TData, T1> handler)
    {
    }
}

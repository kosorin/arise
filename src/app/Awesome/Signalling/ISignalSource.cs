namespace Awesome.Signalling;

public interface ISignalSource
{
    void Connect(string name, Delegate handler);

    void Disconnect(string name, Delegate handler);
}

namespace Awesome.Signalling;

public delegate void SignalHandler<in TSignal>(TSignal signal)
    where TSignal : ISignal;

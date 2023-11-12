namespace Awesome.Signal;

public delegate void SignalHandler<in TSignal>(TSignal signal)
    where TSignal : ISignal;

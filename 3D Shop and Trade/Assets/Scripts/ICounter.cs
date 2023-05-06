using System;

public interface ICounter<T>
{
    public event Action<T> CounterUpdated;
}
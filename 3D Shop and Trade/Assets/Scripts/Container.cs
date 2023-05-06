using System.Collections.Generic;

public interface Container<T>
{
    public List<T> AllObjects();

    void Remove(T obj);
}
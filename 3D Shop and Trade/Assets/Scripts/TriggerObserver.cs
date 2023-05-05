using UnityEngine;
using System;

public class TriggerObserver<T> : MonoBehaviour
{
    public event Action<T> OnTriggerEnterEvent; 
    public event Action<T> OnTriggerExitEvent; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out T obj))
        {
            Debug.Log("trigger");
            OnTriggerEnterEvent?.Invoke(obj);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out T obj))
        {
            OnTriggerExitEvent?.Invoke(obj);
        }
    }
}
using UnityEngine;
using System;

public class TriggerObserver<T> : MonoBehaviour
{
    public event Action OnTriggerEnterEvent; 
    public event Action OnTriggerExitEvent; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out T obj))
        {
            Debug.Log("trigger");
            OnTriggerEnterEvent?.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out T obj))
        {
            OnTriggerExitEvent?.Invoke();
        }
    }
}
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public UnityEvent DropEvent;

    void Drop()
    {
        DropEvent?.Invoke();
    }
}

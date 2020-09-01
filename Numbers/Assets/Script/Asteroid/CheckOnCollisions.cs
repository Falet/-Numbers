using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CheckOnCollisions : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _eventCollisionAsteroid;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        _eventCollisionAsteroid.Invoke();
    }
}

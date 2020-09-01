using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DeleteButton : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent HitEvent;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        HitEvent.Invoke();
    }
}

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public abstract class Class3DButton<T> : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    protected UnityEvent<GameObject> _hitEventForPlayerContr;//Эвент для движения игрока
    [SerializeField]
    protected UnityEvent<T> _hitEventForMechanic;//Эвент для счета результата
    [SerializeField]
    protected UnityEvent<GameObject> _hitEventForCreatorText;//Эвент для создания объектов цифр
    public GameObject TextNumOrSignOnScene;
    public T WhatButton;
    private bool _isLocked = false;
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if(!_isLocked)
        {
            _hitEventForPlayerContr.Invoke(pointerEventData.pointerPress);
            _hitEventForMechanic.Invoke(WhatButton);
            _hitEventForCreatorText.Invoke(TextNumOrSignOnScene);
        }
        else
        {

        }
    }
}

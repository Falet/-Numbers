using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject ObjText;
    
    private Vector3 _endPoint;
    [Range(0, 100)] public int Speed = 1;

    private void Start()
    {
        _endPoint = transform.position;
    }

    public void OnHitObject(GameObject Data)//Функция эвента при нажатии кнопки
    {
        _endPoint = Data.transform.position;//Получение конечной точки движения
        _endPoint[1] += (float)11.3;
    }

    private void Update()
    {
        if(_endPoint != transform.position)
            transform.position = Vector3.MoveTowards(transform.position,
                            _endPoint,
                            Speed * Time.deltaTime);
    }
}
using UnityEngine;
using System.Collections.Generic;
using System;

public class CreatorTextNumbersOrSign : MonoBehaviour
{
    public int CountObjInLine = 5;
    public int CountLine = 5;
    public float DistanceBetweenObjHorizon = 10.0f;
    public float DistanceBetweenObjVertical = 10.0f;
    private List<GameObject> _arrayStackObjNumbersAndSing = new List<GameObject>();
    private Vector3 _currentPosition;
    private Quaternion _rotationText;
    private int _countElementInLine = 0;
    private int _countLine = 0;
    private void Start()
    {
        _currentPosition = transform.position;
        _rotationText = transform.rotation;
    }

    public void AddTextObjOnScene(GameObject Number)
    {
        if (_arrayStackObjNumbersAndSing.Count != 0)
        {
            if (_arrayStackObjNumbersAndSing[_arrayStackObjNumbersAndSing.Count - 1].name != Number.name)
            {
                CalculationPostion(Number);
            }
        }
        else
            CalculationPostion(Number);
    }
    private void CalculationPostion(GameObject Number)
    {
        _currentPosition.x += DistanceBetweenObjHorizon;
        if (_countElementInLine == CountObjInLine)
        {
            if (_countLine > CountLine)
                Debug.Log(_countLine);
            _currentPosition.x -= CountObjInLine * DistanceBetweenObjHorizon;
            _currentPosition.y += DistanceBetweenObjVertical;
            _countElementInLine = 0;
            _countLine++;
        }
        _countElementInLine++;
        GameObject objText = Instantiate(Number, _currentPosition, _rotationText);
        objText.name = Number.name; 
        _arrayStackObjNumbersAndSing.Add(objText);
    }
    public void RemoveTextOnScene()
    {
        if(_arrayStackObjNumbersAndSing.Count !=0)
        {
            Destroy(_arrayStackObjNumbersAndSing[_arrayStackObjNumbersAndSing.Count - 1]);
            _arrayStackObjNumbersAndSing.RemoveAt(_arrayStackObjNumbersAndSing.Count - 1);
            if(_countElementInLine > 0)
            {
                _currentPosition.x -= DistanceBetweenObjHorizon;
                _countElementInLine--;
            }
                

            if(_countElementInLine == 0 && _countLine > 0)
            {
                _currentPosition.y -= DistanceBetweenObjVertical;
                _countLine--;
            }
        }    
    }
}

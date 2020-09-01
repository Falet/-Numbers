using UnityEngine;
using System.Collections;

public class MehanicNumbers : MonoBehaviour
{
    private ArrayList _arrayStackNumbersAndSing = new ArrayList();
    private int _result = 0;
    public void AddNumber(int Number)
    {
        if(_arrayStackNumbersAndSing.Count != 0)
        {
            if (_arrayStackNumbersAndSing[_arrayStackNumbersAndSing.Count - 1].GetType() != Number.GetType())
            {
                switch (_arrayStackNumbersAndSing[_arrayStackNumbersAndSing.Count - 1])
                {
                    case Operation.Plus:
                        _result += Number;
                        break;
                    case Operation.Subtract:
                        _result -= Number;
                        break;
                    case Operation.Multiply:
                        _result *= Number;
                        break;
                    case Operation.Divide:
                        _result /= Number;
                        break;
                }
                _arrayStackNumbersAndSing.Add(Number);
                Debug.Log(_result);
            }
        }
        else
            _arrayStackNumbersAndSing.Add(Number);
    }
    public void AddSign(Operation Sign)
    {
        if (_arrayStackNumbersAndSing.Count != 0)
        {
            if (_arrayStackNumbersAndSing[_arrayStackNumbersAndSing.Count - 1].GetType() != Sign.GetType())
                _arrayStackNumbersAndSing.Add(Sign);
        }
    }
    public void RemoveLastElement()
    {
        if(_arrayStackNumbersAndSing.Count != 0)
        {
            if (_arrayStackNumbersAndSing[_arrayStackNumbersAndSing.Count - 1].GetType() == typeof(int))
                switch (_arrayStackNumbersAndSing[_arrayStackNumbersAndSing.Count - 2])
                {
                    case Operation.Plus:
                        _result -= (int)_arrayStackNumbersAndSing[_arrayStackNumbersAndSing.Count - 1];
                        break;
                    case Operation.Subtract:
                        _result += (int)_arrayStackNumbersAndSing[_arrayStackNumbersAndSing.Count - 1];
                        break;
                    case Operation.Multiply:
                        _result /= (int)_arrayStackNumbersAndSing[_arrayStackNumbersAndSing.Count - 1];
                        break;
                    case Operation.Divide:
                        _result *= (int)_arrayStackNumbersAndSing[_arrayStackNumbersAndSing.Count - 1];
                        break;
                }
            _arrayStackNumbersAndSing.RemoveAt(_arrayStackNumbersAndSing.Count - 1);
        }
        Debug.Log(_result);
    }
}

using System.Collections.Generic;
using UnityEngine;
using System;
public class SpawnAsteroid : MonoBehaviour
{
    public int CountAsteroid;
    public List<GameObject> _arrayprefubAsteroid = new List<GameObject>();
    public float _incrementSpeedAsteroid;

    private int _counterForSpawn = 0;
    private CheckOnBarrier _checkotheasteroid;
    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private DictionaryAsteroid _componentdictionary;
    private FindExtremePoints _valueExtremePoints;
    private void Awake()
    {
        _componentdictionary = GetComponent<DictionaryAsteroid>();
        _valueExtremePoints = GetComponent<FindExtremePoints>();
        _checkotheasteroid = GetComponent<CheckOnBarrier>();
    }
    private GameObject ObjAsteroid;
    private void Start()
    {
        _startPosition = new Vector3(_valueExtremePoints.XRight, UnityEngine.Random.Range(_valueExtremePoints.YBot, _valueExtremePoints.YTop), 1.0f);
        _startRotation = Quaternion.Euler(0,0,0);
        ObjAsteroid = Instantiate(_arrayprefubAsteroid[UnityEngine.Random.Range(0, _arrayprefubAsteroid.Count - 1)], _startPosition, _startRotation);
        _componentdictionary.AttachedScriptsToObj.Add(ObjAsteroid, ObjAsteroid.GetComponent<Asteroid>());
        _componentdictionary.AttachedScriptsToObj[ObjAsteroid].UpperPointSpawn = _componentdictionary.AttachedScriptsToObj[ObjAsteroid].transform.position.y + (float)Math.Sqrt(Math.Pow(_componentdictionary.AttachedScriptsToObj[ObjAsteroid].GetAsteroidCirlce.bounds.size.y, 2) - Math.Pow(Math.Abs(_startPosition.x - transform.position.x), 2));
        if (_componentdictionary.AttachedScriptsToObj[ObjAsteroid].UpperPointSpawn > _valueExtremePoints.YTop)
        {
            _componentdictionary.AttachedScriptsToObj[ObjAsteroid].LockUpperPointSpawn = true;
        }
        else
        {
            _componentdictionary.AttachedScriptsToObj[ObjAsteroid].LockUpperPointSpawn = false;
        }
            
        _componentdictionary.AttachedScriptsToObj[ObjAsteroid].LowerPointSpawn = _componentdictionary.AttachedScriptsToObj[ObjAsteroid].transform.position.y - (float)Math.Sqrt(Math.Pow(_componentdictionary.AttachedScriptsToObj[ObjAsteroid].GetAsteroidCirlce.bounds.size.y, 2) - Math.Pow(Math.Abs(_startPosition.x - transform.position.x), 2));
        if (_componentdictionary.AttachedScriptsToObj[ObjAsteroid].LowerPointSpawn < _valueExtremePoints.YBot)
        {
            _componentdictionary.AttachedScriptsToObj[ObjAsteroid].LockLowerPointSpawn = true;
        }
        else
        {
            _componentdictionary.AttachedScriptsToObj[ObjAsteroid].LockLowerPointSpawn = false;
        }
        _componentdictionary.AttachedScriptsToObj[ObjAsteroid].GetMovementAsteroid.Speed = UnityEngine.Random.Range(7, 20);
        for(int count = 0; count< CountAsteroid; count++)
        {
            CreatAndSetPositionNewAsteroid();
        }
    }
    private void FixedUpdate()
    {
        /*List<GameObject> keys = new List<GameObject>(_componentdictionary.AttachedScriptsToObj.Keys);
        foreach (GameObject key in keys)
        {
            CreatAndSetPositionNewAsteroid(key);
        }*/
    }
    public void CreatAndSetPositionNewAsteroid()
    {
        List<GameObject> keys = new List<GameObject>(_componentdictionary.AttachedScriptsToObj.Keys);
        foreach (GameObject key in keys)
        {
            if (_componentdictionary.AttachedScriptsToObj[key].LockUpperPointSpawn == false)
            {
                _startPosition.x = _valueExtremePoints.XRight;
                _startPosition.y = _componentdictionary.AttachedScriptsToObj[key].UpperPointSpawn;
                ObjAsteroid = Instantiate(_arrayprefubAsteroid[UnityEngine.Random.Range(0, _arrayprefubAsteroid.Count - 1)], _startPosition, _startRotation);
                ObjAsteroid.name = _startPosition.y.ToString();
                _componentdictionary.AttachedScriptsToObj.Add(ObjAsteroid, ObjAsteroid.GetComponent<Asteroid>());
                _componentdictionary.AttachedScriptsToObj[ObjAsteroid].UpperPointSpawn = _componentdictionary.AttachedScriptsToObj[ObjAsteroid].transform.position.y + (float)Math.Sqrt(Math.Pow(_componentdictionary.AttachedScriptsToObj[ObjAsteroid].GetAsteroidCirlce.bounds.size.y, 2) - Math.Pow(Math.Abs(_startPosition.x - transform.position.x), 2));
                if (_componentdictionary.AttachedScriptsToObj[ObjAsteroid].UpperPointSpawn > _valueExtremePoints.YTop)
                    _componentdictionary.AttachedScriptsToObj[ObjAsteroid].LockUpperPointSpawn = true;
                else
                    _componentdictionary.AttachedScriptsToObj[ObjAsteroid].LockUpperPointSpawn = false;
                _componentdictionary.AttachedScriptsToObj[ObjAsteroid].LockLowerPointSpawn = true;
                _componentdictionary.AttachedScriptsToObj[ObjAsteroid].LowerParent = _componentdictionary.AttachedScriptsToObj[key];
                _componentdictionary.AttachedScriptsToObj[key].UpperParent = _componentdictionary.AttachedScriptsToObj[ObjAsteroid];
                _componentdictionary.AttachedScriptsToObj[ObjAsteroid].GetMovementAsteroid.Speed = UnityEngine.Random.Range(7, 20);
                _componentdictionary.AttachedScriptsToObj[key].LockUpperPointSpawn = true;
            }
            if (_componentdictionary.AttachedScriptsToObj[key].LockLowerPointSpawn == false)
            {
                _startPosition.x = _valueExtremePoints.XRight;
                _startPosition.y = _componentdictionary.AttachedScriptsToObj[key].LowerPointSpawn;
                ObjAsteroid = Instantiate(_arrayprefubAsteroid[UnityEngine.Random.Range(0, _arrayprefubAsteroid.Count - 1)], _startPosition, _startRotation);
                ObjAsteroid.name = _startPosition.y.ToString();
                _componentdictionary.AttachedScriptsToObj.Add(ObjAsteroid, ObjAsteroid.GetComponent<Asteroid>());
                _componentdictionary.AttachedScriptsToObj[ObjAsteroid].LockUpperPointSpawn = true;
                _componentdictionary.AttachedScriptsToObj[ObjAsteroid].LowerPointSpawn = _componentdictionary.AttachedScriptsToObj[ObjAsteroid].transform.position.y - (float)Math.Sqrt(Math.Pow(_componentdictionary.AttachedScriptsToObj[ObjAsteroid].GetAsteroidCirlce.bounds.size.y, 2) - Math.Pow(Math.Abs(_startPosition.x - transform.position.x), 2));
                if (_componentdictionary.AttachedScriptsToObj[ObjAsteroid].LowerPointSpawn < _valueExtremePoints.YBot)
                    _componentdictionary.AttachedScriptsToObj[ObjAsteroid].LockLowerPointSpawn = true;
                else
                    _componentdictionary.AttachedScriptsToObj[ObjAsteroid].LockLowerPointSpawn = false;
                _componentdictionary.AttachedScriptsToObj[ObjAsteroid].UpperParent = _componentdictionary.AttachedScriptsToObj[key];
                _componentdictionary.AttachedScriptsToObj[key].LowerParent = _componentdictionary.AttachedScriptsToObj[ObjAsteroid];
                _componentdictionary.AttachedScriptsToObj[ObjAsteroid].GetMovementAsteroid.Speed = UnityEngine.Random.Range(7, 20);
                _componentdictionary.AttachedScriptsToObj[key].LockLowerPointSpawn = true;
            }
        }
    }
    /*public void Respawn(GameObject Asteroid)
    {
        Asteroid.GetComponent<SpriteRenderer>().sprite = _arrayprefubAsteroid[UnityEngine.Random.Range(0, _arrayprefubAsteroid.Count - 1)].GetComponent<SpriteRenderer>().sprite;
        _startPosition.y = UnityEngine.Random.Range(_valueExtremePoints.YBot, _valueExtremePoints.YTop);
        Asteroid.transform.position = _startPosition;
    }*/

}

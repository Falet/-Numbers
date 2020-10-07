using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnAsteroid : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _arrayPrefubAsteroid = new List<GameObject>();
    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private FindExtremePoints _valueExtremePoints;
    private GameObject _currentCreatedAsteroid;
    private DictionaryAsteroid _dictionaryCurrentOfAsteroid;
    private Dictionary<Asteroid,bool> CheckFreedomPointForSpawn = new Dictionary<Asteroid, bool>();
    private Asteroid _asteroidFlyAway;
    private void Awake()
    {
        _valueExtremePoints = GetComponent<FindExtremePoints>();
        _dictionaryCurrentOfAsteroid = GetComponent<DictionaryAsteroid>();
    }
    private void Start()
    {
        _startPosition = new Vector3(_valueExtremePoints.XRight, UnityEngine.Random.Range(_valueExtremePoints.YBot, _valueExtremePoints.YTop), 1.0f);
        _startRotation = Quaternion.Euler(0, 0, 0);
        _currentCreatedAsteroid = Instantiate(_arrayPrefubAsteroid[UnityEngine.Random.Range(0, _arrayPrefubAsteroid.Count - 1)], _startPosition, _startRotation);
        _dictionaryCurrentOfAsteroid.AttachedScriptsToObj.Add(_currentCreatedAsteroid, _currentCreatedAsteroid.GetComponent<Asteroid>());
        _currentCreatedAsteroid.name = _startPosition.y.ToString();
        _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].UpperPointSpawn = _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].transform.position.y + (float)Math.Sqrt(Math.Pow(_dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].GetAsteroidCirlce.bounds.size.y, 2) - Math.Pow(Math.Abs(_startPosition.x - transform.position.x), 2));
        _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].LowerPointSpawn = _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].transform.position.y - (float)Math.Sqrt(Math.Pow(_dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].GetAsteroidCirlce.bounds.size.y, 2) - Math.Pow(Math.Abs(_startPosition.x - transform.position.x), 2));
        _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].GetMovementAsteroid.Speed = 2;
        for(int i=0;i<1;i++)
            CreateAsteroid();
    }
    private void CreateAsteroid()
    {
        List<GameObject> keys = new List<GameObject>(_dictionaryCurrentOfAsteroid.AttachedScriptsToObj.Keys);
        foreach (GameObject key in keys)
        {
            if(_dictionaryCurrentOfAsteroid.AttachedScriptsToObj[key].UpperNeighbour == null)
            {
                if(_dictionaryCurrentOfAsteroid.AttachedScriptsToObj[key].UpperPointSpawn < _valueExtremePoints.YTop)
                {
                    _startPosition.y = _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[key].UpperPointSpawn;
                    _currentCreatedAsteroid = Instantiate(_arrayPrefubAsteroid[UnityEngine.Random.Range(0, _arrayPrefubAsteroid.Count - 1)], _startPosition, _startRotation);
                    _dictionaryCurrentOfAsteroid.AttachedScriptsToObj.Add(_currentCreatedAsteroid, _currentCreatedAsteroid.GetComponent<Asteroid>());
                    _currentCreatedAsteroid.name = _startPosition.y.ToString();
                    _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].GetMovementAsteroid.Speed = 2;
                    _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].UpperPointSpawn = _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].transform.position.y + (float)Math.Sqrt(Math.Pow(_dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].GetAsteroidCirlce.bounds.size.y, 2) - Math.Pow(Math.Abs(_startPosition.x - transform.position.x), 2));
                    _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].LowerPointSpawn = _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].transform.position.y - (float)Math.Sqrt(Math.Pow(_dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].GetAsteroidCirlce.bounds.size.y, 2) - Math.Pow(Math.Abs(_startPosition.x - transform.position.x), 2));
                    _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[key].UpperNeighbour = _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid];
                    _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].LowerNeighbour = _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[key];
                }
            }
            if (_dictionaryCurrentOfAsteroid.AttachedScriptsToObj[key].LowerNeighbour == null)
            {
                if (_dictionaryCurrentOfAsteroid.AttachedScriptsToObj[key].LowerPointSpawn > _valueExtremePoints.YBot)
                {
                    _startPosition.y = _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[key].LowerPointSpawn;
                    _currentCreatedAsteroid = Instantiate(_arrayPrefubAsteroid[UnityEngine.Random.Range(0, _arrayPrefubAsteroid.Count - 1)], _startPosition, _startRotation);
                    _dictionaryCurrentOfAsteroid.AttachedScriptsToObj.Add(_currentCreatedAsteroid, _currentCreatedAsteroid.GetComponent<Asteroid>());
                    _currentCreatedAsteroid.name = _startPosition.y.ToString();
                    _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].GetMovementAsteroid.Speed = 2;
                    _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].UpperPointSpawn = _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].transform.position.y + (float)Math.Sqrt(Math.Pow(_dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].GetAsteroidCirlce.bounds.size.y, 2) - Math.Pow(Math.Abs(_startPosition.x - transform.position.x), 2));
                    _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].LowerPointSpawn = _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].transform.position.y - (float)Math.Sqrt(Math.Pow(_dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].GetAsteroidCirlce.bounds.size.y, 2) - Math.Pow(Math.Abs(_startPosition.x - transform.position.x), 2));
                    _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[key].LowerNeighbour = _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid];
                    _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].UpperNeighbour = _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[key];
                }
            }
        }
    }
    public void IfAsteroidFlyOut(GameObject AsteroidOut)
    {
        if (_dictionaryCurrentOfAsteroid.AttachedScriptsToObj.TryGetValue(AsteroidOut, out _asteroidFlyAway))
        {
            if (_asteroidFlyAway.UpperPointSpawn < _valueExtremePoints.YTop)
            {
                if (_asteroidFlyAway.UpperNeighbour != null)
                    _startPosition.y = _asteroidFlyAway.UpperNeighbour.LowerPointSpawn;
                else
                    _startPosition.y = _asteroidFlyAway.UpperPointSpawn;
                _currentCreatedAsteroid = Instantiate(_arrayPrefubAsteroid[UnityEngine.Random.Range(0, _arrayPrefubAsteroid.Count - 1)], _startPosition, _startRotation);
                _dictionaryCurrentOfAsteroid.AttachedScriptsToObj.Add(_currentCreatedAsteroid, _currentCreatedAsteroid.GetComponent<Asteroid>());
                _currentCreatedAsteroid.name = _startPosition.y.ToString();
                _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].GetMovementAsteroid.Speed = 2;
                _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].UpperPointSpawn = _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].transform.position.y + (float)Math.Sqrt(Math.Pow(_dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].GetAsteroidCirlce.bounds.size.y, 2) - Math.Pow(Math.Abs(_startPosition.x - transform.position.x), 2));
                _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].LowerPointSpawn = _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].transform.position.y - (float)Math.Sqrt(Math.Pow(_dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].GetAsteroidCirlce.bounds.size.y, 2) - Math.Pow(Math.Abs(_startPosition.x - transform.position.x), 2));
                _asteroidFlyAway.UpperNeighbour.LowerNeighbour = _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid];
                if (_asteroidFlyAway.LowerNeighbour != null)
                    _asteroidFlyAway.LowerNeighbour.UpperNeighbour = _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid];
                _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].UpperNeighbour = _asteroidFlyAway.UpperNeighbour;
                _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].LowerNeighbour = _asteroidFlyAway.LowerNeighbour;
                _dictionaryCurrentOfAsteroid.AttachedScriptsToObj.Remove(AsteroidOut);
            }
            if (_asteroidFlyAway.LowerPointSpawn > _valueExtremePoints.YBot)
            {
                if (_asteroidFlyAway.LowerNeighbour != null)
                {
                    _startPosition.y = _asteroidFlyAway.LowerNeighbour.UpperPointSpawn;
                    _currentCreatedAsteroid = Instantiate(_arrayPrefubAsteroid[UnityEngine.Random.Range(0, _arrayPrefubAsteroid.Count - 1)], _startPosition, _startRotation);
                    _dictionaryCurrentOfAsteroid.AttachedScriptsToObj.Add(_currentCreatedAsteroid, _currentCreatedAsteroid.GetComponent<Asteroid>());
                    _currentCreatedAsteroid.name = _startPosition.y.ToString();
                    _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].GetMovementAsteroid.Speed = 2;
                    _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].UpperPointSpawn = _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].transform.position.y + (float)Math.Sqrt(Math.Pow(_dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].GetAsteroidCirlce.bounds.size.y, 2) - Math.Pow(Math.Abs(_startPosition.x - transform.position.x), 2));
                    _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].LowerPointSpawn = _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].transform.position.y - (float)Math.Sqrt(Math.Pow(_dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].GetAsteroidCirlce.bounds.size.y, 2) - Math.Pow(Math.Abs(_startPosition.x - transform.position.x), 2));
                    if (_asteroidFlyAway.UpperNeighbour != null)
                        _asteroidFlyAway.UpperNeighbour.LowerNeighbour = _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid];
                    _asteroidFlyAway.LowerNeighbour.UpperNeighbour = _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid];
                    _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].UpperNeighbour = _asteroidFlyAway.UpperNeighbour;
                    _dictionaryCurrentOfAsteroid.AttachedScriptsToObj[_currentCreatedAsteroid].LowerNeighbour = _asteroidFlyAway.LowerNeighbour;
                    _dictionaryCurrentOfAsteroid.AttachedScriptsToObj.Remove(AsteroidOut);
                }
            }
        }
    }
}

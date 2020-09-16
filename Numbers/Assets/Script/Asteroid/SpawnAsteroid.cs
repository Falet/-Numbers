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
    private DictionaryAsteroid Componentdictionary;
    private FindExtremePoints _valueExtremePoints;
    private void Start()
    {
        Componentdictionary = GetComponent<DictionaryAsteroid>();
        _valueExtremePoints = GetComponent<FindExtremePoints>();
        _checkotheasteroid = GetComponent<CheckOnBarrier>();

        _startPosition = new Vector3(_valueExtremePoints.XRight + 10.0f, _valueExtremePoints.YTop, 1.0f);
        _startRotation = Quaternion.Euler(0,0,0);
        GameObject ObjAsteroid = Instantiate(_arrayprefubAsteroid[UnityEngine.Random.Range(0, _arrayprefubAsteroid.Count - 1)], _startPosition, _startRotation);
        Componentdictionary._attachedScriptsToObj.Add(ObjAsteroid, ObjAsteroid.GetComponent<Asteroid>());
        Componentdictionary._attachedScriptsToObj[ObjAsteroid].UpperPointSpawn = Componentdictionary._attachedScriptsToObj[ObjAsteroid].transform.position.y + (float)Math.Sqrt(Math.Pow(2 * (Componentdictionary._attachedScriptsToObj[ObjAsteroid].GetAsteroidCirlce.bounds.size.y / 2), 2) - Math.Pow(Math.Abs(_startPosition.x - transform.position.x), 2));
        if (Componentdictionary._attachedScriptsToObj[ObjAsteroid].LowerPointSpawn > _valueExtremePoints.YTop)
            Componentdictionary._attachedScriptsToObj[ObjAsteroid].LockUpperPointSpawn = false;
        Componentdictionary._attachedScriptsToObj[ObjAsteroid].LowerPointSpawn = Componentdictionary._attachedScriptsToObj[ObjAsteroid].transform.position.y - (float)Math.Sqrt(Math.Pow(2 * (Componentdictionary._attachedScriptsToObj[ObjAsteroid].GetAsteroidCirlce.bounds.size.y / 2), 2) - Math.Pow(Math.Abs(_startPosition.x - transform.position.x), 2));
        if (Componentdictionary._attachedScriptsToObj[ObjAsteroid].LowerPointSpawn < _valueExtremePoints.YBot)
            Componentdictionary._attachedScriptsToObj[ObjAsteroid].LockLowerPointSpawn = false;
        Componentdictionary._attachedScriptsToObj[ObjAsteroid].GetMovementAsteroid.Speed = UnityEngine.Random.Range(1, 7);
    }

    private void FixedUpdate()
    {
        foreach (KeyValuePair<GameObject, Asteroid> keyValue in Componentdictionary._attachedScriptsToObj)
        {
            if(keyValue.Value.LockUpperPointSpawn == false)
            {
                GameObject ObjAsteroid = Instantiate(_arrayprefubAsteroid[UnityEngine.Random.Range(0, _arrayprefubAsteroid.Count - 1)], _startPosition, _startRotation);
                Componentdictionary._attachedScriptsToObj.Add(ObjAsteroid, ObjAsteroid.GetComponent<Asteroid>());
                Componentdictionary._attachedScriptsToObj[ObjAsteroid].UpperPointSpawn = Componentdictionary._attachedScriptsToObj[ObjAsteroid].transform.position.y + (float)Math.Sqrt(Math.Pow(2 * (Componentdictionary._attachedScriptsToObj[ObjAsteroid].GetAsteroidCirlce.bounds.size.y / 2), 2) - Math.Pow(Math.Abs(_startPosition.x - transform.position.x), 2));
                if (Componentdictionary._attachedScriptsToObj[ObjAsteroid].LowerPointSpawn > _valueExtremePoints.YTop)
                    Componentdictionary._attachedScriptsToObj[ObjAsteroid].LockUpperPointSpawn = false;
                Componentdictionary._attachedScriptsToObj[ObjAsteroid].LowerPointSpawn = Componentdictionary._attachedScriptsToObj[ObjAsteroid].transform.position.y - (float)Math.Sqrt(Math.Pow(2 * (Componentdictionary._attachedScriptsToObj[ObjAsteroid].GetAsteroidCirlce.bounds.size.y / 2), 2) - Math.Pow(Math.Abs(_startPosition.x - transform.position.x), 2));
                Componentdictionary._attachedScriptsToObj[ObjAsteroid].LockLowerPointSpawn = true;
                Componentdictionary._attachedScriptsToObj[ObjAsteroid].GetMovementAsteroid.Speed = UnityEngine.Random.Range(1, 7);
            }
            else if(keyValue.Value.LockLowerPointSpawn == false)
            {
                GameObject ObjAsteroid = Instantiate(_arrayprefubAsteroid[UnityEngine.Random.Range(0, _arrayprefubAsteroid.Count - 1)], _startPosition, _startRotation);
                Componentdictionary._attachedScriptsToObj.Add(ObjAsteroid, ObjAsteroid.GetComponent<Asteroid>());
                Componentdictionary._attachedScriptsToObj[ObjAsteroid].UpperPointSpawn = Componentdictionary._attachedScriptsToObj[ObjAsteroid].transform.position.y + (float)Math.Sqrt(Math.Pow(2 * (Componentdictionary._attachedScriptsToObj[ObjAsteroid].GetAsteroidCirlce.bounds.size.y / 2), 2) - Math.Pow(Math.Abs(_startPosition.x - transform.position.x), 2));
                Componentdictionary._attachedScriptsToObj[ObjAsteroid].LockUpperPointSpawn = true;
                Componentdictionary._attachedScriptsToObj[ObjAsteroid].LowerPointSpawn = Componentdictionary._attachedScriptsToObj[ObjAsteroid].transform.position.y - (float)Math.Sqrt(Math.Pow(2 * (Componentdictionary._attachedScriptsToObj[ObjAsteroid].GetAsteroidCirlce.bounds.size.y / 2), 2) - Math.Pow(Math.Abs(_startPosition.x - transform.position.x), 2));
                if(Componentdictionary._attachedScriptsToObj[ObjAsteroid].LowerPointSpawn < _valueExtremePoints.YBot)
                    Componentdictionary._attachedScriptsToObj[ObjAsteroid].LockLowerPointSpawn = false;
                Componentdictionary._attachedScriptsToObj[ObjAsteroid].GetMovementAsteroid.Speed = UnityEngine.Random.Range(1, 7);
            }
        }
    }
    public void Respawn(GameObject Asteroid)
    {
        Asteroid.GetComponent<SpriteRenderer>().sprite = _arrayprefubAsteroid[UnityEngine.Random.Range(0, _arrayprefubAsteroid.Count - 1)].GetComponent<SpriteRenderer>().sprite;
        _startPosition.y = UnityEngine.Random.Range(_valueExtremePoints.YBot, _valueExtremePoints.YTop);
        Asteroid.transform.position = _startPosition;
    }

}

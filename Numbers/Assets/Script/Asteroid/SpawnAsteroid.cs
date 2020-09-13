using System.Collections.Generic;
using UnityEngine;

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
    /*private struct ObjAndSpeed
    {
        public GameObject Asteroid;
        public MoveAsteroid SpeedAsteroid;
        public CircleCollider2D AsteroidCirlce;
        public ObjAndSpeed(GameObject Asteroid, MoveAsteroid SpeedAsteroid, CircleCollider2D AsteroidCirlce)
        {
            this.Asteroid = Asteroid;
            this.SpeedAsteroid = SpeedAsteroid;
            this.AsteroidCirlce = AsteroidCirlce;
        }
        
    }*/
    //private List<Asteroid> _arrayAsteroid = new List<Asteroid>();
    private FindExtremePoints _valueExtremePoints;
    private void Start()
    {
        Componentdictionary = GetComponent<DictionaryAsteroid>();
        _valueExtremePoints = GetComponent<FindExtremePoints>();
        _checkotheasteroid = GetComponent<CheckOnBarrier>();

        _startPosition = new Vector3(_valueExtremePoints.XRight + 10.0f, _valueExtremePoints.YTop, 1.0f);
        _startRotation = Quaternion.Euler(0,0,0);
        
        for (_counterForSpawn = 0; _counterForSpawn < CountAsteroid; _counterForSpawn++)
        {
            _startPosition.y = Random.Range(_valueExtremePoints.YBot, _valueExtremePoints.YTop);
            GameObject ObjAsteroid = Instantiate(_arrayprefubAsteroid[Random.Range(0, _arrayprefubAsteroid.Count - 1)], _startPosition, _startRotation);

            Componentdictionary._attachedScriptsToObj.Add(ObjAsteroid, ObjAsteroid.GetComponent<Asteroid>());
            Componentdictionary._attachedScriptsToObj[ObjAsteroid].GetMovementAsteroid.Speed = Random.Range(1,7);

            _checkotheasteroid.SetSrartPositionForRayCast(Componentdictionary._attachedScriptsToObj[ObjAsteroid]);

        }
    }

    private void FixedUpdate()
    {

    }
    public void Respawn(GameObject Asteroid)
    {
        Asteroid.GetComponent<SpriteRenderer>().sprite = _arrayprefubAsteroid[Random.Range(0, _arrayprefubAsteroid.Count - 1)].GetComponent<SpriteRenderer>().sprite;
        _startPosition.y = Random.Range(_valueExtremePoints.YBot, _valueExtremePoints.YTop);
        Asteroid.transform.position = _startPosition;
    }

}

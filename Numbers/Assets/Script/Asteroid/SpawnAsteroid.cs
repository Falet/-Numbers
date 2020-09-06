using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    public int CountAsteroid = 1;
    public List<GameObject> _arrayprefubAsteroid = new List<GameObject>();
    public float _incrementSpeedAsteroid;

    private int _counterForSpawn = 0;
    private CheckOnBarrier _checkotheasteroid;
    private Vector3 _startPosition;
    private Vector2 StartpositionRayUpper;
    private Vector2 StartpositionRayLower;
    private Quaternion _startRotation;
    private Dictionary<GameObject, Asteroid> _attachedScriptsToObj = new Dictionary<GameObject, Asteroid>();
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
    private FindExtremePoints ValueExtremePoints;
    private void Start()
    {
        ValueExtremePoints = GetComponent<FindExtremePoints>();
        _checkotheasteroid = GetComponent<CheckOnBarrier>();

        _startPosition = new Vector3(ValueExtremePoints.XRight + 10.0f, ValueExtremePoints.YTop, 1.0f);
        _startRotation = Quaternion.Euler(0,0,0);
        
        for (_counterForSpawn = 0; _counterForSpawn < CountAsteroid; _counterForSpawn++)
        {
            _startPosition.y = Random.Range(ValueExtremePoints.YBot, ValueExtremePoints.YTop);
            GameObject ObjAsteroid = Instantiate(_arrayprefubAsteroid[Random.Range(0, _arrayprefubAsteroid.Count - 1)], _startPosition, _startRotation);

            _attachedScriptsToObj.Add(ObjAsteroid, ObjAsteroid.GetComponent<Asteroid>());
            _attachedScriptsToObj[ObjAsteroid].GetMovementAsteroid.Speed = 0;

            _checkotheasteroid.SetSrartPositionForRayCast(_attachedScriptsToObj[ObjAsteroid]);

        }
    }

    private void FixedUpdate()
    {

    }
    public void Respawn(GameObject Asteroid)
    {
        Asteroid.GetComponent<SpriteRenderer>().sprite = _arrayprefubAsteroid[Random.Range(0, _arrayprefubAsteroid.Count - 1)].GetComponent<SpriteRenderer>().sprite;
        _startPosition.y = Random.Range(ValueExtremePoints.YBot, ValueExtremePoints.YTop);
        Asteroid.transform.position = _startPosition;
    }

}

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
    private struct ObjAndSpeed
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
        
    }
    private List<Asteroid> _arrayAsteroid = new List<Asteroid>();
    private int _indexLastElement = 0;
    private FindExtremePoints ValueExtremePoints;
    private void Start()
    {
        ValueExtremePoints = GetComponent<FindExtremePoints>();
        _checkotheasteroid = GetComponent<CheckOnBarrier>();

        _startPosition = new Vector3(ValueExtremePoints.Xr + 10.0f, ValueExtremePoints.Yt, 1.0f);
        _startRotation = Quaternion.Euler(0,0,0);
        
        _indexLastElement = _arrayprefubAsteroid.Count - 1;
        for (_counterForSpawn = 0; _counterForSpawn < CountAsteroid; _counterForSpawn++)
        {
            _startPosition.y = Random.Range(ValueExtremePoints.Yb, ValueExtremePoints.Yt);
            GameObject ObjAsteroid = Instantiate(_arrayprefubAsteroid[Random.Range(0, _indexLastElement)], _startPosition, _startRotation);
            ObjAndSpeed ObjAndHisChangeSpeed = new ObjAndSpeed(ObjAsteroid, ObjAsteroid.GetComponent<MoveAsteroid>(), ObjAsteroid.GetComponent<CircleCollider2D>());  
            _arrayAsteroid.Add(ObjAsteroid.GetComponent<Asteroid>());
            
            
            _arrayAsteroid[_counterForSpawn].MovementAsteroid.Speed = 0;

            _checkotheasteroid.SetObjRayCast(_arrayAsteroid[_counterForSpawn]);
            //_arrayAsteroid[_counterForSpawn].SpeedAsteroid.Speed = 2.0f + _incrementSpeedAsteroid;
        }
    }

    private void FixedUpdate()
    {
        /*RaycastHit2D HitUpper = Physics2D.Raycast(StartpositionRayUpper, Vector2.right);
        RaycastHit2D HitLower = Physics2D.Raycast(StartpositionRayLower, Vector2.right);

        Debug.Log(HitUpper.collider.gameObject);*/
        //Debug.Log(HitLower.collider.gameObject);
    }
    public void Respawn(GameObject Asteroid)
    {
        Asteroid.GetComponent<SpriteRenderer>().sprite = _arrayprefubAsteroid[Random.Range(0, _arrayprefubAsteroid.Count - 1)].GetComponent<SpriteRenderer>().sprite;
        _startPosition.y = Random.Range(ValueExtremePoints.Yb, ValueExtremePoints.Yt);
        Asteroid.transform.position = _startPosition;
    }

}

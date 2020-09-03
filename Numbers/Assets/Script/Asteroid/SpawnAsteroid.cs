using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    public int CountAsteroid = 1;
    public List<GameObject> _arrayprefubAsteroid = new List<GameObject>();
    public float _incrementSpeedAsteroid;

    private int _counterForSpawn = 0;
    private float xr;
    private float yt;
    private float yb;
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
    private List<ObjAndSpeed> _arrayAsteroid = new List<ObjAndSpeed>();
    private int _indexLastElement = 0;
    private void Start()
    {
        RectTransform _changeTransform = transform as RectTransform;

        xr = _changeTransform.position.x + _changeTransform.sizeDelta.x / 2;
        yt = _changeTransform.position.y + _changeTransform.sizeDelta.y / 2;
        yb = _changeTransform.position.y - _changeTransform.sizeDelta.y / 2;

        _startPosition = new Vector3(xr + 10.0f, yt, 1.0f);
        _startRotation = Quaternion.Euler(0,0,0);
        
        _indexLastElement = _arrayprefubAsteroid.Count - 1;
        for (_counterForSpawn = 0; _counterForSpawn < CountAsteroid; _counterForSpawn++)
        {
            _startPosition.y = Random.Range(yb, yt);
            GameObject ObjAsteroid = Instantiate(_arrayprefubAsteroid[Random.Range(0, _indexLastElement)], _startPosition, _startRotation);
            ObjAndSpeed ObjAndHisChangeSpeed = new ObjAndSpeed(ObjAsteroid, ObjAsteroid.GetComponent<MoveAsteroid>(), ObjAsteroid.GetComponent<CircleCollider2D>());  
            _arrayAsteroid.Add(ObjAndHisChangeSpeed);
            StartpositionRayUpper = new Vector2(ObjAsteroid.transform.position.x, ObjAsteroid.transform.position.y + _arrayAsteroid[_arrayAsteroid.Count - 1].AsteroidCirlce.bounds.size.y / 2 + 0.1f);
            StartpositionRayLower = new Vector2(ObjAsteroid.transform.position.x, ObjAsteroid.transform.position.y - _arrayAsteroid[_arrayAsteroid.Count - 1].AsteroidCirlce.bounds.size.y / 2 - 0.1f);
            
            _arrayAsteroid[_counterForSpawn].SpeedAsteroid.Speed = 0;
            //_arrayAsteroid[_counterForSpawn].SpeedAsteroid.Speed = 2.0f + _incrementSpeedAsteroid;
        }
    }

    private void FixedUpdate()
    {
        RaycastHit2D HitUpper = Physics2D.Raycast(StartpositionRayUpper, Vector2.right);
        RaycastHit2D HitLower = Physics2D.Raycast(StartpositionRayLower, Vector2.right);

        Debug.Log(HitUpper.collider.gameObject);
        //Debug.Log(HitLower.collider.gameObject);
    }
    public void Respawn(GameObject Asteroid)
    {
        Asteroid.GetComponent<SpriteRenderer>().sprite = _arrayprefubAsteroid[Random.Range(0, _arrayprefubAsteroid.Count - 1)].GetComponent<SpriteRenderer>().sprite;
        _startPosition.y = Random.Range(yb, yt);
        Asteroid.transform.position = _startPosition;
    }

}

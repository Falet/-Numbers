using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    public int CountAsteroid = 5;
    public List<GameObject> _prefubAsteroid = new List<GameObject>();
    public float _incrementSpeedAsteroid;

    private int _counterForSpawn = 0;
    private float xr;
    private float yt;
    private float yb;
    private Vector3 _startPosition;
    private Quaternion _startRotation;
    private struct ObjAndSpeed
    {
        public GameObject Asteroid;
        public MoveAsteroid SpeedAsteroid;
        public ObjAndSpeed(GameObject Asteroid, MoveAsteroid SpeedAsteroid)
        {
            this.Asteroid = Asteroid;
            this.SpeedAsteroid = SpeedAsteroid;
        }
        
    }
    private List<ObjAndSpeed> _arrayAsteroid = new List<ObjAndSpeed>();
    private void Start()
    {
        RectTransform _changeTransform = transform as RectTransform;

        xr = _changeTransform.position.x + _changeTransform.sizeDelta.x / 2;
        yt = _changeTransform.position.y + _changeTransform.sizeDelta.y / 2;
        yb = _changeTransform.position.y - _changeTransform.sizeDelta.y / 2;

        _startPosition = new Vector3(xr, yt, 1.0f);
        _startRotation = Quaternion.Euler(0,0,0);

        for(int i = 0;i < CountAsteroid;i++)
        {
            _startPosition.y = Random.Range(yb, yt);
            GameObject ObjAsteroid = Instantiate(_prefubAsteroid[Random.Range(0, _prefubAsteroid.Count - 1)], _startPosition, _startRotation);
            ObjAndSpeed ObjAndHisChangeSpeed = new ObjAndSpeed(ObjAsteroid, ObjAsteroid.GetComponent<MoveAsteroid>());
            _arrayAsteroid.Add(ObjAndHisChangeSpeed);
            ObjAsteroid.GetComponent<MoveAsteroid>().Speed = 2.0f + _incrementSpeedAsteroid;
            _counterForSpawn++;
        }
    }

    private void Update()
    {

    }
    public void Respawn(GameObject Asteroid)
    {
        Asteroid.GetComponent<MoveAsteroid>().Speed = Random.Range(0.07f, 7.0f);
        Asteroid.GetComponent<SpriteRenderer>().sprite = _prefubAsteroid[Random.Range(0, _prefubAsteroid.Count - 1)].GetComponent<SpriteRenderer>().sprite;
        _startPosition.y = Random.Range(yb, yt);
        Asteroid.transform.position = _startPosition;
    }

}

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
    private Quaternion _rotationAsteroid;
    private MoveAsteroid _changeSpeed;
    private Transform _startTrans;
    
    private void Start()
    {
        //Debug.Log(transform.localPosition.x);
        //Debug.Log(transform.lossyScale.x);
        /*xr = transform.localPosition.x + transform.localScale.x;
        yt = transform.localPosition.y + transform.localScale.y;
        yb = transform.localPosition.y - transform.localScale.y;
        
        //Debug.Log(yt);
        _startPosition = new Vector3(xr, yb, 1.0f);
        _startTrans.rotation = Quaternion.Euler(0, 0, 0);
        _startTrans.position = _startPosition;*/
        RectTransform _changeTransform = transform as RectTransform;
        Debug.Log(_changeTransform.sizeDelta);
        //_startTrans.localScale = _Asteroid[_Asteroid.Count - 1].transform.localScale;
        //_startPosition = new Vector3(Random.Range(yb, yt), xr, 1.0f);
    }

    private void Update()
    {
        /*if(_counterForSpawn < CountAsteroid)
        {
            //_startPosition.y = Random.Range(yt, yb);
            if(_prefubAsteroid.Count == 0)
            {
                GameObject Asteroid = CreateAsteroid();
                Asteroid.GetComponent<CircleCollider2D>().radius += 1.5f;

            }
            else
            {
                CreateAsteroid();
                //if()
            }
            _counterForSpawn++;
        }*/
    }
    private GameObject CreateAsteroid()
    {
        GameObject _objAsteroid = Instantiate(_prefubAsteroid[Random.Range(0, _prefubAsteroid.Count - 1)], _startTrans);
        _changeSpeed = _objAsteroid.GetComponent<MoveAsteroid>();
        _changeSpeed.Speed = 2.0f + _incrementSpeedAsteroid;
        return _objAsteroid;
    }
    public void Respawn(GameObject Asteroid)
    {
        _changeSpeed.Speed = Random.Range(0.07f, 7.0f);
        _startPosition.y = Random.Range(yt, yb);
        Asteroid.transform.position = _startPosition;
    }

}

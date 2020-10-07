using UnityEngine;
using System;
using System.Collections.Generic;
public class Asteroid : MonoBehaviour
{
    private MoveAsteroid MovementAsteroid;
    private CircleCollider2D AsteroidCirlce;
    public MoveAsteroid GetMovementAsteroid { get { return MovementAsteroid; } }
    public CircleCollider2D GetAsteroidCirlce { get { return AsteroidCirlce; } }
    public float UpperPointSpawn;
    public bool LockUpperPointSpawn;
    public Asteroid UpperParent = null;
    public Asteroid LowerParent = null;
    public float LowerPointSpawn;
    public bool LockLowerPointSpawn;
    
    private GameObject SpawnBorder;
    private DictionaryAsteroid _componentdictionary;
    private Asteroid _asteroidHurt;
    private bool flag = true;
    private SpawnAsteroid ScriptSpawnBorder;
    private FindExtremePoints _valueExtremePoints;
    private void Awake()
    {
        MovementAsteroid = GetComponent<MoveAsteroid>();
        AsteroidCirlce = GetComponent<CircleCollider2D>();
        SpawnBorder = GameObject.Find("BorderSpawnAsteroids");
        ScriptSpawnBorder = SpawnBorder.GetComponent<SpawnAsteroid>();
        _valueExtremePoints = GetComponent<FindExtremePoints>();
        _componentdictionary = SpawnBorder.GetComponent<DictionaryAsteroid>();
    }

    private void FixedUpdate()
    {
        if(flag)
        {
            float cathetus = (float)Math.Abs(transform.position.x - SpawnBorder.transform.position.x);
            float hypotenuse =  GetAsteroidCirlce.bounds.size.y;
            float necessarycathetus = (float)Math.Sqrt(Math.Pow(hypotenuse, 2) - Math.Pow(cathetus, 2));
            //Debug.Log(necessarycathetus);
            /*if(necessarycathetus == float.NaN)
            {
                flag = false;
                _componentdictionary.AttachedScriptsToObj.Remove(gameObject);
                return;
            }*/
            if (cathetus > hypotenuse)
            {
                if (_componentdictionary.AttachedScriptsToObj.TryGetValue(gameObject, out _asteroidHurt))
                {
                    if (_asteroidHurt.LowerParent != null && _asteroidHurt.UpperParent != null)
                    {
                        if (UnityEngine.Random.Range(0, 1) == 1)
                        {
                            //if(_asteroidHurt.UpperParent.LowerPointSpawn > _valueExtremePoints.YBot)
                                _asteroidHurt.UpperParent.LockLowerPointSpawn = false;
                            _asteroidHurt.LowerParent.LockUpperPointSpawn = true;
                        }
                        else
                        {
                            //if (_asteroidHurt.LowerParent.UpperPointSpawn < _valueExtremePoints.YTop)
                                _asteroidHurt.LowerParent.LockUpperPointSpawn = false;
                            _asteroidHurt.UpperParent.LockLowerPointSpawn = true;
                        }
                    }
                    else if (_asteroidHurt.UpperParent != null)
                    {
                        //if (_asteroidHurt.UpperParent.LowerPointSpawn > _valueExtremePoints.YBot)
                            _asteroidHurt.UpperParent.LockLowerPointSpawn = false;
                    }
                    else if (_asteroidHurt.LowerParent != null)
                    {
                        //if (_asteroidHurt.LowerParent.UpperPointSpawn < _valueExtremePoints.YTop)
                            _asteroidHurt.LowerParent.LockUpperPointSpawn = false;
                    }
                    Debug.LogFormat("{0},{1}", _asteroidHurt.UpperParent, _asteroidHurt.LowerParent);
                    ScriptSpawnBorder.CreatAndSetPositionNewAsteroid();
                    _componentdictionary.AttachedScriptsToObj.Remove(gameObject);
                    flag = false;
                }
            }
            UpperPointSpawn = transform.position.y + necessarycathetus;
            LowerPointSpawn = transform.position.y - necessarycathetus;
        }
        
    }
}

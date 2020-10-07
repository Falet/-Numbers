using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float UpperPointSpawn;
    public Asteroid UpperNeighbour = null;
    public float LowerPointSpawn;
    public Asteroid LowerNeighbour = null;
    public SpawnAsteroid BorderOfSpawnAsteroid;
    private MoveAsteroid MovementAsteroid;
    private CircleCollider2D AsteroidCirlce;
    public MoveAsteroid GetMovementAsteroid { get { return MovementAsteroid; } }
    public CircleCollider2D GetAsteroidCirlce { get { return AsteroidCirlce; } }
    private bool flag;
    private DictionaryAsteroid _dictionaryCurrentOfAsteroid;
    void Awake()
    {
        MovementAsteroid = GetComponent<MoveAsteroid>();
        AsteroidCirlce = GetComponent<CircleCollider2D>();
        BorderOfSpawnAsteroid = GameObject.Find("SpawnBorder").GetComponent<SpawnAsteroid>();
        _dictionaryCurrentOfAsteroid = GameObject.Find("SpawnBorder").GetComponent<DictionaryAsteroid>();
    }
    private void Start()
    {
        flag = true;
    }
    void FixedUpdate()
    {
        if (flag)
        {
            float cathetus = (float)Math.Abs(transform.position.x - BorderOfSpawnAsteroid.transform.position.x);
            float hypotenuse = GetAsteroidCirlce.bounds.size.y;
            float necessarycathetus = (float)Math.Sqrt(Math.Pow(hypotenuse, 2) - Math.Pow(cathetus, 2));
            if (necessarycathetus == Double.NaN)
            {
                flag = false;
                return;
            }
            if (cathetus >= hypotenuse)
            {
                BorderOfSpawnAsteroid.IfAsteroidFlyOut(gameObject);
                flag = false;
            }
            UpperPointSpawn = transform.position.y + necessarycathetus;
            LowerPointSpawn = transform.position.y - necessarycathetus;
        }
    }
}

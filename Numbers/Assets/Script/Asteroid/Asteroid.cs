using UnityEngine;
using System;

public class Asteroid : MonoBehaviour
{
    private MoveAsteroid MovementAsteroid;
    private CircleCollider2D AsteroidCirlce;
    public MoveAsteroid GetMovementAsteroid { get { return MovementAsteroid; } }
    public CircleCollider2D GetAsteroidCirlce { get { return AsteroidCirlce; } }
    public float UpperPointSpawn;
    public bool LockUpperPointSpawn;
    public float LowerPointSpawn;
    public bool LockLowerPointSpawn;
    private GameObject SpawnBorder;
    private void Awake()
    {
        MovementAsteroid = GetComponent<MoveAsteroid>();
        AsteroidCirlce = GetComponent<CircleCollider2D>();
        SpawnBorder = GameObject.Find("BorderSpawnAsteroids");
    }

    private void FixedUpdate()
    {
        UpperPointSpawn = transform.position.y + (float)Math.Sqrt(Math.Pow(2 * (GetAsteroidCirlce.bounds.size.y / 2), 2) - Math.Pow(Math.Abs(transform.position.x - SpawnBorder.transform.position.x), 2));
        LowerPointSpawn = transform.position.y - (float)Math.Sqrt(Math.Pow(2 * (GetAsteroidCirlce.bounds.size.y / 2), 2) - Math.Pow(Math.Abs(transform.position.x - SpawnBorder.transform.position.x), 2));
    }
}

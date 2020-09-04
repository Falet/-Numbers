using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public MoveAsteroid MovementAsteroid { private set { MovementAsteroid = value; } get { return MovementAsteroid; } }
    public CircleCollider2D AsteroidCirlce { private set { AsteroidCirlce = value; } get { return AsteroidCirlce; } }

    private void Start()
    {
        MovementAsteroid = GetComponent<MoveAsteroid>();
        AsteroidCirlce = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        
    }
}

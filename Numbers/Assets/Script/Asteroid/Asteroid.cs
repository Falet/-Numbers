using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private MoveAsteroid MovementAsteroid;
    private CircleCollider2D AsteroidCirlce;
    public MoveAsteroid GetMovementAsteroid { get { return MovementAsteroid; } }
    public CircleCollider2D GetAsteroidCirlce { get { return AsteroidCirlce; } }
    private void Awake()
    {
        MovementAsteroid = GetComponent<MoveAsteroid>();
        AsteroidCirlce = GetComponent<CircleCollider2D>();
    }
    

}

using UnityEngine;

public class MoveAsteroid : MonoBehaviour
{
    [Range(0.0f, 7.0f)]
    public float Speed = 2.0f;
    private void FixedUpdate()
    {
        MovementLogic();
    }
    private void MovementLogic()
    {
        Vector3 movement = new Vector3(1.0f, 0.0f, 0.0f);
        transform.Translate(movement * Speed * Time.fixedDeltaTime);
    }
}

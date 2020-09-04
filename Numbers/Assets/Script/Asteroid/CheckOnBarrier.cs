using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOnBarrier : MonoBehaviour
{
    private Vector2 StartpositionRayUpper;
    private Vector2 StartpositionRayLower;
    void Start()
    {
        
    }

    public void SetObjRayCast(Asteroid ObjAsteroid)
    {
        StartpositionRayUpper = new Vector2(ObjAsteroid.transform.position.x, ObjAsteroid.transform.position.y + ObjAsteroid.AsteroidCirlce.bounds.size.y / 2 + 0.1f);
        StartpositionRayLower = new Vector2(ObjAsteroid.transform.position.x, ObjAsteroid.transform.position.y - ObjAsteroid.AsteroidCirlce.bounds.size.y / 2 - 0.1f);

    }
    void FixedUpdate()
    {
        RaycastHit2D HitUpper = Physics2D.Raycast(StartpositionRayUpper, Vector2.right);
        RaycastHit2D HitLower = Physics2D.Raycast(StartpositionRayLower, Vector2.right);
        Debug.Log(HitUpper.collider.gameObject);
    }
}

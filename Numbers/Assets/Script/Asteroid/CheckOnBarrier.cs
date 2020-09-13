using UnityEngine;
using System;


public class CheckOnBarrier : MonoBehaviour
{
    public float Complexity = 200.0f;
    private Vector2 _startpositionRayUpper;
    private Vector2 _startpositionRayLower;
    private DictionaryAsteroid _compenentdictionary;
    private Asteroid _asteroidTouch;
    private const float _inaccuracyCollider = 0.1f;
    private GameObject _asteroidForChangePosotion;
    void Start()
    {
        _compenentdictionary = GetComponent<DictionaryAsteroid>();
    }

    public void SetSrartPositionForRayCast(Asteroid ObjAsteroid)
    {

        _startpositionRayUpper = new Vector2(ObjAsteroid.transform.position.x, ObjAsteroid.transform.position.y + ObjAsteroid.GetAsteroidCirlce.bounds.size.y / 2 + _inaccuracyCollider);
        _startpositionRayLower = new Vector2(ObjAsteroid.transform.position.x, ObjAsteroid.transform.position.y - ObjAsteroid.GetAsteroidCirlce.bounds.size.y / 2 - _inaccuracyCollider);
        _asteroidForChangePosotion = ObjAsteroid.gameObject;
    }
    private void FixedUpdate()
    {
        if (_startpositionRayUpper != Vector2.zero && _startpositionRayLower != Vector2.zero)
        {
            RaycastHit2D HitUpper = Physics2D.Raycast(_startpositionRayUpper, Vector2.right, Complexity);
            RaycastHit2D HitLower = Physics2D.Raycast(_startpositionRayLower, Vector2.right, Complexity);
            if (HitUpper.collider.gameObject != null && HitLower.collider.gameObject != null)
            {
                if (UnityEngine.Random.Range(0, 1) == 1)
                {
                    SetNewPositionAsteroid(HitUpper);
                }
                else
                {
                    SetNewPositionAsteroid(HitLower);
                }
            }
            else if (HitUpper.collider.gameObject != null)
            {
                SetNewPositionAsteroid(HitUpper);
            }
            else if (HitLower.collider.gameObject != null)
            {
                SetNewPositionAsteroid(HitLower);
            }
        }
    }
    private void SetNewPositionAsteroid(RaycastHit2D RaycastFromAsteroid)
    {
        if (_compenentdictionary._attachedScriptsToObj.TryGetValue(RaycastFromAsteroid.collider.gameObject, out _asteroidTouch))
        {
            float distancebetweencenter = Math.Abs(RaycastFromAsteroid.collider.transform.position.y - _asteroidForChangePosotion.transform.position.y);// расстояние между центрами для смещения
            _asteroidForChangePosotion.transform.position = new Vector3(_asteroidForChangePosotion.transform.position.x, _asteroidTouch.GetAsteroidCirlce.bounds.size.y / 2 + distancebetweencenter + _inaccuracyCollider, 1.0f);
        }
    }
}

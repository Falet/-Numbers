using UnityEngine;
using System;


public class CheckOnBarrier : MonoBehaviour
{
    public float Complexity = 200.0f;
    public float MaxSpeed = 10.0f;
    public float MinSpeed = 1.0f;
    private Vector2 _startpositionRayUpper;
    private Vector2 _startpositionRayLower;
    private DictionaryAsteroid _compenentdictionary;
    private Asteroid _asteroidTouch;
    private const float _inaccuracyCollider = 0.1f;
    private Asteroid _asteroidForChangePosotion;
    void Start()
    {
        _compenentdictionary = GetComponent<DictionaryAsteroid>();
    }

    public void SetSrartPositionForRayCast(Asteroid ObjAsteroid)
    {
        _startpositionRayUpper = new Vector2(ObjAsteroid.transform.position.x, ObjAsteroid.transform.position.y + ObjAsteroid.GetAsteroidCirlce.bounds.size.y / 2 + _inaccuracyCollider);
        _startpositionRayLower = new Vector2(ObjAsteroid.transform.position.x, ObjAsteroid.transform.position.y - ObjAsteroid.GetAsteroidCirlce.bounds.size.y / 2 - _inaccuracyCollider);
        _asteroidForChangePosotion = ObjAsteroid;
        RaycastHit2D HitUpper = Physics2D.Raycast(_startpositionRayUpper, Vector2.right);
        RaycastHit2D HitLower = Physics2D.Raycast(_startpositionRayLower, Vector2.right);
        if (HitUpper.collider.gameObject != null && HitLower.collider.gameObject != null)
        {
            if (UnityEngine.Random.Range(0, 1) == 1)
            {
                if (_compenentdictionary.AttachedScriptsToObj.TryGetValue(HitUpper.collider.gameObject, out _asteroidTouch))
                {
                    _asteroidForChangePosotion.GetMovementAsteroid.Speed = _asteroidTouch.GetMovementAsteroid.Speed;
                }
            }
            else
            {
                if (_compenentdictionary.AttachedScriptsToObj.TryGetValue(HitLower.collider.gameObject, out _asteroidTouch))
                {
                    _asteroidForChangePosotion.GetMovementAsteroid.Speed = _asteroidTouch.GetMovementAsteroid.Speed;
                }
            }
        }
        else if (HitUpper.collider.gameObject != null)
        {
            if (_compenentdictionary.AttachedScriptsToObj.TryGetValue(HitUpper.collider.gameObject, out _asteroidTouch))
            {
                _asteroidForChangePosotion.GetMovementAsteroid.Speed = _asteroidTouch.GetMovementAsteroid.Speed;
            }
        }
        else if (HitLower.collider.gameObject != null)
        {
            if (_compenentdictionary.AttachedScriptsToObj.TryGetValue(HitLower.collider.gameObject, out _asteroidTouch))
            {
                _asteroidForChangePosotion.GetMovementAsteroid.Speed = _asteroidTouch.GetMovementAsteroid.Speed;
            }
        }
        else
            _asteroidForChangePosotion.GetMovementAsteroid.Speed = UnityEngine.Random.Range(MinSpeed,MaxSpeed);
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
                    if (_compenentdictionary.AttachedScriptsToObj.TryGetValue(HitUpper.collider.gameObject, out _asteroidTouch))
                    {
                        _asteroidForChangePosotion.GetMovementAsteroid.Speed = _asteroidTouch.GetMovementAsteroid.Speed;
                    }
                }
                else
                {
                    if (_compenentdictionary.AttachedScriptsToObj.TryGetValue(HitLower.collider.gameObject, out _asteroidTouch))
                    {
                        _asteroidForChangePosotion.GetMovementAsteroid.Speed = _asteroidTouch.GetMovementAsteroid.Speed;
                    }
                }
            }
            else if (HitUpper.collider.gameObject != null)
            {
                SetNewPositionAsteroid(HitUpper, true);
            }
            else if (HitLower.collider.gameObject != null)
            {
                SetNewPositionAsteroid(HitLower, false);
            }
        }
    }
    private void SetNewPositionAsteroid(RaycastHit2D RaycastFromAsteroid,bool FlagSign)
    {
        if(FlagSign)
        {
            if (_compenentdictionary.AttachedScriptsToObj.TryGetValue(RaycastFromAsteroid.collider.gameObject, out _asteroidTouch))
            {
                /*float distancebetweencenter = Math.Abs(RaycastFromAsteroid.collider.transform.position.y - _asteroidForChangePosotion.transform.position.y);// расстояние между центрами для смещения
                _asteroidForChangePosotion.transform.position = new Vector3(_asteroidForChangePosotion.transform.position.x, _asteroidTouch.GetAsteroidCirlce.bounds.size.y / 2 + distancebetweencenter + _inaccuracyCollider, 1.0f);*/
                _asteroidForChangePosotion.GetMovementAsteroid.Speed = _asteroidTouch.GetMovementAsteroid.Speed;
            }
        }
        else
        {
            if (_compenentdictionary.AttachedScriptsToObj.TryGetValue(RaycastFromAsteroid.collider.gameObject, out _asteroidTouch))
            {
                float distancebetweencenter = Math.Abs(RaycastFromAsteroid.collider.transform.position.y - _asteroidForChangePosotion.transform.position.y);// расстояние между центрами для смещения
                _asteroidForChangePosotion.transform.position = new Vector3(_asteroidForChangePosotion.transform.position.x, _asteroidTouch.GetAsteroidCirlce.bounds.size.y / 2 - distancebetweencenter - _inaccuracyCollider, 1.0f);
            }
        }
        _startpositionRayUpper = Vector2.zero;
        _startpositionRayLower = Vector2.zero;

    }
}

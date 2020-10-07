using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOnBarrier1 : MonoBehaviour
{
    private Asteroid AsteroidSript;
    private DictionaryAsteroid _componentdictionary;
    private Asteroid _asteroidHurt;
    private void Awake()
    {
        AsteroidSript = GetComponent<Asteroid>();
        _componentdictionary = GameObject.Find("BorderSpawnAsteroids").GetComponent<DictionaryAsteroid>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Destroy");
        if (_componentdictionary.AttachedScriptsToObj.TryGetValue(collision.gameObject, out _asteroidHurt))
        {
            if(AsteroidSript.LockUpperPointSpawn == false)
            {
                _asteroidHurt.LockLowerPointSpawn = true;
                _asteroidHurt.LowerParent = AsteroidSript.LowerParent;
                AsteroidSript.LowerParent.UpperParent = _asteroidHurt;
            }  
            else if(AsteroidSript.LockLowerPointSpawn == false)
            {
                _asteroidHurt.LockUpperPointSpawn = true;
                _asteroidHurt.UpperParent = AsteroidSript.UpperParent;
                AsteroidSript.UpperParent.LowerParent = _asteroidHurt;
            }
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
    }
}

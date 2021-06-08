using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spacegame.Map
{
    public class AsteroidSpawning : MonoBehaviour
    {
        //private ObjectPooling objectPooling;
        [SerializeField] private List<GameObject> asteroids = new List<GameObject>();

        [Header("Spawn Boundaries")]
        [SerializeField] private float minX, maxX;
        [SerializeField] private float minY, maxY;
        [SerializeField] private float minZ, maxZ;
        [SerializeField] private int asteroidCount;
        private Vector3 newSpawn;
        
        // Start is called before the first frame update
        void Start()
        {
            SpawnAsteroids();
        }

        // Update is called once per frame
        void SpawnAsteroids()
        {
            for (int i = 0; i < asteroidCount; i++)
            {
                GameObject newAsteroid = asteroids[Random.Range(0, asteroids.Count + 1)];
             //   objectPooling.Spawn(newAsteroid, null);
            }
        }
    }
}
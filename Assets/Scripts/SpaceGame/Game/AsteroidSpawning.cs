using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spacegame.Map
{
    public class AsteroidSpawning : MonoBehaviour
    {
        [SerializeField]
        private ObjectPooling<Transform> objectPooling;
        [SerializeField] private List<GameObject> asteroids = new List<GameObject>();

        [Header("Spawn Boundaries")] 
        [SerializeField]
        private float minX;
        [SerializeField] private float maxX;
        [SerializeField] private float minY, maxY;
        [SerializeField] private float minZ, maxZ;
        [SerializeField] private int asteroidCount;
        private Vector3 newSpawn;
        
        // Start is called before the first frame update
        void Start()
        {
            objectPooling = new ObjectPooling<Transform>();
            SpawnAsteroids();
        }

        // Update is called once per frame
        void SpawnAsteroids()
        {
            for (int i = 0; i < asteroidCount; i++)
            {
                GameObject newAsteroid = asteroids[Random.Range(0, asteroids.Count -1)];
                Vector3 newSpawnPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY),
                    Random.Range(minZ, maxZ));
                objectPooling.Spawn(newAsteroid.transform,newSpawnPos,Quaternion.Euler(0,0,0), null);
            }
        }
    }
}
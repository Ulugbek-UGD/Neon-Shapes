using UnityEngine;

namespace NeonShapes
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField, Range(1.3f, 5)] private float spawnRate = 3;
        [Space(10)]
        [SerializeField] private GameObject[] enemies;
        [SerializeField] private Transform[] spawnPoints;
        [Space(10)]
        [SerializeField] private Transform spawnContainer;
        
        //==================================================
        public void StartSpawn()
        {
            spawnRate = 3;
            Spawn();
        }
        //==================================================
        public void StopSpawn()
        {
            CancelInvoke(nameof(Spawn));
        }
        //==================================================
        public void SpeedUpSpawn()
        {
            if (spawnRate > 1.0f)
            {
                spawnRate -= 0.1f;
            }
        }
        //==================================================
        private void Spawn()
        {
            var randomEnemy = enemies[Random.Range(0, enemies.Length)];
            var randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            Instantiate(randomEnemy, randomPoint, Quaternion.identity, spawnContainer);
            Invoke(nameof(Spawn), spawnRate);
        }
        //==================================================
    }
}
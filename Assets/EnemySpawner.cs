using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 3.1f, 70f);
    }
    void Update()
    {

    }
    void SpawnEnemy()
    {
        int bats = 0;
        int worms = 0;
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);
            if(randomEnemy == 0)
            {
                bats++;
                if(bats > 3)
                {
                    randomEnemy = 1;
                }
            }
            else
            {
                worms++;
            }
            Instantiate(enemyPrefabs[randomEnemy], spawnPoints[i].position, Quaternion.identity);

        }

    }
}
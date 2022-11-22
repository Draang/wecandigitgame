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
        InvokeRepeating("SpawnEnemy", 4f, 60f);
    }
    void Update()
    {

    }
    void SpawnEnemy()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int randomEnemy = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[randomEnemy], spawnPoints[i].position, Quaternion.identity);

        }

    }
}
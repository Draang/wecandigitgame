using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    [SerializeField] float invokeAfter=3.1f;
    [SerializeField] float repeatAfter=70f;
    int lives=3;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", invokeAfter, repeatAfter);
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
            int randomEnemy = Random.Range(0, enemyPrefabs.Length-1);
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
    private void OnTriggerEnter2D(Collider2D other) {
            if(other.tag=="bullet" && lives>0){
                lives--;
            }else{
                Destroy(gameObject);
            }

    }
}
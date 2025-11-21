using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;


    [SerializeField] private float minTimeBtwSpawn;
    [SerializeField] private float decreaseTime;

    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (timeBtwSpawn <= 0)
            {
                GameObject randomEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                Instantiate(randomEnemy, randomSpawnPoint.position, Quaternion.identity);

                if (startTimeBtwSpawn > minTimeBtwSpawn)
                {
                    startTimeBtwSpawn -= decreaseTime;
                }

                timeBtwSpawn = startTimeBtwSpawn;
            }
            else
            {
                timeBtwSpawn -= Time.deltaTime;
            }
        }
    }
}

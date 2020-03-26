using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyprefab;
    public GameObject explodingEnemyPrefab;
    public Transform spawner;
    public int maxEnemies = 1;
    public int currentEnemies = 0;
    public int currentExplodingEnemies = 0;
    public float spawnActivateDistance = 10;
    public bool explodingEnemySpawner = false;
    public bool enemySpawner = false;
    public float spawnCoolDown = 5f;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemies < maxEnemies && currentExplodingEnemies < maxEnemies)
        {
            if ((spawner.position - Player.Instance.transform.position).magnitude < spawnActivateDistance)
            {
                if (Time.time - timer > spawnCoolDown)
                {
                    if (enemySpawner)
                        SpawnEnemies();
                    else if (explodingEnemySpawner)
                        SpawnExplodingEnemies();
                }
            }
        } 
    }

    void SpawnEnemies() 
    {
        Instantiate(enemyprefab, spawner.position, spawner.rotation);
        currentEnemies++;
        timer = Time.time;
    }

    void SpawnExplodingEnemies() 
    {
        Instantiate(explodingEnemyPrefab, spawner.position, spawner.rotation);
        currentExplodingEnemies++;
        timer = Time.time;
    }
}

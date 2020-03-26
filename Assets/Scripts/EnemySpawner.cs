using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyprefab;
    public Transform spawner;
    public int maxEnemies = 1;
    public int currentEnemies = 0;
    public float spawnActivateDistance = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemies < maxEnemies)
        {
            if ((spawner.position - Player.Instance.transform.position).magnitude < spawnActivateDistance)
            {
                Instantiate(enemyprefab, spawner.position, spawner.rotation);
                currentEnemies++;
            }
        }
        
    }
}

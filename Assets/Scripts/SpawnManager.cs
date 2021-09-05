using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject catchEnemyPrefab;
    public Vector2 spawnRangeX;

    private float m_SpawnInterval = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnEvader), 0, m_SpawnInterval);
        InvokeRepeating(nameof(SpawnCatcher), 1, m_SpawnInterval + 1.30f);
    }

    private void SpawnCatcher()
    {
        SpawnEnemy(EnemyType.Catcher);
    }

    private void SpawnEvader()
    {
        SpawnEnemy(EnemyType.Evader);

    }

    private void SpawnEnemy(EnemyType enemyType)
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnRangeX.x, spawnRangeX.y),
            enemyPrefab.transform.position.y,
            enemyPrefab.transform.position.z);

        if(enemyType == EnemyType.Evader)
        {
            Instantiate(
                enemyPrefab,
                spawnPosition,
                enemyPrefab.transform.rotation);
        }
        else
        {
            Instantiate(
                catchEnemyPrefab,
                spawnPosition,
                catchEnemyPrefab.transform.rotation);
        }
        

    }

}

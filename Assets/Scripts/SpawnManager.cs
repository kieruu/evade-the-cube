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
        InvokeRepeating(nameof(SpawnEnemy), 0, m_SpawnInterval);
        InvokeRepeating(nameof(SpawnCatchEnemy), 1.0f, m_SpawnInterval + 1.0f);
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnRangeX.x, spawnRangeX.y),
            enemyPrefab.transform.position.y,
            enemyPrefab.transform.position.z);

        Instantiate(
            enemyPrefab,
            spawnPosition,
            enemyPrefab.transform.rotation);

    }

    private void SpawnCatchEnemy()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnRangeX.x, spawnRangeX.y),
            catchEnemyPrefab.transform.position.y,
            catchEnemyPrefab.transform.position.z);

        Instantiate(
            catchEnemyPrefab,
            spawnPosition,
            catchEnemyPrefab.transform.rotation);

    }
}

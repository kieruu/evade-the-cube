using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public Vector2 spawnRangeX;

    private float m_SpawnInterval = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, m_SpawnInterval);
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
}

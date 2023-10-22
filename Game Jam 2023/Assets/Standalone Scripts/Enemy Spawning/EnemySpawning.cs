using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public static EnemySpawning Instance;

    private Vector2 minBound;
    private Vector2 maxBound;

    private GameObject[] spawnedEnemies;
    private int[] waveConfig;

    private bool waveSpawned;
    private int currentWave;
    private int waveCount;

    private void Awake()
    {
        Instance = this;

        currentWave = 0;
        waveCount = 0;
        waveSpawned = false;
    }

    private void Update()
    {
        if (!waveSpawned) return;

        if (!WaveCleared()) return;

        currentWave++;

        if (currentWave >= waveCount)
        {
            GateManager.Instance.ActivateGates(false);
            waveSpawned = false;
            return;
        }

        SpawnWave(waveConfig[currentWave]);
    }

    public void SetBounds(Vector2 min, Vector2 max)
    {
        minBound = min;
        maxBound = max;
    }

    public void StartSpawnWaves(int[] enemyCounts)
    {
        waveConfig = enemyCounts;
        waveCount = enemyCounts.Length;
        currentWave = 0;

        SpawnWave(enemyCounts[0]);

        waveSpawned = true;
    }

    public bool WavesCompleted()
    {
        if (currentWave < waveCount) return false;

        if (!WaveCleared()) return false;

        return true;
    }

    private void SpawnWave(int enemyCount)
    {
        spawnedEnemies = new GameObject[enemyCount];
        
        for(int n = 0; n < enemyCount; n++)
        {
            spawnedEnemies[n] = RandomEnemy();
            spawnedEnemies[n].SetActive(true);
            spawnedEnemies[n].transform.position = RandomPosition();
        }
    }

    private GameObject RandomEnemy()
    {
        ObjectPool enemyPool1 = PoolManager.EnemyPool1;
        ObjectPool enemyPool2 = PoolManager.EnemyPool2;

        float rng = Random.Range(0f, 1f);
        return rng < 0.5 ? enemyPool1.GetObject() : enemyPool2.GetObject();
    }

    private Vector2 RandomPosition()
    {
        float x = Random.Range(minBound.x, maxBound.x);
        float y = Random.Range(minBound.y, maxBound.y);

        return new Vector2(x, y);
    }

    private bool WaveCleared()
    {
        for (int n = 0; n < spawnedEnemies.Length; n++)
        {
            if (spawnedEnemies[n].activeSelf) return false;
        }

        return true;
    }
}

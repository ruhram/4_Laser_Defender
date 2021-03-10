﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWaves = 0;
    // Start is called before the first frame update
    void Start()
    {
        var currentWaves = waveConfigs[startingWaves];
        StartCoroutine(spawnAllWaves());
    }

    private IEnumerator spawnAllWaves()
    {
        for(int waveIndex = startingWaves; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWaves = waveConfigs[waveIndex];
            yield return StartCoroutine(spawnAllEnemies(currentWaves));
        }
    }

    private IEnumerator spawnAllEnemies(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.getNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(waveConfig.getEnemyPrefab(), waveConfig.getWaypoint()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.getTimeBetweenSpawn());
        }
    }
}

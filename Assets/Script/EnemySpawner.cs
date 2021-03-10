using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    int startingWaves = 0;
    // Start is called before the first frame update
    void Start()
    {
        var currentWaves = waveConfigs[startingWaves];
        StartCoroutine(spawnAllEnemies(currentWaves));
    }

    private IEnumerator spawnAllEnemies(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.getNumberOfEnemies(); enemyCount++)
        {
            Instantiate(waveConfig.getEnemyPrefab(), waveConfig.getWaypoint()[0].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(waveConfig.getTimeBetweenSpawn());
        }
    }
}

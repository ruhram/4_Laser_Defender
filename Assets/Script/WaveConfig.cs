using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject EnemyPrefabs;
    [SerializeField] GameObject pathPrefabs;
    [SerializeField] float timeBetweenSpawn = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;

    public GameObject getEnemyPrefab() { return EnemyPrefabs; }

    public List<Transform> getWaypoint()
    {
        var waveWaypoint = new List<Transform>();
        foreach(Transform child in pathPrefabs.transform)
        {
            waveWaypoint.Add(child);
        }
        return waveWaypoint;
    }

    public float getTimeBetweenSpawn() { return timeBetweenSpawn; }

    public float getSpawnRandomFactor() { return spawnRandomFactor; }

    public float getNumberOfEnemies() { return numberOfEnemies; }

    public float getMoveSpeed() { return moveSpeed; }

}

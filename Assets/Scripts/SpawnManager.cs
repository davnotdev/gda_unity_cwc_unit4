using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy_prefab;
    public GameObject powerup_prefab;

    private int enemy_count;
    private int wave_number = 1;
    private float spawn_range = 9;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemy_count = FindObjectsOfType<Enemy>().Length;
        if (enemy_count == 0)
        {
            SpawnEnemyWave(wave_number++);
            Instantiate(powerup_prefab, GetRandomSpawnPosition(), powerup_prefab.transform.rotation);
        }
    }

    void SpawnEnemyWave(int spawn_count)
    {
        for (int i = 0; i < spawn_count; i++)
        {
            Instantiate(enemy_prefab, GetRandomSpawnPosition(), enemy_prefab.transform.rotation);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(
            Random.Range(-spawn_range, spawn_range),
            0.0f,
            Random.Range(-spawn_range, spawn_range)
        );
    }
}

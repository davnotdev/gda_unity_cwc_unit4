using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy_prefab;

    private float spawn_range = 9;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemy_prefab, GetRandomSpawnPosition(), enemy_prefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }

    Vector3 GetRandomSpawnPosition() {
        return new Vector3(
            Random.Range(-spawn_range, spawn_range),
            0.0f,
            Random.Range(-spawn_range, spawn_range)
        );
    }
}

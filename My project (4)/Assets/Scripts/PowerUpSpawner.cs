using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab;

    public float minSpawnDelay = 5f;
    public float maxSpawnDelay = 12f;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    System.Collections.IEnumerator SpawnLoop()
    {
        while (true)
        {
            float delay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(delay);

            SpawnPowerUp();
        }
    }

    void SpawnPowerUp()
    {
        float x = Random.Range(-2.2f, 2.2f);
        float y = Random.Range(-4f, 4f);

        Vector3 spawnPos = new Vector3(x, y, 0);
        Instantiate(powerUpPrefab, spawnPos, Quaternion.identity);
    }
}

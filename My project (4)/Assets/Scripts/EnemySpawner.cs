using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject enemyPrefab;
    public float spawnInterval = 10f;
    public int spawnCount = 5;

    [Header("Spawn Area")]
    public float xSpacing = 1.5f;
    public float minX = -7f;
    public float maxX = 7f;
    public float spawnY = 5.5f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemies();
            timer = 0f;
        }
    }

    void SpawnEnemies()
    {
        // spawn 5 enemy berjejer
        float startX = Random.Range(minX, maxX - (spawnCount * xSpacing));

        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPos = new Vector3(startX + (i * xSpacing), spawnY, 0);
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}

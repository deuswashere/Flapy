using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnRate = 3f;
    public float minY = -2f, maxY = 4f;

    private float timer = 0f;

    void Update()
    {
        if (obstaclePrefab == null)
        {
            Debug.LogWarning("Obstacle Prefab is missing! Assign it in the inspector.");
            return;
        }

        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        float y = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(transform.position.x, y, 0f);

        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
    }
}
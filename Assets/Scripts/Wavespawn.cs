using UnityEngine;
using System.Collections;

public class Wavespawn : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnRate = 3f;

    void Start()
    {
        if (obstaclePrefab == null)
        {
            Debug.LogWarning("Obstacle Prefab is missing! Assign it in the inspector.");
            return;
        }

        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (!GameManager.Instance.isGameOver)
        {
            SpawnObstacle();
            yield return new WaitForSecondsRealtime(spawnRate); // oyun dursa bile çalýþýr
        }
    }

    void SpawnObstacle()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, 0f);
        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
    }
}

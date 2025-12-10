using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;       // Assign prefab in Inspector
    public float spawnIntervalMin = 2f;
    public float spawnIntervalMax = 5f;
    public float spawnX = 10f;
    public float minY = -3f, maxY = 3f;

    void Start()
    {
        StartCoroutine(SpawnClouds());
    }

    IEnumerator SpawnClouds()
    {
        while (true)
        {
            float waitTime = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(waitTime);

            Vector3 spawnPos = new Vector3(spawnX, Random.Range(minY, maxY), 0);
            Instantiate(cloudPrefab, spawnPos, Quaternion.identity);
        }
    }
}

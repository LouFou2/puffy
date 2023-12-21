
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBedSpawner : MonoBehaviour
{
    public GameObject nextBedPrefab; // The prefab of the next bed to spawn
    public float offsetDistance;
    public float destroyDelay;

    private bool hasSpawnedNextBed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasSpawnedNextBed && other.CompareTag("Player"))
        {
            SpawnNextBed();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Start a coroutine to destroy the old bed after a delay
            StartCoroutine(DestroyOldBedAfterDelay());
        }
    }

    private void SpawnNextBed()
    {
        Vector3 spawnPosition = transform.parent.position + (transform.parent.forward * offsetDistance);
        GameObject newBed = Instantiate(nextBedPrefab, spawnPosition, Quaternion.identity);
        hasSpawnedNextBed = true;
    }

    private IEnumerator DestroyOldBedAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);

        // Destroy the old bed
        Destroy(transform.parent.gameObject);
    }
}
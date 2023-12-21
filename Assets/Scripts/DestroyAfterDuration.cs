
using System.Collections;
using UnityEngine;

public class DestroyAfterDuration : MonoBehaviour
{
    public float duration = 2.0f; // Duration in seconds before destruction

    private void Start()
    {
        // Start the coroutine to destroy the object after the specified duration
        StartCoroutine(DestroyAfterDelay());
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}

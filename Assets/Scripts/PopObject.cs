using UnityEngine;

public class PopObject : MonoBehaviour
{
    public GameObject bubblePopPrefab; // Assign the "BubblePop" prefab in the Inspector
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Replace "Player" with the appropriate tag for the colliding object
        {
            // Instantiate the "BubblePop" prefab at the same position and rotation
            Instantiate(bubblePopPrefab, transform.position, transform.rotation);

            // Play the pop sound
            if (audioSource != null)
            {
                audioSource.Play();
            }

            // Destroy the main bubble prefab
            Destroy(gameObject);
        }
    }
}

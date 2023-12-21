using UnityEngine;

public class TriggerBounceSound : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component from the player GameObject
        //audioSource = GetComponent<AudioSource>();

        // Make sure the AudioSource is set to play through 3D spatial blending
        //audioSource.spatialBlend = 1.0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor")) // Replace "Floor" with the appropriate tag for the floor GameObject
        {
            // Play the bounce sound
            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
        }
    }
}

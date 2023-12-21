using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetOnOutBounds : MonoBehaviour
{
    public float outOfBoundsThreshold = -10f; // Adjust this threshold as needed

    private void Update()
    {
        // Check if the player's position falls below the outOfBoundsThreshold
        if (transform.position.y < outOfBoundsThreshold)
        {
            // Reset or restart the scene
            RestartScene();
        }
    }

    private void RestartScene()
    {
        // Get the current scene's index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Restart the current scene
        SceneManager.LoadScene(currentSceneIndex);
    }
}


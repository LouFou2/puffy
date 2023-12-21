using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroAudioPlayer : MonoBehaviour
{
    public string nextSceneName;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            LoadNextScene();
        }
    }
    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}










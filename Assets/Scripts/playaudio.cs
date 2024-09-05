using UnityEngine;

public class playaudio : MonoBehaviour
{
    public GameObject fileBrowserGameObject; // Reference to the GameObject that has the FileBrowserUpdate script

    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component from the fileBrowserGameObject
        if (fileBrowserGameObject != null)
        {
            audioSource = fileBrowserGameObject.GetComponent<FileBrowserAudio>().audioSource;
        }

        if (audioSource != null && audioSource.clip != null)
        {
            // Now you can use the audioSource and its clip
            Debug.Log("Audio clip length: " + audioSource.clip.length);
            PlayAudio();
        }
        else
        {
            Debug.LogError("AudioSource or AudioClip is missing.");
        }
    }

    public void PlayAudio()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }

    public void PauseAudio()
    {
        if (audioSource != null)
        {
            audioSource.Pause();
        }
    }
}

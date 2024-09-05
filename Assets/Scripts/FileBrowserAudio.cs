using AnotherFileBrowser.Windows;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FileBrowserAudio : MonoBehaviour
{
    //public RawImage rawImage;
    //public Material mat;
    public AudioSource audioSource;

    public void OpenFileBrowser()
    {
        var bp = new BrowserProperties();
        bp.filter = "Media files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.mp3, *.wav) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.mp3; *.wav";
        bp.filterIndex = 0;

        new FileBrowser().OpenFileBrowser(bp, path =>
        {
            // Determine the file type by the file extension
            string extension = System.IO.Path.GetExtension(path).ToLower();

            /*if (extension == ".jpg" || extension == ".jpeg" || extension == ".jpe" || extension == ".jfif" || extension == ".png")
            {
                // Load image from local path with UWR
                StartCoroutine(LoadImage(path));
            }*/
            if (extension == ".mp3" || extension == ".wav")
            {
                // Load audio from local path with UWR
                StartCoroutine(LoadAudio(path));
            }
            else
            {
                Debug.LogError("Unsupported file type");
            }
        });
    }

    /*IEnumerator LoadImage(string path)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(path))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result == UnityWebRequest.Result.ConnectionError || uwr.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(uwr.error);
            }
            else
            {
                var uwrTexture = DownloadHandlerTexture.GetContent(uwr);
                rawImage.texture = uwrTexture;
                mat.mainTexture = uwrTexture;
            }
        }
    }*/

    IEnumerator LoadAudio(string path)
    {
        using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(path, GetAudioType(path)))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result == UnityWebRequest.Result.ConnectionError || uwr.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(uwr.error);
            }
            else
            {
                AudioClip audioClip = DownloadHandlerAudioClip.GetContent(uwr);
                audioSource.clip = audioClip;
                //audioSource.Play();
            }
        }
    }

    AudioType GetAudioType(string path)
    {
        string extension = System.IO.Path.GetExtension(path).ToLower();

        switch (extension)
        {
            case ".mp3":
                return AudioType.MPEG;
            case ".wav":
                return AudioType.WAV;
            default:
                Debug.LogError("Unsupported audio type");
                return AudioType.UNKNOWN;
        }
    }
}

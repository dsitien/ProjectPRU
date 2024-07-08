using UnityEngine;

public class AudioManagerLoader : MonoBehaviour
{
    public GameObject audioManagerPrefab;

    void Awake()
    {
        AudioManager existingAudioManager = FindObjectOfType<AudioManager>();
        if (existingAudioManager == null)
        {
            Debug.Log("AudioManager not found, creating new one.");
            GameObject audioManagerObj = Instantiate(audioManagerPrefab);
            DontDestroyOnLoad(audioManagerObj);
        }
        else
        {
            Debug.Log("AudioManager found in scene.");
        }
    }
}

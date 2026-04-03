using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip bgMusic;
    public float volume = 0.3f;

    void Start()
    {
        if (bgMusic != null)
        {
            AudioSource.PlayClipAtPoint(bgMusic, Vector3.zero, volume);
        }
        else
        {
            Debug.LogWarning("BG music not assigned!");
        }
    }
}
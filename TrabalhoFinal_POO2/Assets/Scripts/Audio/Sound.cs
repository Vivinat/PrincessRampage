using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    [HideInInspector]
    public AudioSource audioSource;

    public string name;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 0.5f;

    [Range(.1f, 3f)]
    public float pitch = 1f;

    public bool loop;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PlaySoundOn : MonoBehaviour
{
    public string Playing;
    public string ActiveScene;
    public string Song;

    private void Start()
    {
        if (!(AudioManager.instance.IsPlaying(Playing)) && SceneManager.GetActiveScene().name == ActiveScene)
        {
            AudioManager.instance.PlaySound(Song);
        }
    }
}

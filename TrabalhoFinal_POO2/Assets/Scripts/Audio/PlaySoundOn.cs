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
    public string Stop;

    private void Start()
    {
        if (!(AudioManager.instance.IsPlaying(Playing)) && SceneManager.GetActiveScene().name == ActiveScene)
        {
            if (Stop == null)
            {
                AudioManager.instance.PlaySound(Song);    
            }
            else
            {
                AudioManager.instance.StopSound(Stop);
                AudioManager.instance.PlaySound(Song);
            }
        }
    }
}

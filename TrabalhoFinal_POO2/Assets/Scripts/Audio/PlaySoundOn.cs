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

    //Esse script vai tocar o som desejado e parar qualquer outro som que esteja sendo tocado

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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//AudioManager também é um singleton!
public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;        //lista de sons



    public static AudioManager instance;
    //Só precisamos inicializá-lo uma vez
    private void Awake()
    {
        if (instance == null)       //Existe alguma instancia ao iniciar?
        {
            instance = this;        //Senão, esta é a nova instancia
        }
        else
        {
            Destroy(gameObject, 2f);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in sounds)     //Propriedades do som
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.loop = sound.loop;
        }
    }

    public void PlaySound(string name)      //Precisamos passar o nome do som para que ele toque!
    {
        Debug.Log(name);
        Sound s = FindSound(name);          
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");     
            return;
        }
        s.audioSource.Play();
    }

    public void StopSound(string name)      //Pare de tocar
    {
        Sound s = FindSound(name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.audioSource.Stop();
    }

    public void PlaySoundAt(GameObject source, string name)     //Toque quando
    {
        Sound s = FindSound(name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        AudioSource soundSource = source.AddComponent<AudioSource>();
        soundSource.clip = s.clip;
        soundSource.volume = s.volume;
        soundSource.pitch = s.pitch;
        soundSource.spatialBlend = 0.5f;
        soundSource.Play();
        Destroy(soundSource, (soundSource.clip.length + 1f));
    }

    private Sound FindSound(string name)        //Encontre
    {
        return Array.Find(sounds, sound => sound.name == name);
    }

    public bool IsPlaying(string name)      //Está tocando?
    {
        Sound s = FindSound(name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
        }

        return s.audioSource.isPlaying;       
    }

    public void ChangeSoundVolume(string name, float volume)        //Mude o volume!
    {
        Sound s = FindSound(name);

        s.audioSource.volume = volume;

    }



}

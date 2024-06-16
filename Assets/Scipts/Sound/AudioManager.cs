using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public  Sound[] musicSounds, sfxSounds;
   public  AudioSource musicSource,sfxSource;


    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        PlayMusic("Menu");
       // PlaySFX("Dead");
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute= !musicSource.mute;

    } 
    public void ToggleSFX()
    {
        sfxSource.mute= !sfxSource.mute;

    }

    public void MusicVolumn(float vol)
    {
        musicSource.volume = vol;
    }
    public void SfxVolumn(float vol)
    {
        sfxSource.volume = vol;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource sfxSource;         // For sound effects
    public AudioSource musicSource;       // For background music

    [Header("Sound Clips")]
    public AudioClip clickingClip;
    public AudioClip errorClip;
    public AudioClip swishClip;
    public AudioClip backgroundMusicClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep the audio manager across scenes
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Start background music
        if (backgroundMusicClip != null)
        {
            musicSource.clip = backgroundMusicClip;
            
        }
    }

    private void Start()
    {
            musicSource.Play();
        musicSource.loop = true;

    }

    public void PlayClick()
    {
        sfxSource.PlayOneShot(clickingClip);
    }

    public void PlayError()
    {
        sfxSource.PlayOneShot(errorClip);
    }

    public void PlaySwish()
    {
        sfxSource.PlayOneShot(swishClip);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void StartMusic()
    {
        if (!musicSource.isPlaying)
        {
            musicSource.clip = backgroundMusicClip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }
}
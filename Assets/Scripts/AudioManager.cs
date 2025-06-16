using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*public class AudioManager : MonoBehaviour
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

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}*/




public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource sfxSource;
    public AudioSource musicSource;

    [Header("Sound Clips")]
    public AudioClip clickingClip;
    public AudioClip errorClip;
    public AudioClip swishClip;

    [Header("Background Music Clips Per Scene")]
    public AudioClip mainMenuMusic;
    public AudioClip level1Music;
    public AudioClip level2Music;
    public AudioClip level3Music;

    private Dictionary<string, AudioClip> sceneMusicMap;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            sceneMusicMap = new Dictionary<string, AudioClip>
            {
                { "MainMenu", mainMenuMusic },
                { "Level_1", level1Music },
                { "Level_2", level2Music },
                { "Level_3", level3Music }
            };

            SceneManager.sceneLoaded += OnSceneLoaded;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (sceneMusicMap.ContainsKey(scene.name))
        {
            PlayBackgroundMusic(sceneMusicMap[scene.name]);
        }
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
    {musicSource.Stop();}

    public void PlayBackgroundMusic(AudioClip newClip)
    {
        if (musicSource.clip != newClip)
        {
            musicSource.clip = newClip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource _musicSource, _effectsSource;

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

    public void PlaySound(AudioClip clip, bool loop = false)
    {
        _musicSource.clip = clip;
        _musicSource.loop = loop;
        _musicSource.Play();
    }

    public void ChangeMasterVolume(float value)
    {
        AudioListener.volume = value;
    }

    public void StopMusic()
    {
        _musicSource.Stop();
    }
}

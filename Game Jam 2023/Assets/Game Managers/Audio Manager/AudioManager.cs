using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySFX(AudioSource source, AudioClip clip, float volume)
    {
        source.PlayOneShot(clip, volume);
    }

    public void PlayBGM(AudioSource source, AudioClip clip, float volume)
    {
        source.clip = clip;
        source.volume = volume;

        source.Play();
    }
}

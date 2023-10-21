using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBank : MonoBehaviour
{
    [System.Serializable]
    private class AudioInstance
    {
        public string name;
        public AudioClip clip;
    }

    public static AudioBank Instance;

    [SerializeField] private AudioInstance[] audioClips;
    //public AudioClip clip;

    private void Awake()
    {
        Instance = this;
    }

    public AudioClip GetAudioClip(string name)
    {
        foreach(AudioInstance audioInstance in audioClips)
        {
            if (audioInstance.name == name) return audioInstance.clip;
        }

        return audioClips[0].clip;
    }
}

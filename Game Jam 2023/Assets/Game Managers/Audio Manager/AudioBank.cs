using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBank : MonoBehaviour
{
    public static AudioBank Instance;

    //public AudioClip clip;

    private void Awake()
    {
        Instance = this;
    }
}

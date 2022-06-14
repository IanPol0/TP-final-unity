using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource sounds;

    void Start()
    {
        sounds = gameObject.GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        sounds.clip = clip;
        sounds.Play();
    }
}

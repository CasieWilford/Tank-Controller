using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioHelper
{
    public static AudioSource PlayClip2D(AudioClip clip, float volume)
    {
        // Create
        GameObject audioObject = new GameObject("Audio2D");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();

        // Configure
        audioSource.clip = clip;
        audioSource.volume = volume;

        // Active
        audioSource.Play();
        Object.Destroy(audioObject, clip.length);

        // Return in case other things need it.
        return audioSource;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryAudio : MonoBehaviour
{
    public AudioClip achievement;
    AudioSource bossDefeated;

    public float volume;
    public bool alreadyPlayed = false;

    void Start()
    {
        bossDefeated = GetComponent<AudioSource>();
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (!alreadyPlayed && other.transform.tag == "Player")
        {
            bossDefeated.PlayOneShot(achievement, volume);
            alreadyPlayed = true;
        }
    }
}

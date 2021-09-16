using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionAudio : MonoBehaviour
{
    AudioSource bulletCollide;

    void Start()
    {
        bulletCollide = GetComponent<AudioSource>();
    }

    void Update()
    {
        bulletCollide.Play();
        Destroy(gameObject, .1f);
    }
}

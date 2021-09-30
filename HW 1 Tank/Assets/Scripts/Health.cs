using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IKillable, IDamageable<int>
{
    public int currentHealth;
    public int enemyMaxHealth = 3;

    public ParticleSystem deathParticle;

    AudioSource deathAudio;

    void Start()
    {
        currentHealth = enemyMaxHealth;
        deathAudio = gameObject.GetComponent<AudioSource>();
    }

    public void Update()
    {

    }

    public void TakeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;

        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        deathAudio.Play();
        Instantiate(deathParticle, transform.position, transform.rotation);
        Destroy(gameObject, .1f);
    } 
}



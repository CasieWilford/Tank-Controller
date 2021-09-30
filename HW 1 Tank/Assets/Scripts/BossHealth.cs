using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int currentHealth;
    int bossMaxHealth = 14;

    public GameObject victoryAudio;

    public ParticleSystem deathParticle;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = bossMaxHealth;
        healthBar.SetMaxHealth(bossMaxHealth);

        victoryAudio.SetActive(false);
    }

    public void Update()
    {

    }

    public void TakeDamage(int damageTaken)
    {
        currentHealth -= damageTaken;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        victoryAudio.SetActive(true);

        Instantiate(deathParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

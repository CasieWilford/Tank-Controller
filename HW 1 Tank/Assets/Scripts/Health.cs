using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IKillable, IDamageable<int>
{
    public int currentHealth;
    public int enemyMaxHealth = 3;
    public int bossMaxHealth = 10;

    public ParticleSystem deathParticle;
    
    void Start()
    {
        if (gameObject.tag == "Enemy")
        {
            currentHealth = enemyMaxHealth;
        }
        else if (gameObject.tag == "Boss")
        {
            currentHealth = bossMaxHealth;
        }
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
        // death particle and sound
        Instantiate(deathParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}



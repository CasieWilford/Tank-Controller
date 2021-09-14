using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IKillable, IDamageable<int>
{
    public int currentHealth;
    public int maxHealth = 3;

    void Start()
    {
        currentHealth = maxHealth;
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
        Destroy(gameObject);
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IKillable, IDamageable<int>
{
    public int currentHealth;
    public int enemyMaxHealth = 3;
    public int bossMaxHealth = 7;



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



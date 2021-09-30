using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ParticleSystem bulletParticles;
    public GameObject bulletCollisionAudio;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(bulletCollisionAudio, transform.position, transform.rotation);
        Instantiate(bulletParticles, transform.position, transform.rotation);
       
        // Player shoots an enemy
        if (collision.transform.tag == "Enemy" || collision.transform.tag == "Boss")
        {
            // Get Health
            var enemyHealthComponent = collision.collider.GetComponent<Health>();
            var bossHealthComponent = collision.collider.GetComponent<BossHealth>();

            if (enemyHealthComponent != null)
            {
                enemyHealthComponent.TakeDamage(1);
                Debug.Log("this current health: " + enemyHealthComponent.currentHealth);
            }

            if (bossHealthComponent != null)
            {
                bossHealthComponent.TakeDamage(1);
                Debug.Log("this current health: " + bossHealthComponent.currentHealth);
            }
        }
        gameObject.SetActive(false);
    }
}

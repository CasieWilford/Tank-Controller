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
            var healthComponent = collision.collider.GetComponent<Health>();

            if (healthComponent != null)
            {
                healthComponent.TakeDamage(1);
                Debug.Log("this current health: " + healthComponent.currentHealth);
            }
        }
        gameObject.SetActive(false);
    }
}

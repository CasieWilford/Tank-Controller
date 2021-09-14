using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.name);

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
            // Hide bullet after collission.
            gameObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.name);

        // Player shoots an enemy
        if (collision.transform.tag == "Enemy") // && gameObject.tag == "Player")
        {
            // Destroy enemy.
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

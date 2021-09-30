using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionEffect;
    float radius = 3f;

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        // Get nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        
        foreach (Collider nearbyObject in colliders)
        {
            var characterHealth = nearbyObject.GetComponent<Player>();
            if (characterHealth != null)
            {
                Debug.Log(nearbyObject.name + " has been bombed!");
                characterHealth.DecreaseHealth(1);
            }
        }
        Destroy(gameObject);
    }
}

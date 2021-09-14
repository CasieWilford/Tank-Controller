using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionEffect;
    public float radius = 5f;
    

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
            // damage player.
        }
        Destroy(gameObject);
    }
}

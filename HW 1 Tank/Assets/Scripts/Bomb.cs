using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionEffect;
    public float radius = 5f;

    public GameObject bomb;
    //public GameObject bombSpawningParticle;
 

    int randomX;
    int randomZ;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            randomX = Random.Range(-7, 7);
            randomZ = Random.Range(-7, 7);

            GameObject tempBomb = Instantiate(bomb, new Vector3(randomX, 20f, randomZ), transform.rotation) as GameObject;
            //GameObject tempBombParticle = Instantiate(bombSpawningParticle, new Vector3(randomX, 5f, randomZ), transform.rotation) as GameObject;
            Rigidbody tempRigidBodyBomb = tempBomb.GetComponent<Rigidbody>();

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    void Explode()
    {
        //Instantiate(explosionEffect, transform.position, transform.rotation);
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

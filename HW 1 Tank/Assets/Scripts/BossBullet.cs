using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
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


        var playerHealthComponent = collision.collider.GetComponent<Player>();

        if(playerHealthComponent != null)
        {
            Debug.Log("Player hit by boss!");
            playerHealthComponent.DecreaseHealth(1);
        }

        Instantiate(bulletParticles, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

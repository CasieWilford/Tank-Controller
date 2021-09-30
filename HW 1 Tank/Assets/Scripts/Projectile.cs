using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float bulletspeed = 1100;
    public GameObject bullet;
    public ParticleSystem muzzleFlash;

    public float fireRate = 1f;
    private float fireCountdown = 2f;
    
    AudioSource bulletAudio;

    private void Start()
    {
        bulletAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Player Shooting
        if (Input.GetKeyDown(KeyCode.Space) && gameObject.tag == "Player")
        {
            Fire();
        }

        // Boss Shooting
        if ((fireCountdown <= 0f) && (gameObject.tag == "Enemy"))
        {
            Fire();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void Fire()
    {
        // Shoot
        GameObject tempBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
        tempRigidBodyBullet.AddForce(tempRigidBodyBullet.transform.forward * bulletspeed);
        Destroy(tempBullet, 1f);

        // Play Firing Audio.
        bulletAudio.Play();
        // Firing Particle.
        Instantiate(muzzleFlash, transform.position, transform.rotation);
    }
}

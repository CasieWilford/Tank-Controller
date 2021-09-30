using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    float fireRate = .45f;
    private float fireCountdown = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fireCountdown <= 0f)
        {
            SpawnEnemy();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;

    }

    void SpawnEnemy()
    {
        GameObject tempEnemy = Instantiate(enemy, transform.position, transform.rotation) as GameObject;
        Destroy(tempEnemy, 5.7f);
        
    }
}

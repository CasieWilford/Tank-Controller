using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBomb : MonoBehaviour
{
    public GameObject bombPrefab;

    int randomX;
    int randomZ;

    public float maxTimer = 1f;
    public float timeRemaining;
    bool startDroppingBombs = false;

    void Start()
    {
        timeRemaining = maxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();

        if (GameObject.Find("Boss") != null)
        {
            var bossCurrentHealth = GameObject.Find("Boss").GetComponent<BossHealth>();
            // Once boss reaches a certain health, bombs begin dropping!
            if (bossCurrentHealth != null)
            {
                if (startDroppingBombs && bossCurrentHealth.currentHealth <= 10)
                {
                    DropBombs();
                }
            }
        }
    }

    void DropBombs()
    {
        randomX = Random.Range(-18, 20);
        randomZ = Random.Range(17, 46);

        GameObject tempBomb = Instantiate(bombPrefab, new Vector3(randomX, 20f, randomZ),
            transform.rotation) as GameObject;
        //GameObject tempBombParticle = Instantiate(bombSpawningParticle, new Vector3(randomX, 5f, randomZ), transform.rotation) as GameObject;
        Rigidbody tempRigidBodyBomb = tempBomb.GetComponent<Rigidbody>();
    }

    void Timer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            startDroppingBombs = false;
            //Debug.Log(timeRemaining);
        }
        else
        {
            startDroppingBombs = true;
            timeRemaining = 1f;
            //Debug.Log("Bomb time reset!");
        }
    }
}

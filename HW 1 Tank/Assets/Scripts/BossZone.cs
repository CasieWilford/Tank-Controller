using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossZone : MonoBehaviour
{
    public GameObject boss;
    public GameObject bossHealthBar;
    public GameObject player;
    public GameObject wall;

    private MoveCamera moveCamera;
    private Health checkBossHP;

    public AudioSource bossZoneAudio;

    int active = 0;

    private void Awake()
    {
        moveCamera = GameObject.FindObjectOfType<MoveCamera>();
    }

    private void Start()
    {
        wall.SetActive(false);
    }

    private void Update()
    {
        if (boss == null)
        {
            bossZoneAudio.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && active == 0)
        {
            moveCamera.BossActivated();

            MovePlayer();
            MoveWall();
            
            bossZoneAudio.Play();

            boss.SetActive(true);
            bossHealthBar.SetActive(true);
            Debug.Log("Boss Activated!!");
            active = 1;
        }
    }

    void MovePlayer()
    {
        player.transform.position = new Vector3(0f, .5f, 17f);
    }

    void MoveWall()
    {
        wall.SetActive(true);
    }
}

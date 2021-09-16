using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform[] waypoint;
    public float bossSpeed;
    private int movementNum = 1;
    public int spinSpeed = 100;



    private int current;

    private void Start()
    {

    }

    void Update()
    {
        // Moving boss between waypoints.
        if (transform.position != waypoint[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, waypoint[current].position, bossSpeed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);

            // Every 4 movements, make boss spin.
            if (movementNum % 4 == 0f)
            {
                transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f, Space.Self);
            }
        }
        else
        {
            current = (current + 1) % waypoint.Length;
            movementNum += 1;
           
            //Debug.Log(movementNum);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform target;
    public float speed = .1f;
    public bool bossActive;

    // Start is called before the first frame update
    void Start()
    {
        bossActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bossActive)
        {
            StartCoroutine(Move());
        }
    }

    private IEnumerator Move()
    {
        Vector3 a = transform.position;
        Vector3 b = target.position;
        transform.position = Vector3.Lerp(a, b, speed);

        yield return new WaitForSeconds(4);
    }

    public void BossActivated()
    {
        bossActive = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    protected abstract void PowerUp(Player player);

    [SerializeField] float _powerupDuration = 1f;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            PowerUp(player);
        }
    }

    private void PowerDown()
    {
        gameObject.SetActive(false);
    }
}

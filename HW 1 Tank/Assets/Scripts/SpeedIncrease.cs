using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncrease : CollectibleBase
{
    [SerializeField] readonly float _speedAmount = .25f;

    protected override void Collect(Player player)
    {
        // Pull motor controller from the player.
        TankController controller = player.GetComponent<TankController>();

        if (controller != null)
        {
            controller.MaxSpeed += _speedAmount;
            controller.MoveSpeed += _speedAmount;
        }

        player.IncreaseTreasure();
        Debug.Log("Speed Boost!");
    }

    protected override void Movement(Rigidbody rb)
    {
        // Calculate rotation.
        Quaternion turnOffset = Quaternion.Euler
            (MovementSpeed, MovementSpeed, MovementSpeed);

    }

}

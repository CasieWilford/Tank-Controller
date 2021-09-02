using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slower : Enemy
{
    [SerializeField] readonly float _slowAmount = .15f;

    public override void PlayerImpact(Player player)
    {
        TankController controller = player.GetComponent<TankController>();

        if (controller != null)
        {
            controller.MaxSpeed -= _slowAmount;
            controller.MoveSpeed -= _slowAmount;
            Debug.Log("Get SLOWEDDD");
        }
    }
}

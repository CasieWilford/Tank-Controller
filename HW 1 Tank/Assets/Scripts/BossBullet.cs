using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : Enemy
{
    public override void PlayerImpact(Player player)
    {
        base.PlayerImpact(player);
        gameObject.SetActive(false);
    }
}

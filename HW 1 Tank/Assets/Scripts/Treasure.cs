using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Treasure : CollectibleBase
{
    //[SerializeField] int _treasureAdded = 1;
    public static int currentTreasure;

    public Text treasureText;

    void Update()
    {
        treasureText.text = "Treasure: " + currentTreasure.ToString();
    }

    protected override void Collect(Player player)
    {
        Debug.Log("Score Increase! " + currentTreasure);
    }
}

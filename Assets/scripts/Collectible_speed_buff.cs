using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_speed_buff : Collectible_buff
{
    public float speedIncrease = 10f;
    public override void Collected(Player player)
    {
        StarterAssets.FirstPersonController controller = player.GetComponent<StarterAssets.FirstPersonController>();
        if (controller != null)
        {
            controller.MoveSpeed += speedIncrease;
            Debug.Log("Player speed increased by " + speedIncrease);
        }
        base.Collected(player);
    }
 
}

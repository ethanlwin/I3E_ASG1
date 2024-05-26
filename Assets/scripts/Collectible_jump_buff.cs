using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_jump_buff : Collectible_buff
{
    public float jumpIncrease = 1f;
    public override void Collected(Player player)
    {
        StarterAssets.FirstPersonController controller = player.GetComponent<StarterAssets.FirstPersonController>();
        if (controller != null)
        {
            controller.JumpHeight += jumpIncrease;
            Debug.Log("Player speed increased by " + jumpIncrease);
        }
        base.Collected(player);
    }
}

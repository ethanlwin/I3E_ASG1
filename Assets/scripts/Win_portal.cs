/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: 17th May 2024
 * Description: The code for the interactable portal which allows the player to win the game
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_portal : MonoBehaviour
{
    /// <summary>
    /// this connects the player script to this script
    /// </summary>
    public Player script;
    // Start is called before the first frame update
    /// <summary>
    /// //detect if the player has entered the win portal zone.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //check if the player has collected all the win conditions and will update the player that it is in front of the "portal"
        if(other.gameObject.tag == "Player" && script.allWinConCollected)
        {
            other.gameObject.GetComponent<Player>().UpdateWinPortal(this);
        }
    }

    /// <summary>
    /// //detect if the player has exited the win portal zone.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        //check if the player has collected all the win conditions and will update the player that it is has left the zone of the "portal"
        if (other.gameObject.tag == "Player" && script.allWinConCollected)
        {
            other.gameObject.GetComponent<Player>().UpdateWinPortal(null);
        }
    }
}

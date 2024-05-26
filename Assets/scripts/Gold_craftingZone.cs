/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: 17th May 2024
 * Description: the script for the gold crafting zone where the player can interact for the gold key to be crafted
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold_craftingZone : MonoBehaviour
{
    /// <summary>
    /// this bool shows if the gold key has been crafted or not
    /// </summary>
    public bool goldKeyCrafted = false;
    /// <summary>
    /// this is the player script that is connected to this script
    /// </summary>
    public Player script;

    /// <summary>
    /// this is the function that will craft the gold key if all 4 gold key fragments are collected
    /// </summary>
    public void CraftGoldKey()
    {
        //once crafted the bool will be updated accordingly
        if (script.keyfrag_02 == 4)
        {
            goldKeyCrafted = true;
        }
    }
    /// <summary>
    /// checks if the player has enterd the triggerzone of the game object
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //checks if its the player in the triggerzone
        if (other.gameObject.tag == "Player")
        {

            // upodate the player on which zone it is infront of
            Debug.Log("Entered");
            other.gameObject.GetComponent<Player>().UpdateZoneGold(this);
        }
    }

    /// <summary>
    /// checks if the player has exited the triggerzone of the game object
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        //checks if its the player who exited the triggerzone
        if (other.gameObject.tag == "Player")
        {
            //update the player that it has left the zone 
            other.gameObject.GetComponent<Player>().UpdateZoneGold(null);
        }
    }
}

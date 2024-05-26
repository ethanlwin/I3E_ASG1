/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: 17th May 2024
 * Description: the script for the silver crafting zone where the player can interact for the silver key to be crafted
 */
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Silv_craftingZone : MonoBehaviour
{
    /// <summary>
    /// this bool shows if the silver key has been crafted or not
    /// </summary>
    public bool silvKeyCrafted = false;
    /// <summary>
    /// this is the player script that is connected to this script
    /// </summary>
    public Player script;

    /// <summary>
    /// this is the function that will craft the silver key if all 4 silver key fragments are collected
    /// </summary>
    public void CraftSilvKey()
    {
        //once crafted the bool will be updated accordingly
        if (script.keyfrag_01 == 4)
        {
            silvKeyCrafted = true;
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
            other.gameObject.GetComponent<Player>().UpdateZone(this);
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
            other.gameObject.GetComponent<Player>().UpdateZone(null);
        }
    }
}

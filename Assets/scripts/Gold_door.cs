/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: 17th May 2024
 * Description: a code that manages the interactions between the gold doors and the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold_door : MonoBehaviour
{
    /// <summary>
    /// connects the gold crafting zone script to this script
    /// </summary>
    public Gold_craftingZone script;
    /// <summary>
    /// this bool shows if the doors is opened or not
    /// </summary>
    public bool opened = false;
    /// <summary>
    /// this variable can be assgined to a game object in the inpsector menu
    /// </summary>
    [SerializeField] GameObject doorR;
    /// <summary>
    /// detect if the player has entered the triggerzone of the gold door
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //chceks if the player has the gold key crafted from the gold crafting zone
        if (other.gameObject.tag == "Player" && script.goldKeyCrafted)
        {
            // OpenDoor();

            // upodate the player on which gold door it is infront of
            other.gameObject.GetComponent<Player>().UpdateGoldDoor(this);
            opened = true;
        }
    }
    /// <summary>
    /// detect if the player has exited the triggerzone of the gold door
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        //chceks if the player has the silver key crafted from the silver crafting zone and that the door is opened
        if (other.gameObject.tag == "Player" && script.goldKeyCrafted && opened)
        {
            CloseDoor();
            // update the player on which door it has left
            other.gameObject.GetComponent<Player>().UpdateGoldDoor(null);
            opened = false;
        }
    }

    /// <summary>
    /// this function opens the door
    /// </summary>
    public void OpenDoor()
    {
        //this checks if the gold key is crafted
        if (script.goldKeyCrafted)
        {
            Vector3 newRotation = doorR.transform.eulerAngles;
            newRotation.x += 90f;
            doorR.transform.eulerAngles = newRotation;
            Debug.Log("Open");
        }
    }
    /// <summary>
    /// this function closes the door
    /// </summary>
    public void CloseDoor()
    {
        Vector3 newRotation = doorR.transform.eulerAngles;
        newRotation.x -= 90f;
        doorR.transform.eulerAngles = newRotation;
        Debug.Log("Close");

    }
}

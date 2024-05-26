/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: 17th May 2024
 * Description: the script for the bronze door and the interactions between the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    /// <summary>
    /// this bool shows if the doors is opened or not
    /// </summary>
    public bool opened = false;
    /// <summary>
    /// this bool manages if this door is locked or not
    /// </summary>
    bool locked = false;
    /// <summary>
    /// this variable can be assgined to a game object in the inpsector menu
    /// </summary>
    [SerializeField] GameObject doorR;
    /// <summary>
    /// detect if the player has exited the triggerzone of the bronze door
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //checks if the player has entered the triggerzone of the bronze door and that its not locked
        if(other.gameObject.tag == "Player" && !locked)
        {
            // OpenDoor();

            // upodate the player on which bronze door it is infront of
            other.gameObject.GetComponent <Player>().UpdateDoor(this);
        }
    }

    /// <summary>
    /// detect if the player has exited the triggerzone of the bronze door
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        //checks if the door is locked and that it is opened
        if (other.gameObject.tag == "Player" && !locked && opened)
        {
            CloseDoor();
            other.gameObject.GetComponent<Player>().UpdateDoor(null);
            opened = false;
        }
    }

    /// <summary>
    /// this function opens the door
    /// </summary>
    public void OpenDoor()
    {
        //this checks again if the door is locked
        if (!locked)
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
    /// <summary>
    /// this function locks the door
    /// </summary>
    /// <param name="lockStatus"></param>
    public void SetLock(bool lockStatus)
    {
        locked = lockStatus;

    }
}

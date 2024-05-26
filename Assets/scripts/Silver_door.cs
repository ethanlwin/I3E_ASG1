/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: 17th May 2024
 * Description: a code that manages the interactions between the silver doors and the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silver_door : MonoBehaviour
{
    //connects the silver crafting zone script to this script
    public Silv_craftingZone script;
    //this bool shows if the doors is opened or not
    public bool opened = false;
    //this variable can be assgined to a game object in the inpsector menu
    [SerializeField] GameObject doorR;

    //detect if the player has entered the triggerzone of the silver door
    private void OnTriggerEnter(Collider other)
    {
        //chceks if the player has the silver key crafted from the silver crafting zone
        if (other.gameObject.tag == "Player" && script.silvKeyCrafted)
        {
            // OpenDoor();

            // update the player on which door it is infront of
            other.gameObject.GetComponent<Player>().UpdateSilverDoor(this);
            opened = true;
        }
    }

    //detect if the player has exited the triggerzone of the silver door
    private void OnTriggerExit(Collider other)
    {
        //chceks if the player has the silver key crafted from the silver crafting zone and that the door is opened
        if (other.gameObject.tag == "Player" && script.silvKeyCrafted && opened)
        {
            //closes the door
            CloseDoor();
            // update the player on which door it has left
            other.gameObject.GetComponent<Player>().UpdateSilverDoor(null);
            opened = false;
        }
    }

    //this function opens the door
    public void OpenDoor()
    {
        //this checks if the silver key is crafted
        if (script.silvKeyCrafted)
        {
            Vector3 newRotation = doorR.transform.eulerAngles;
            newRotation.x += 90f;
            doorR.transform.eulerAngles = newRotation;
            Debug.Log("Open");
        }
    }
    //this function closes the door
    public void CloseDoor()
    {
        Vector3 newRotation = doorR.transform.eulerAngles;
        newRotation.x -= 90f;
        doorR.transform.eulerAngles = newRotation;
        Debug.Log("Close");

    }
}

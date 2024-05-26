/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: 17th May 2024
 * Description: this script manages the interactions between the bronze key and the player/bronze door
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side_key : MonoBehaviour
{
    //the bronze door script that is linked to this script
    /// <summary>
    /// this is referencing the door script and is linking the key to the door
    /// </summary>
    public Door linkedDoor;

    //the UI variables
    /// <summary>
    /// the bronze key inv bg
    /// </summary>
    public GameObject inv_bg3;
    /// <summary>
    /// the bronze key inv text
    /// </summary>
    public GameObject inv_text3;

    /// <summary>
    /// detects when the player collides with this game object
    /// </summary>
    /// <param name="collision"></param>

    private void OnCollisionEnter(Collision collision)
    {
        //checks if the player has collided with this game object
        if (collision.gameObject.tag == "Player")
        {
            //unlocks the linked door, which is the bronze door and destroys the object. This also updates the UI and says that the player has obtained the bronze key
            linkedDoor.SetLock(false);
            Destroy(gameObject);
            Debug.Log(collision.gameObject.name);
            inv_bg3.SetActive(true);
            inv_text3.SetActive(true);
        }
        
    }
    // Start is called before the first frame update
    /// <summary>
    /// check if there is a linked door
    /// </summary>
    void Start()
    {

        //check if there is a linked door
        if(linkedDoor != null)
        {
            linkedDoor.SetLock(true);
        }
        inv_bg3.SetActive(false);
        inv_text3.SetActive(false);
    }
}

/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: 17th May 2024
 * Description: this script will be managing the interactions between the silver key fragments and the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_fragment : MonoBehaviour
{
    /// <summary>
    /// the value of the silver key fragment
    /// </summary>
    public int key_frag = 1;
    /// <summary>
    /// the function that will destroy the game object or collect it
    /// </summary>
    public void Collected()
    {
        Destroy(gameObject);
    }
    /// <summary>
    /// checks if the player has collided with the game object
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        //will check if the game object has collided with the player and will update the player on which silver key fragment it has collided with
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().UpdateKeyFrag1(this);
            //Collected();
        }
    }
    /// <summary>
    /// checks if the player has stopped colliding with the game object
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision)
    {
        //will update the player that it has stop colliding with the game object
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().UpdateKeyFrag1(null);
        }
    }
}

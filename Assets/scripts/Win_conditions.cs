/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: 17th May 2024
 * Description: the script that will be placed on the win conditions and check the interactions between the win condition and the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_conditions : MonoBehaviour
{
    /// <summary>
    /// the value of each win condition collectible
    /// </summary>
    public int win_condition = 1;
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
        //will check if the game object has collided with the player and will update the player on which win condition it has collided with
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().UpdateWinCon(this);
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
            collision.gameObject.GetComponent<Player>().UpdateWinCon(null);
        }
    }
}

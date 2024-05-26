/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: 17th May 2024
 * Description: this script will manage the interactions between the plat collectible and the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_plat: MonoBehaviour    
{
    /// <summary>
    /// the value of the plat coin that will update the score of the player
    /// </summary>
    public int Plat_Coin = 10;

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
        if (collision.gameObject.tag == "Player")
        {
            //will check if the game object has collided with the player and will update the player on which plat coin it has collided with
            collision.gameObject.GetComponent<Player>().UpdateCollectible1(this);
            //collision.gameObject.GetComponent<player>().scoreadder(Plat_Coin);
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
            collision.gameObject.GetComponent<Player>().UpdateCollectible1(null);
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        //Make coin spin
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }
}

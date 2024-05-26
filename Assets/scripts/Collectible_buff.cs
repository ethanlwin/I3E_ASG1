using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_buff : MonoBehaviour
{
    
    public virtual void Collected(Player player)
    {
        Destroy(gameObject);
    }

    public void UpdatePlayerInteractable(Player player)
    {
        player.UpdateBuff(this);
    }
    public void RemovePlayerInteractable( Player player )
    {
        player.UpdateBuff(null);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        //will check if the game object has collided with the player and will update the player on which win condition it has collided with
        if (other.gameObject.tag == "Player")
        {
            UpdatePlayerInteractable(other.gameObject.GetComponent<Player>());
        }
    }
    /// <summary>
    /// checks if the player has stopped colliding with the game object
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit(Collider other)
    {
        //will update the player that it has stop colliding with the game object
        if (other.gameObject.tag == "Player")
        {
            RemovePlayerInteractable (other.gameObject.GetComponent<Player>());
        }
    }


}

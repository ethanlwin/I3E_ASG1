/*
 * Author: Ethan Thuta Lwin
 * Date of Creation: 17th May 2024
 * Description: this is the script for my player capsule that manages the UI and all the player interactions
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity;

public class Player: MonoBehaviour
{
    //the integers and the booleans
    /// <summary>
    /// stores the current score of the player
    /// </summary>
    public int currentScore = 0;
    /// <summary>
    /// stores the amount of silver key fragments the player has
    /// </summary>
    public int keyfrag_01 = 0;
    /// <summary>
    /// stores the amount of gold key fragments the player has
    /// </summary>
    public int keyfrag_02 = 0;
    /// <summary>
    /// stores the amount of win conditions the player has
    /// </summary>
    public int win_con = 0;
    /// <summary>
    /// checks if all silver key fragments are collected
    /// </summary>
    public bool allsilvKeyFragCollected = false;
    /// <summary>
    /// checks if all gold key fragments are collected
    /// </summary>
    public bool allgoldKeyFragCollected = false;
    /// <summary>
    /// checks if all win conditions are collected
    /// </summary>
    public bool allWinConCollected = false;
    
    //all the scripts connected to the player script
    /// <summary>
    /// This line references the Door script in the Player script
    /// </summary>
    public Door script;
    /// <summary>
    /// This line references the silver crafting zone script in the Player script
    /// </summary>
    public Silv_craftingZone script1;
    /// <summary>
    /// This line references the gold crafting zone script in the Player script
    /// </summary>
    public Gold_craftingZone script2;
    /// <summary>
    /// This line references the door script in order to inform the player which bronze door its infront of
    /// </summary>
    Door currentDoor;
    /// <summary>
    /// This line references the silver door script in order to inform the player which silver door its infront of
    /// </summary>
    Silver_door currentSilverDoor;
    /// <summary>
    /// This line references the gold door script in order to inform the player which gold door its infront of
    /// </summary>
    Gold_door currentGoldDoor;
    /// <summary>
    /// This line references the silver crafting zone script in order to inform the player which zone its inside of
    /// </summary>
    Silv_craftingZone currentZone;
    /// <summary>
    /// This line references the gold crafting zone script in order to inform the player which zone its inside of
    /// </summary>
    Gold_craftingZone goldcurrentZone;
    /// <summary>
    /// This line references the gold coin script in order to inform the player which gold coin its infront of
    /// </summary>
    Collectible_gold currentCollectible;
    /// <summary>
    /// This line references the plat coin script in order to inform the player which plat coin its infront of
    /// </summary>
    Collectible_plat currentCollectible1;
    /// <summary>
    /// This line references the silver coin script in order to inform the player which silver coin its infront of
    /// </summary>
    Collectible_silv currentCollectible2;
    /// <summary>
    /// This line references the silver key fragment script in order to inform the player which silver key fragment its infront of
    /// </summary>
    Key_fragment keyfraglvl1;
    /// <summary>
    /// This line references the gold key fragment script in order to inform the player which gold key fragment its infront of
    /// </summary>
    Key_fragments_gold keyfraglvl2;
    /// <summary>
    /// This line references the win condition script in order to inform the player which win condition its infront of
    /// </summary>
    Win_conditions wincon;
    /// <summary>
    /// This line references the win portal script in order to inform the player which win portal its infront of
    /// </summary>
    Win_portal win;
    /// <summary>
    /// This line references the buff script in order to inform the player which buff its infront of
    /// </summary>
    Collectible_buff buff;

    //the text and image variables for the UI
    /// <summary>
    /// current score text 
    /// </summary>
    public TextMeshProUGUI scoreText;
    /// <summary>
    /// current amount of win con
    /// </summary>
    public TextMeshProUGUI winconText;
    /// <summary>
    /// silver key fragment text
    /// </summary>
    public TextMeshProUGUI keyfragText;
    /// <summary>
    /// amount of silver key fragments
    /// </summary>
    public TextMeshProUGUI keyfraglvl1state;
    /// <summary>
    /// silver key inv bg
    /// </summary>
    public GameObject inv_bg1;
    /// <summary>
    /// silver key inv text
    /// </summary>
    public GameObject inv_text1;
    /// <summary>
    /// gold key fragment text
    /// </summary>
    public TextMeshProUGUI keyfragGoldText;
    /// <summary>
    /// amount of gold key fragments
    /// </summary>
    public TextMeshProUGUI keyfragGoldlvl1state;
    /// <summary>
    /// gold key inv bg
    /// </summary>
    public GameObject inv_bg2;
    /// <summary>
    /// gold key inv text
    /// </summary>
    public GameObject inv_text2;
    /// <summary>
    /// YOU WIN screen
    /// </summary>
    public GameObject you_win;
    /// <summary>
    /// final score text
    /// </summary>
    public TextMeshProUGUI final_score;
    /// <summary>
    /// the final score value
    /// </summary>
    public TextMeshProUGUI final_score_text;
    /// <summary>
    /// this function increases the varible current score and updates the score text in the UI
    /// </summary>
    /// <param name="scoreToAdd"></param>
    public void Scoreadder(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        Debug.Log(currentScore);

        scoreText.text = currentScore.ToString();
        
    }
    /// <summary>
    /// //this function increases the variable win condition and updates the amount of win conditions in the UI
    /// </summary>
    /// <param name="win_condition"></param>
    public void Winconadd(int win_condition)
    {
        win_con += win_condition;
        winconText.text = $"{win_con.ToString()} / 5";
        //checks if all 5 win conditions are collected and turns the text yelllow
        if (win_con == 5)
        {
            winconText.color = Color.yellow;
            allWinConCollected = true;
        }
    }
    /// <summary>
    /// this function updates the silver key frag variable and updates the UI on how many key fragments you have collected
    /// <summary>
    /// <param name="keyfrag"></param>
    public void Keyfragadd(int keyfrag)
    {
        keyfrag_01 += keyfrag;
        Debug.Log(keyfrag_01);
        keyfragText.text = $"{keyfrag_01.ToString()} / 4 Fragments Collected";
        //checks if all 4 silver key fragments are collected and turns the text yellow and updates the boolean that checks if all the silver key fragments are collected
        if(keyfrag_01 == 4)
        {
            keyfragText.color = Color.yellow;
            allsilvKeyFragCollected = true;
        }   
    }


    /// <summary>
    /// this function updates the gold key frag variable and updates the UI on how many gold key fragments you have collected
    /// </summary>
    /// <param name="keyfrag"></param>
    public void Keyfraggoldadd(int keyfrag)
    {
        keyfrag_02 += keyfrag;
        Debug.Log(keyfrag_02);
        keyfragGoldText.text = $"{keyfrag_02.ToString()} / 4 Gold Fragments Collected";
        //checks if all 4 gold key fragments are collected and turns the text yellow and updates the boolean that checks if all the gold key fragments are collected
        if (keyfrag_02 == 4)
        {
            keyfragGoldText.color = Color.yellow;
            allgoldKeyFragCollected = true;
        }
    }

    /// <summary>
    /// when the players presses E on an collectible or interactable door
    /// </summary>
    void OnInteract()
    {
        //null check on the bronze door
        if (currentDoor != null)
        {
            //will open door if the player is infront of the specific bronze door
            currentDoor.OpenDoor();
            currentDoor = null;
            script.opened = true;
        }
        //null check on the silver door
        if (currentSilverDoor != null)
        {
            //will open door if the player is infront of the specific silver door
            currentSilverDoor.OpenDoor();
            currentSilverDoor = null;
            script.opened = true;
        }
        //null check on the gold door
        if (currentGoldDoor != null)
        {
            //will open door if the player is infront of the specific gold door
            currentGoldDoor.OpenDoor();
            currentGoldDoor = null;
            script.opened = true;
        }
        //null check on the win condition
        if (wincon != null)
        {
            //will use the winconadd function to increase the win condition amount and collect the object
            Winconadd(wincon.win_condition);
            wincon.Collected();
            //since the game object has been collected it will be reupdated to null
            wincon = null;
        }
        //null check on the gold coin collectible
        if (currentCollectible != null)
        {
            //will use the scoreadder function to increase the score with the value from the gold coin script and collect the object
            Scoreadder(currentCollectible.Gold_Coin);
            currentCollectible.Collected();
            //since the game object has been collected it will be reupdated to null
            currentCollectible = null;
        }
        //null check on the plat coin collectible
        if (currentCollectible1 != null)
        {
            //will use the scoreadder function to increase the score with the value from the plat coin script and collect the object
            Scoreadder(currentCollectible1.Plat_Coin);
            currentCollectible1.Collected();
            //since the game object has been collected it will be reupdated to null
            currentCollectible1 = null;
        }
        //null check on the silver coin collectible
        if (currentCollectible2 != null)
        {
            //will use the scoreadder function to increase the score with the value from the silver coin script and collect the object
            Scoreadder(currentCollectible2.Silv_Coin);
            currentCollectible2.Collected();
            //since the game object has been collected it will be reupdated to null
            currentCollectible2 = null;
        }
        //null check on the silver key fragment collectible
        if (keyfraglvl1 != null)
        {
            //will use the keyfragadd function to increase the amount of silver key fragments collected and collect the object
            Keyfragadd(keyfraglvl1.key_frag);
            keyfraglvl1.Collected();
            //since the game object has been collected it will be reupdated to null
            keyfraglvl1 = null;
        }
        //null check on the gold key fragment collectible
        if (keyfraglvl2 != null)
        {
            //will use the keyfragadd function to increase the amount of gold key fragments collected and collect the object
            Keyfraggoldadd(keyfraglvl2.key_frag_gold);
            keyfraglvl2.Collected();
            //since the game object has been collected it will be reupdated to null
            keyfraglvl2 = null;
        }
        if (buff != null)
        {
            buff.Collected(this);
        }
        //null check on the silver key crafting zone
        if (currentZone != null)
        {
            //this will execute the craftsilvkey function when interacted with
            script1.CraftSilvKey();
            Debug.Log("Interact");
            //if the silver key was crafted the UI will be updated accordingly
            if (script1.silvKeyCrafted)
            {
                keyfragText.gameObject.SetActive(false);
                keyfraglvl1state.gameObject.SetActive(false);
                inv_bg1.gameObject.SetActive(true);
                inv_text1.gameObject.SetActive(true);
                keyfragGoldText.text = $"{keyfrag_02.ToString()} / 4 Gold Fragments Collected";
                keyfragGoldlvl1state.gameObject.SetActive(true);
            }
        }
        //null check on the gold key crafting zone
        if (goldcurrentZone != null)
        {
            //this will execute the craftgoldkey function when interacted with
            script2.CraftGoldKey();
            Debug.Log("Interact");
            //if the gold key was crafted the UI will be updated accordingly
            if (script2.goldKeyCrafted)
            {
                inv_bg2.gameObject.SetActive(true);
                inv_text2.gameObject.SetActive(true);
                keyfragGoldlvl1state.gameObject.SetActive(false);
                keyfragGoldText.gameObject.SetActive(false);
            }
        }
        //null check on the win portal and if all the win conditions have been collected
        if (win != null && allWinConCollected)
        {
            //update the UI if the player has "won" the game
            you_win.gameObject.SetActive(true);
            final_score.gameObject.SetActive(true);
            final_score_text.text = currentScore.ToString();
        }
    }
    /// <summary>
    /// all the functions below assign the current variables to the variables within the game. Which means its telling the player which door its infront of, which collectible its infront of and so on.
    /// </summary>
    /// <param name="newDoor"></param>
    public void UpdateDoor(Door newDoor)
    {
        currentDoor = newDoor;
    }
    public void UpdateSilverDoor(Silver_door newSilverDoor)
    {
        currentSilverDoor = newSilverDoor;
    }
    public void UpdateGoldDoor(Gold_door newGoldDoor)
    {
        currentGoldDoor = newGoldDoor;
    }
    public void UpdateZone(Silv_craftingZone newZone)
    {
        currentZone = newZone;
    }
    public void UpdateZoneGold(Gold_craftingZone newZoneGold)
    {
        goldcurrentZone = newZoneGold;
    }
    public void UpdateCollectible(Collectible_gold newCollectibleGold)
    {
        currentCollectible = newCollectibleGold;
    }
    public void UpdateCollectible1(Collectible_plat newCollectiblePlat)
    {
        currentCollectible1 = newCollectiblePlat;
    }
    public void UpdateCollectible2(Collectible_silv newCollectibleSilv)
    {
        currentCollectible2 = newCollectibleSilv;
    }
    public void UpdateKeyFrag1(Key_fragment newCollectibleFrag1)
    {
        keyfraglvl1 = newCollectibleFrag1;
    }
    public void UpdateKeyFrag2(Key_fragments_gold newCollectibleFrag2)
    {
        keyfraglvl2 = newCollectibleFrag2;
    }
    public void UpdateWinCon(Win_conditions newWinCon)
    {
        wincon = newWinCon;
    }
    public void UpdateWinPortal(Win_portal newWinZone)
    {
        win = newWinZone;
    }
    public void UpdateBuff(Collectible_buff newbuff)
    {
        buff = newbuff;
    }

    // Start is called before the first frame update
    /// <summary>
    /// sets up the UI for the start of the game
    /// </summary>
    void Start()
    {
        winconText.text = $"{win_con.ToString()} / 5";
        keyfragText.text = $"{keyfrag_01.ToString()} / 4 Fragments Collected";
        scoreText.text = currentScore.ToString();
        inv_bg1.gameObject.SetActive(false);
        inv_text1.gameObject.SetActive(false);
        inv_bg2.gameObject.SetActive(false);
        inv_text2.gameObject.SetActive(false);
        keyfragGoldlvl1state.gameObject.SetActive(false);
        you_win.gameObject.SetActive(false);
        final_score.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SingleTon<PlayerManager>
{
    private Deck playerDeck;
    private PlayerData player;
    private Inventory playerInventory;

    
    private Inventory PlayerInventory
    {
        get { return playerInventory; }
        set {playerInventory=PlayerInventory;}
    }
    public Deck PlayerDeck { 
        get { return playerDeck; }
        set { playerDeck = PlayerDeck; }
    }

    public PlayerData PlayerData1 
    { 
        get { return player; } 
        set { player = PlayerData1; } 
    }

    private void Start()
    {
        player= new PlayerData();
        playerDeck=GameObject.Find("Manager").GetComponent<Deck>();
        playerInventory= GameObject.Find("Manager").GetComponent<Inventory>();

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SingleTon<PlayerManager>
{
    private Deck playerDeck;
    private PlayerData player;
    public Deck PlayerDeck { 
        get { return playerDeck; }
        set { playerDeck = PlayerDeck; }
    }

    public PlayerData PlayerData 
    { 
        get { return player; } 
        set { player = PlayerData; } 
    }


}

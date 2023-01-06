using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : SingleTon<PlayerManager>
{
    private Deck playerDeck;

    public Deck PlayerDeck { 
        get { return playerDeck; }
        set { playerDeck = PlayerDeck; }
    }

}

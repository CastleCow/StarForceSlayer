using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckEdit : MonoBehaviour
{
    private Deck pdeck;

    private int maxDeckCount=0;
    
    [SerializeField]
    private ShowCard prefabs;
    
    // Start is called before the first frame update
    void Start()
    {
        pdeck=GameObject.Find("PlayerDeck").GetComponent<Deck>();
        
    }
    // Update is called once per frame
    void Update()
    {
        ShowDeck();

    }
    void ShowDeck()
    {
        if (maxDeckCount < pdeck.cards.Count)
        {
            prefabs.thisId = pdeck.cards[maxDeckCount].CardNum;
            Instantiate(prefabs, transform);
            maxDeckCount++;
        }
    }

    
}

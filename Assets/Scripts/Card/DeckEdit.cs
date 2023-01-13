using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckEdit : MonoBehaviour
{

    public List<CardData> cards;

    private int maxDeckCount=0;
    
    [SerializeField]
    private ShowCard prefabs;


    private void Start()
    {
        cards= PlayerManager.Instance.PlayerDeck.GetCards();
    }
    private void OnEnable()
    {
       // ShowDeck();
    }
    private void Update()
    {
        ShowDeck();
    }
    void ShowDeck()
    {
        if (PlayerManager.Instance.PlayerDeck == null)
            return;
      
        if (maxDeckCount < cards.Count)
        {
            prefabs.thisId = cards[maxDeckCount].CardNum;
            Instantiate(prefabs, transform);
            maxDeckCount++;
        }
    }
    void AddCard()
    {
        
    }
    void RemoveCard()
    {

    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeckEdit : MonoBehaviour
{
    public List<CardData> PrevCards= new List<CardData>();
    public List<CardData> cards;

    private int maxDeckCount = 0;

    [SerializeField]
    private ShowCard prefabs;

    [SerializeField]
    private TextMeshProUGUI cardCount;

    private void Start()
    {
        cards = PlayerManager.Instance.PlayerDeck.GetCards();
        for (int i= 0; i <cards.Count;i++) { PrevCards.Add(cards[i]); }
    }
    private void OnEnable()
    {
        // ShowDeck();
    }
    private void Update()
    {
        ShowDeck();
        cardCount.text=""+ cards.Count.ToString()+" / 30";
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
    
    public void SaveDeck()
    {
        PrevCards.Clear();
        for (int i = 0; i < cards.Count; i++) { PrevCards.Add(cards[i]); }
    }
    public void ExitDeckEdit() 
    {
        PlayerManager.Instance.PlayerDeck.cards.Clear(); 
        for (int i = 0; i < PrevCards.Count; i++) { cards.Add(PrevCards[i]); }
    }

}

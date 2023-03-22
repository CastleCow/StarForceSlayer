using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    public List<CardData> cards = new List<CardData>();
    public List<CardData> container = new List<CardData>();


    private int x = 0;
    private int MinDeckSize = 20;
    private int MaxDeckSize = 30;

    private void Awake()
    {
        cards = new List<CardData>();
        container = new List<CardData>
        {
            null
        };
    }
    private void Start()
    {

        //for (int i = 0; i < MinDeckSize; i++)
        //{
        //    int rannum = Random.Range(1, 7);
        //    cards.Add(null);
        //    cards[i] = DataBaseManager.Instance.datas[rannum];
        //}
        int j = 0;
        for (int i = 0; i < MinDeckSize; i++)
        {
            if (i % 4 == 0)
                j++;
            if (j > 6) j = 6;
            cards.Add(null);
            cards[i] = DataBaseManager.Instance.cardDatas[j];
        }
        //BaseDeck();
    }
    public void Shuffle()
    {
        for (int i = 0; i < MinDeckSize; i++)
        {
            container[0] = cards[i];
            int randomIndex = Random.Range(i, MinDeckSize);
            cards[i] = cards[randomIndex];
            cards[randomIndex] = container[0];
        }
    }
    private void BaseDeck()
    {
        int j = 0;
        for (int i = 0; i < MinDeckSize; i++)
        {
            if (i % 3 == 0)
                j++;
            if (j > 6) j = 6;
            cards.Add(null);
            cards[i].CardNum = j;
        }

    }
    public List<CardData> GetCards() { return cards; }

    public void Add(CardData card)
    {
        cards.Add(card);
    }

    public void Add(List<CardData> newCards)
    {
        foreach (CardData card in newCards)
        {
            cards.Add(card);
        }
    }

    public void Remove(CardData card)
    {
        cards.Remove(card);
    }

}

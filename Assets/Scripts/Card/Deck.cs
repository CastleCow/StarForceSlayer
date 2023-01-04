using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    private CardDataBase m_base;
    public List<CardData> cards = new List<CardData>();
    public List<CardData> container = new List<CardData>();


    private int x = 0;
    private int DeckSize = 20;

    private void Awake()
    {
        
    }
    private void Start()
    {
        m_base = GameObject.Find("CardDataBase").GetComponent<CardDataBase>();
        for (int i = 0; i < DeckSize; i++)
        {
            int rannum = Random.Range(1, 7);
            cards[i] = m_base.datas[rannum];
        }
        //BaseDeck();
    }
    private void Shuffle()
    {
        for(int i = 0; i < DeckSize; i++)
        {
            container[0] = cards[i];
            int randomIndex=Random.Range(i, DeckSize);
            cards[i] = cards[randomIndex];
            cards[randomIndex] = container[0];
        }
    }
    private void BaseDeck()
    {
        int j = 0;
        for(int i=0;i< DeckSize;i++)
        {
            if (i % 3 == 0)
                    j++;
            if (j > 6) j = 6;
            cards[i].CardNum = j;
        }
        
    }

}

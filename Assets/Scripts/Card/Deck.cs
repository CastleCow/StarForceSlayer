using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    public List<CardData> cards = new List<CardData>();
    public List<CardData> container = new List<CardData>();


    private int x = 0;
    private int DeckSize = 20;

    private void Start()
    {
        for(int i=0;i<DeckSize;i++)
        {
            //cards[i] = CardDataBase.datas[0];
        }
    }

    private void Shuffle()
    {
        for(int i = 0; i < DeckSize; i++)
        {
            container[0] = cards[i];
            int randomIndex=Random.Range(0, DeckSize);
            cards[i] = cards[randomIndex];
            cards[randomIndex] = container[randomIndex];
        }
    }


}

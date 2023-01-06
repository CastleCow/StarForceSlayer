using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : SingleTon<DeckManager>
{

    public class Deck
    {
        private List<CardData> Cards;

        public Deck(List<CardData> cards)
        {
            Cards = cards;
        }
        public List<CardData> GetCards() { return Cards; }

        public void Add(CardData card)
        {
            Cards.Add(card);
        }

        public void Add(List<CardData> newCards)
        {
            foreach (CardData card in newCards)
            {
                Cards.Add(card);
            }
        }

        public void Remove(CardData card)
        {
            Cards.Remove(card);
        }


    }

}

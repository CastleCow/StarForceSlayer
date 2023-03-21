using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCard : MonoBehaviour
{
    [SerializeField]
    private ShowCard[] showCards;

    public CardData cardSelect;

    

    private void Start()
    {
        //showCards = new ShowCard[6];
        cardSelect = new CardData();  
        
        Show();
    }
    private void OnEnable()
    {
        
        Show();
        int i = BattleManager.Instance.player.MaxUsingCost;
        BattleManager.Instance.player.CardUsingCost = i;
    }
    private void Show()
    {
        for (int i = 0; i < showCards.Length; i++) {
            showCards[i].gameObject.SetActive(true);
            showCards[i].thisId = PlayerManager.Instance.PlayerDeck.cards[i].CardNum; 
        }
    }

    public void CardSelection(ShowCard card)
    {
        if (BattleManager.Instance.player.CardUsingCost < cardSelect.Cost) { card.gameObject.SetActive(true); return; }
        int i = card.cardId;
        cardSelect = DataBaseManager.Instance.cardDatas[i];
    }
    public void ToHand()
    {
        //선택된 카드의코스트합계가 현재플레이어 코스트보다 높을경우 리턴  
        if (BattleManager.Instance.player.CardUsingCost < cardSelect.Cost) { return; }

        //this.gameObject.SetActive(false);
        BattleManager.Instance.hands.Add(cardSelect);
        BattleManager.Instance.deck.Remove(cardSelect);
        BattleManager.Instance.player.CardUsingCost -= cardSelect.Cost;
    }
    public void ToGrave()
    {
        BattleManager.Instance.grave.Add(cardSelect);
        BattleManager.Instance.hands.Remove(cardSelect);

    }

}

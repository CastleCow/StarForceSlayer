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
        //���õ� ī�����ڽ�Ʈ�հ谡 �����÷��̾� �ڽ�Ʈ���� ������� ����  
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

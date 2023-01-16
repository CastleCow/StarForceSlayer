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
    }
    private void Show()
    {
        for (int i = 0; i < showCards.Length; i++) {
            showCards[i].thisId = PlayerManager.Instance.PlayerDeck.cards[i].CardNum; 
        }
    }

    public void ToHand()
    {
        //선택된 카드의코스트합계가 현재플레이어 코스트보다 높을경우 리턴  
        if (PlayerManager.Instance.cardUsingCost < cardSelect.Cost) { return; }

        //this.gameObject.SetActive(false);
        BattleManager.Instance.hands.Add(cardSelect);
        PlayerManager.Instance.cardUsingCost-=cardSelect.Cost;
    }
    public void ToGrave()
    {
        BattleManager.Instance.hands.Remove(cardSelect);
        BattleManager.Instance.grave.Add(cardSelect);

    }
}

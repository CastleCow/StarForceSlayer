using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<CardData> inventory;
    public int? Money;
    public int[] Amount;

    private void Start()
    {
        inventory = DataBaseManager.Instance.datas;
        Amount=new int[inventory.Count];
    }
    public void AcquireCard(CardData card)
    {
        Amount[card.CardNum]++;
    }
    public void Buy(CardData card)
    {
        if (Money < card.Price)
            return;
        Money-=card.Price;
        Amount[card.CardNum]++;

    }
    public void Sell(CardData data)
    {
        if (Amount[data.CardNum] == 0)
            return;
        Money += data.Price;
        Amount[data.CardNum]--;
    }

}


/*
 카드 번호
 카드 이름
 카드양
 
전투로 카드 획득
획득시 카드양 증가
판매시 카드양 감소 소지금 증가

 */
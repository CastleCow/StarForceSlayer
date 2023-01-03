using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static CardData;


public class CardDataBase : MonoBehaviour
{
    public List<CardData> datas=new List<CardData>();

    private void Awake()
    {
        datas.Add(new CardData(0,"NULL",        CardAttackTarget.Range,     0, 0, 0,0,null));
        datas.Add(new CardData(1,"Cannon",      CardAttackTarget.Raycast,   40,0,10,1,Resources.Load<Sprite>("00Cannon")));
        datas.Add(new CardData(2,"Cannon+",     CardAttackTarget.Raycast,   60,0,20,2,Resources.Load<Sprite>("01Cannon+")));
        datas.Add(new CardData(3,"Sword",       CardAttackTarget.Range,     80,0,15,1,Resources.Load<Sprite>("07Sword")));
        datas.Add(new CardData(4,"WideSword",   CardAttackTarget.Range,     80,0,30,2,Resources.Load<Sprite>("09WideSword")));
        datas.Add(new CardData(5,"LongSword",   CardAttackTarget.Range,     80,0,30,2,Resources.Load<Sprite>("12ElecSword")));
        datas.Add(new CardData(6,"Recov10",     CardAttackTarget.ToMe,      10,0,10,1,Resources.Load<Sprite>("20Recov10")));

    }
}
//int cardNum, string cardName, CardAttackMethod attackMethod, int damage, int? cardRange, int? price, int cost
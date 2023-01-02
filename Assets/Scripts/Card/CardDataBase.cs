using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static CardData;

public class CardDataBase : MonoBehaviour
{
    public List<CardData> datas=new List<CardData>();

    private void Awake()
    {
        datas.Add(new CardData(0,"NULL",        CardAttackMethod.Range,     0, 0, 0,0));
        datas.Add(new CardData(1,"Cannon",      CardAttackMethod.Raycast,   40,0,10,1));
        datas.Add(new CardData(2,"Sword",       CardAttackMethod.Range,     80,0,15,1));
        datas.Add(new CardData(3,"Cannon+",     CardAttackMethod.Raycast,   60,0,20,2));
        datas.Add(new CardData(4,"WideSword",   CardAttackMethod.Range,     80,0,30,2));
        datas.Add(new CardData(5,"LongSword",   CardAttackMethod.Range,     80,0,30,2));

    }
}
//int cardNum, string cardName, CardAttackMethod attackMethod, int damage, int? cardRange, int? price, int cost
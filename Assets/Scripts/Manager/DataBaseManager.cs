using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CardData;

public class DataBaseManager : SingleTon<DataBaseManager>
{

    public List<CardData> cardDatas = new List<CardData>();
    public List<MonData> mons = new List<MonData>();

    

    private void Awake()
    {

        //cardDatas.Add(new CardData(0, "NULL", CardAttackTarget.Range, 0, null, 0, 0, null));
        //cardDatas.Add(new CardData(1, "Cannon", CardAttackTarget.Raycast, 40, null, 10, 1, Resources.Load<Sprite>("00Cannon")));
        //cardDatas.Add(new CardData(2, "Cannon+", CardAttackTarget.Raycast, 60, null, 20, 2, Resources.Load<Sprite>("01Cannon+")));
        //cardDatas.Add(new CardData(3, "Sword", CardAttackTarget.Range, 80, new CardAttackRange(1,1), 15, 1, Resources.Load<Sprite>("07Sword")));
        //cardDatas.Add(new CardData(4, "WideSword", CardAttackTarget.Range, 80, new CardAttackRange(3, 1), 30, 2, Resources.Load<Sprite>("09WideSword")));
        //cardDatas.Add(new CardData(5, "LongSword", CardAttackTarget.Range, 80, new CardAttackRange(1, 2), 30, 2, Resources.Load<Sprite>("12ElecSword")));
        //cardDatas.Add(new CardData(6, "Recov10", CardAttackTarget.ToMe, 10, null, 10, 1, Resources.Load<Sprite>("20Recov10")));

        mons.Add(new MonData(0, "NULL", 0, MonData.MonsterType.None, 0));
        mons.Add(new MonData(1, "Wolf", 40, MonData.MonsterType.Normal, 10));
        mons.Add(new MonData(2, "Wolf+", 60, MonData.MonsterType.Normal, 10));
        mons.Add(new MonData(3, "Scorpion", 50, MonData.MonsterType.Normal, 10));
        mons.Add(new MonData(4, "ScorpionKing", 100, MonData.MonsterType.Elite, 10));
        mons.Add(new MonData(5, "Wraith", 300, MonData.MonsterType.Boss, 10));
    }
}







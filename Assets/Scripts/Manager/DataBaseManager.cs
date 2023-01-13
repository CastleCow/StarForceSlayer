using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CardData;

public class DataBaseManager :SingleTon<DataBaseManager> 
{
 
        public List<CardData> datas = new List<CardData>();
        public List<MonData> mons = new List<MonData>();

    private void Awake()
        {

            datas.Add(new CardData(0, "NULL", CardAttackTarget.Range, 0, 0, 0, 0, null));
            datas.Add(new CardData(1, "Cannon", CardAttackTarget.Raycast, 40, 0, 10, 1, Resources.Load<Sprite>("00Cannon")));
            datas.Add(new CardData(2, "Cannon+", CardAttackTarget.Raycast, 60, 0, 20, 2, Resources.Load<Sprite>("01Cannon+")));
            datas.Add(new CardData(3, "Sword", CardAttackTarget.Range, 80, 0, 15, 1, Resources.Load<Sprite>("07Sword")));
            datas.Add(new CardData(4, "WideSword", CardAttackTarget.Range, 80, 0, 30, 2, Resources.Load<Sprite>("09WideSword")));
            datas.Add(new CardData(5, "LongSword", CardAttackTarget.Range, 80, 0, 30, 2, Resources.Load<Sprite>("12ElecSword")));
            datas.Add(new CardData(6, "Recov10", CardAttackTarget.ToMe, 10, 0, 10, 1, Resources.Load<Sprite>("20Recov10")));
            mons.Add(new MonData(0, "NULL", 0, MonData.MonsterType.None, 0));
            mons.Add(new MonData(1, "Wolf", 40, MonData.MonsterType.Normal, 10));
            mons.Add(new MonData(2, "Wolf+", 60, MonData.MonsterType.Normal, 10));
            mons.Add(new MonData(3, "Scorpion", 50, MonData.MonsterType.Normal, 10));
            mons.Add(new MonData(4, "ScorpionKing", 100, MonData.MonsterType.Elite, 10));
            mons.Add(new MonData(5, "Wraith", 300, MonData.MonsterType.Boss, 10));
    }
 }

       
      
    



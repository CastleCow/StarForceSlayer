using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCardSkill : MonoBehaviour
{
    public CardData thiscard;

    protected virtual void Start()
    {
        thiscard = BattleManager.Instance.hands[0];   
    }
    protected virtual void Update()
    {
        thiscard = BattleManager.Instance.hands[0];
    }
    public virtual void CardAttack(GameObject Player)
    {
        
    }
}


/*
 카드 스킬 공용틀 
 카드는 레이케스트 타입-
 
 */
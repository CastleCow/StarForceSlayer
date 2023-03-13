using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCardSkill : MonoBehaviour
{
    public CardData thiscard;
    public string animTrigger;
    public string m_ParticleName;
    protected virtual void Start()
    {
        if(BattleManager.Instance.hands.Count!=1)
        thiscard = BattleManager.Instance.hands[1];   
    }
    protected virtual void Update()
    {
        if(BattleManager.Instance.hands.Count!=1)
        thiscard = BattleManager.Instance.hands[1];
    }
    public virtual void CardAttack(GameObject Player)
    {
        Debug.Log("카드부모는 사용함");
    }
}


/*
 카드 스킬 공용틀 
 카드는 레이케스트 타입-
 
 */
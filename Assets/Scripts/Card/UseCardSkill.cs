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
 ī�� ��ų ����Ʋ 
 ī��� �����ɽ�Ʈ Ÿ��-
 
 */
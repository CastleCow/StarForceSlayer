using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCardSkill : MonoBehaviour
{
    public CardData thiscard;
    public string animTrigger;
    protected virtual void Start()
    {
        thiscard = BattleManager.Instance.hands[1];   
    }
    protected virtual void Update()
    {
        //thiscard = BattleManager.Instance.hands[1];
    }
    public virtual void CardAttack(GameObject Player)
    {
        Debug.Log("ī��θ�� �����");
    }
}


/*
 ī�� ��ų ����Ʋ 
 ī��� �����ɽ�Ʈ Ÿ��-
 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : UseCardSkill
{
    public override void CardAttack(GameObject Player)
    {
        Debug.Log("Heal");
        BattleManager.Instance.player.CurHp += thiscard.Damage;
    }
}

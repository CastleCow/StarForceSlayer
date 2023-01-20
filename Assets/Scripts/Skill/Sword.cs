using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : UseCardSkill
{
    private int attackRange;
    private int attackAngle;
    public override void CardAttack(GameObject Player)
    {
        Debug.Log("소드");
        this.attackRange = thiscard.AttackRange*10;
        this.attackAngle = thiscard.AttackAngle*30;
        // 1. 범위내에 있는가
        Collider[] colliders = Physics.OverlapSphere(Player.transform.position, attackRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.name != "Cube")
                continue;

            Vector3 dirToTarget = (colliders[i].transform.position - Player.transform.position).normalized;

            // 2. 각도내에 있는가
            if (Vector3.Dot(Player.transform.forward, dirToTarget) < Mathf.Cos(attackAngle * 0.5f * Mathf.Deg2Rad))
                continue;

            
        }
    }
}

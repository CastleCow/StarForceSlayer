using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : UseCardSkill
{
    private float attackRange;
    private float attackAngle;

    public override void CardAttack(GameObject Player)
    {
        // 1. �������� �ִ°�
        Collider[] colliders = Physics.OverlapSphere(transform.position, attackRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.name != "Cube")
                continue;

            Vector3 dirToTarget = (colliders[i].transform.position - transform.position).normalized;

            // 2. �������� �ִ°�
            if (Vector3.Dot(transform.forward, dirToTarget) < Mathf.Cos(attackAngle * 0.5f * Mathf.Deg2Rad))
                continue;


        }
    }
}

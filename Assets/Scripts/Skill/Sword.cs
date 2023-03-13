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
        animTrigger = "Sword";
        this.attackRange = thiscard.AttackRange*2;
        this.attackAngle = thiscard.AttackAngle*30;
        m_ParticleName = thiscard.AttackAngle < 2 ? "VerticalSlash" : "HorizontalSlash";
        
            
        
        // 1. 범위내에 있는가
        Collider[] colliders = Physics.OverlapSphere(Player.transform.position, attackRange,LayerMask.GetMask("Monster"));
        for (int i = 0; i < colliders.Length; i++)
        {
            //if (colliders[i].gameObject.name != "Cube")
            //    continue;
            Vector3 dirToTarget = (colliders[i].transform.position - Player.transform.position).normalized;

            // 2. 각도내에 있는가
            if (Vector3.Dot(Player.transform.forward, dirToTarget) < Mathf.Cos(attackAngle * 0.5f * Mathf.Deg2Rad))
                continue;
            IDamagable target = colliders[i].GetComponent<IDamagable>();
            Debug.Log(target);
            target?.TakeDamage(thiscard.Damage);
            
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Vector3 rightDir = AngleToDir(transform.eulerAngles.y + attackAngle * 0.5f);
        Vector3 leftDir = AngleToDir(transform.eulerAngles.y - attackAngle * 0.5f);
        Debug.DrawRay(transform.position, rightDir * attackRange, Color.blue);
        Debug.DrawRay(transform.position, leftDir * attackRange, Color.blue);
    }

    private Vector3 AngleToDir(float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radian), 0, Mathf.Cos(radian));
    }
}

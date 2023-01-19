using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : UseCardSkill
{
    public override void CardAttack(GameObject Player)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 0.3f, 0), Vector3.forward * 7f, out hit, Mathf.Infinity))
        {
            IDamagable target = hit.transform.GetComponent<IDamagable>();
            target?.TakeDamage(thiscard.Damage);
        }
    }
}

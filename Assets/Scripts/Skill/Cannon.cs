using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : UseCardSkill
{
    public override void CardAttack(GameObject Player)
    {
        animTrigger = "Burst";
        Debug.Log("Ä³³í");
        RaycastHit hit;
        if (Physics.Raycast(Player.transform.position + new Vector3(0, 0.3f, 0), Vector3.forward * 7f, out hit, Mathf.Infinity,LayerMask.GetMask("Monster")))
        {
            IDamagable target = hit.transform.GetComponent<IDamagable>();
            Debug.Log(target);
            target?.TakeDamage(thiscard.Damage);
        }

    }
}

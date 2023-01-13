using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMoveBase : MonoBehaviour,IDamagable
{
    
    public virtual void Move()
    {
        Debug.Log("MonMove");
    }
    public virtual void Attack()
    {

        Debug.Log("MonAttack");
    }
    public virtual void TakeDamage(int damage)
    {

    }
    
}
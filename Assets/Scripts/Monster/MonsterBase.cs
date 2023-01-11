using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : MonoBehaviour
{
    public virtual void Move()
    {
        Debug.Log("MonMove");
    }
    public virtual void Attack()
    {

        Debug.Log("MonAttack");
    }
    
}

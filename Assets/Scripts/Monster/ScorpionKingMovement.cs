using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionKingMovement : MonsterMoveBase, IDamagable
{
    private Vector3 ReturnPos;
    private int MoveVec;
    private bool targetLock;
    protected override IEnumerator MoveRoutine()
    {
        Debug.Log("ScorkingRou");
        while (true)
        {
            yield return new WaitForSeconds(moveDelay);
            
                Move();

                Attack();
            
        }
    }
    public override void Move()
    {
        

    }
    public override void Attack()
    {
        if (BattleManager.Instance.MonsCount!=1)//||( < transform.position.x && transform.position.x < 1.25))
        {
            return;
        }
        rigid.MovePosition(new Vector3(transform.position.x, transform.position.y, transform.position.z - Time.deltaTime));
        if (transform.position.z < -2.5)
        {
            transform.position = ReturnPos;
            targetLock = false;
        }



    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("스콜피킹 트리거 온");
        IDamagable target = other.transform.GetComponent<IDamagable>();
        target?.TakeDamage(mondata.baseDamage);
        if (target != null)
        {
            transform.position = ReturnPos;
            targetLock = false;
        }
    }
    public override void TakeDamage(int damage)
    {
        if(BattleManager.Instance.MonsCount!=1) { return; }
        curHp -= damage;
        if (curHp <= 0)
        {
            IsDead();
        }
    }
}
/*
 애들이 살아있으면 후방에서 원거리 공격 무적
 애들이 다 죽으면 육탄 공격
 
 
 */
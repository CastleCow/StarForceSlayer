using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithMovement : MonsterMoveBase
{
    int atkCount=0;
    [SerializeField]
    private GameObject[] Plane;
    private void Start()
    {
        moveRoutine=StartCoroutine(MoveRoutine());

    }
    private IEnumerator MoveRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveDelay);
            if (atkCount < 2)
                Move();
            else
                UsePattern();
        }
    }
    public override void Move()
    {
        for (int i = 0; i < Plane.Length; i++) {
            Plane[i].SetActive(false); 
        }
        //x=-1.2 0 1.2
        float x = (Random.Range(0, 3) - 1) * 1.2f;
        //z=-1.25~2.5
        float z = (Random.Range(0, 4) - 1) * 1.25f;


        rigid.MovePosition(new Vector3(x, 0, z));
        //실행시 점프 모션
        atkCount++;
    }
    private void UsePattern()
    {
        int i = Random.Range(0, 3);

        switch (i)
        {
            case 0:
                Pattern1();
                break;
            case 1:
                Pattern2();
                break;
            case 2: 
                Pattern3(); 
                break;
        }
    }
    private void Pattern1()
    {
        //윙스탭 공격
        anim.SetTrigger("StabAtk");


        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 0.3f, 0), Vector3.back * 7f, out hit, Mathf.Infinity, LayerMask.GetMask("Player")))
        {
            IDamagable target = hit.transform.GetComponent<IDamagable>();
            target?.TakeDamage(mondata.baseDamage);
        }
    }
    private void Pattern2()
    {
        //윙 슬래시 공격
        anim.SetTrigger("SlashAtk");
        Debug.Log("슬래시");
        
        float attackRange = 2;
        float attackAngle =90;
        // 1. 범위내에 있는가
        Collider[] colliders = Physics.OverlapSphere(transform.position, attackRange, LayerMask.GetMask("Player"));
        for (int i = 0; i < colliders.Length; i++)
        {
            //if (colliders[i].gameObject.name != "Cube")
            //    continue;
            Vector3 dirToTarget = (colliders[i].transform.position - transform.position).normalized;

            // 2. 각도내에 있는가
            if (Vector3.Dot(transform.forward, dirToTarget) < Mathf.Cos(attackAngle * 0.5f * Mathf.Deg2Rad))
                continue;
            IDamagable target = colliders[i].GetComponent<IDamagable>();
            Debug.Log(target);
            target?.TakeDamage(mondata.baseDamage);

        }

    }

    private void Pattern3()
    {
        //윙 스핀 공격
        anim.SetTrigger("SpinAtk");
        Debug.Log("스핀");
        float attackRange = 2;
       
        Collider[] colliders = Physics.OverlapSphere(transform.position, attackRange, LayerMask.GetMask("Player"));
        for (int i = 0; i < colliders.Length; i++)
        {
            
            IDamagable target = colliders[i].GetComponent<IDamagable>();
            Debug.Log(target);
            target?.TakeDamage(mondata.baseDamage);

        }

    }
}
/*
 2회 이동후 1회 공격
 윙스탭 공격(레이캐스트) 윙슬래시 공격(전방 범위 공격)

 윙스핀(전범위 공격)


 
 */
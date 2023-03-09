using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class WolfMovement1 : MonsterMoveBase,IDamagable
{
    private int atkCount;
    private Vector3 Pos;
    [SerializeField]
    private GameObject Plane;
    protected override IEnumerator MoveRoutine()
    {
        Debug.Log("WolfRou");
        while (true)
        {
            yield return new WaitForSeconds(moveDelay);
            if (atkCount < 3)
                Move();
            else
                Attack();
        }
    }
    public void NextPos()
    {
        //x=-1.2 0 1.2
        Pos.x = (Random.Range(0, 3) - 1) * 1.2f;
        //z=-1.25~2.5
        Pos.z = (Random.Range(0, 4) - 1) * 1.25f;

    }
    public override void Move()
    {
        Plane.SetActive(false);
        //x=-1.2 0 1.2
        NextPos();


        rigid.MovePosition(new Vector3(Pos.x, 0.5f, Pos.z));
        //실행시 점프 모션
        atkCount++;

    }
    public override void Attack()
    {
        atkCount = 0;
        //랜덤 무브3회 실행후 1회 공격

        //x는 플레이어와 같은 위치
        //z는 플레이어칸 앞으로 일반적으로 -1.25f
        rigid.MovePosition(new Vector3(Pos.x, 0, -1.25f));

        anim.SetTrigger("Bite Attack");
        Plane.SetActive(true);

        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 0.3f, 0), Vector3.back * 7f, out hit, Mathf.Infinity, LayerMask.GetMask("Player")))
        {
            IDamagable target = hit.transform.GetComponent<IDamagable>();
            target?.TakeDamage(mondata.baseDamage);
        }


    }
    
}
 /*
 기본 움직임은 좌우 이동
 레이캐스트 해서 내위치가 패널위이고 레이캐스트가 맞으면 그자리에서 쭉 전진
 플레이어 패널까지 전진하고 플레이어 패널에 올라오면 다시 출발지점으로 돌아간다.
 
 */
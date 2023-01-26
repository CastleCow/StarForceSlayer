using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionMovement : MonsterMoveBase
{
    private IEnumerator MoveRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveDelay);
            if ( )
                Move();
            else
                Attack();
        }
    }
    public override void Move()
    {
        //좌우이동 x(-1.2~1.2)
        if (transform.position.x < -1.2)
            rigid.MovePosition(new Vector3(transform.position.x + Time.deltaTime, transform.position.y, transform.position.z));
        else if(transform.position.x > 1.2)
            rigid.MovePosition(new Vector3(transform.position.x - Time.deltaTime, transform.position.y, transform.position.z));


    }
    public override void Attack()
    {
        
    }
}
 /*
 기본 움직임은 좌우 이동
 레이캐스트 해서 내위치가 패널위이고 레이캐스트가 맞으면 그자리에서 쭉 전진
 플레이어 패널까지 전진하고 플레이어 패널에 올라오면 다시 출발지점으로 돌아간다.
 
 */
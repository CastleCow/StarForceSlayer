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
           // if ( )
                Move();
            //else
                Attack();
        }
    }
    public override void Move()
    {
        //�¿��̵� x(-1.2~1.2)
        if (transform.position.x < -1.2)
            rigid.MovePosition(new Vector3(transform.position.x + Time.deltaTime, transform.position.y, transform.position.z));
        else if(transform.position.x > 1.2)
            rigid.MovePosition(new Vector3(transform.position.x - Time.deltaTime, transform.position.y, transform.position.z));


    }
    public override void Attack()
    {
        if((-1.25<transform.position.x&& transform.position.x<-1.15)|| 
            (-0.05 < transform.position.x && transform.position.x < 0.05)||
            (1.15 < transform.position.x && transform.position.x < 1.25))
        {
            return;
        }
    }
}
 /*
 �⺻ �������� �¿� �̵�
 ����ĳ��Ʈ �ؼ� ����ġ�� �г����̰� ����ĳ��Ʈ�� ������ ���ڸ����� �� ����
 �÷��̾� �гα��� �����ϰ� �÷��̾� �гο� �ö���� �ٽ� ����������� ���ư���.
 
 */
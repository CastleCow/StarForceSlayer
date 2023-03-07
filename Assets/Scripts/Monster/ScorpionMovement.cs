using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
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
        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 0.3f, 0), Vector3.back * 7f, out hit, Mathf.Infinity, LayerMask.GetMask("Player")))
        {
            
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        IDamagable target = other.transform.GetComponent<IDamagable>();
        target?.TakeDamage(mondata.baseDamage);
    }
}
 /*
 �⺻ �������� �¿� �̵�
 ����ĳ��Ʈ �ؼ� ����ġ�� �г����̰� ����ĳ��Ʈ�� ������ ���ڸ����� �� ����
 �÷��̾� �гα��� �����ϰ� �÷��̾� �гο� �ö���� �ٽ� ����������� ���ư���.
 
 */
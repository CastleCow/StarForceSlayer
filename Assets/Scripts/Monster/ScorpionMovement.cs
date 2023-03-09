using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ScorpionMovement : MonsterMoveBase,IDamagable
{

    private Vector3 ReturnPos;
    private int MoveVec;
    private bool targetLock;
    protected override IEnumerator MoveRoutine()
    {
        Debug.Log("ScorRou");
        while (true)
        {
            yield return new WaitForSeconds(moveDelay);
            if (targetLock)
            {
                MoveForward();
            }
            else
            {
                Move();

                Attack();
            }
        }
    }
    public override void Move()
    {
        //�¿��̵� x(-1.2~1.2)
        if (transform.position.x < -1.2)
            MoveVec = 1;
        //rigid.MovePosition(new Vector3(transform.position.x + Time.deltaTime, transform.position.y, transform.position.z));
        else if (transform.position.x > 1.2)
            MoveVec = -1;
            //rigid.MovePosition(new Vector3(transform.position.x - Time.deltaTime, transform.position.y, transform.position.z));
        rigid.MovePosition(new Vector3(transform.position.x + MoveVec*Time.deltaTime, transform.position.y, transform.position.z));


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
            targetLock= true;
            if (-1.25 < transform.position.x && transform.position.x < -1.15)
            {
                ReturnPos= new Vector3(-1.2f,transform.position.y, transform.position.z);
            }
            else if (-0.05 < transform.position.x && transform.position.x < 0.05)
            {
                ReturnPos= new Vector3(0,transform.position.y, transform.position.z);

            }
            else if(1.15 < transform.position.x && transform.position.x < 1.25)
            {
                ReturnPos= new Vector3(1.2f,transform.position.y, transform.position.z);

            }
            //MoveVec = 0;

        }



    }
    private void MoveForward()
    {
        rigid.MovePosition(new Vector3(transform.position.x , transform.position.y , transform.position.z - Time.deltaTime));
        if (transform.position.z < -2.5)
        {
            transform.position = ReturnPos;
            targetLock = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("������ Ʈ���� ��");
        IDamagable target = collision.transform.GetComponent<IDamagable>();
        target?.TakeDamage(mondata.baseDamage);
        if (target != null)
        {
            transform.position = ReturnPos;
            targetLock = false;
        }
    }
   
}
 /*
 �⺻ �������� �¿� �̵�
 ����ĳ��Ʈ �ؼ� ����ġ�� �г����̰� ����ĳ��Ʈ�� ������ ���ڸ����� �� ����
 �÷��̾� �гα��� �����ϰ� �÷��̾� �гο� �ö���� �ٽ� ����������� ���ư���.
 
 */
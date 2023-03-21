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
        if((-1.15 < transform.position.x&& transform.position.x< -0.05) || 
            (0.05 < transform.position.x && transform.position.x < 1.15) )//||( < transform.position.x && transform.position.x < 1.25))
        {
            return;
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 0.3f, 0), Vector3.back * 7f, out hit, Mathf.Infinity, LayerMask.GetMask("Player")))
        {
            targetLock= true;
            if (-1.25 <= transform.position.x && transform.position.x <= -1.15)
            {
                ReturnPos= new Vector3(-1.2f,transform.position.y, transform.position.z);
            }
            else if (-0.06 <= transform.position.x && transform.position.x <= 0.06)
            {
                ReturnPos= new Vector3(0,transform.position.y, transform.position.z);

            }
            else if(1.14 <= transform.position.x && transform.position.x <= 1.26)
            {
                ReturnPos= new Vector3(1.2f,transform.position.y, transform.position.z);
            }
            Debug.Log(ReturnPos);
            

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
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("������ Ʈ���� ��");
        IDamagable target = other.transform.GetComponent<IDamagable>();
        target?.TakeDamage(mondata.baseDamage);
        //m_poolManager.NameGet("Hit_NormalAttack", other.transform.position);
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
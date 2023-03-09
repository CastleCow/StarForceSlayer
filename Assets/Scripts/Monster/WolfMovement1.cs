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
        //����� ���� ���
        atkCount++;

    }
    public override void Attack()
    {
        atkCount = 0;
        //���� ����3ȸ ������ 1ȸ ����

        //x�� �÷��̾�� ���� ��ġ
        //z�� �÷��̾�ĭ ������ �Ϲ������� -1.25f
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
 �⺻ �������� �¿� �̵�
 ����ĳ��Ʈ �ؼ� ����ġ�� �г����̰� ����ĳ��Ʈ�� ������ ���ڸ����� �� ����
 �÷��̾� �гα��� �����ϰ� �÷��̾� �гο� �ö���� �ٽ� ����������� ���ư���.
 
 */
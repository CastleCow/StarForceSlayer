using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class WolfMovement : MonoBehaviour,IDamagable
{
    private MonData Wolf;
    private float x, z;
    private int curhp;
    private int atkCount;
    [SerializeField]
    private Rigidbody rigid;
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private TextMeshProUGUI HP;

    [SerializeField]
    private float moveDelay;
    private Coroutine moveRoutine;

    [SerializeField]
    private GameObject Plane;

    

    private void Start()
    {
        moveRoutine = StartCoroutine(MoveRoutine());
        Wolf = DataBaseManager.Instance.mons[1];
        curhp = Wolf.curHp;
    }

    // Update is called once per frame
    void Update()
    {
   
        HP.text=""+curhp;
    }

    private IEnumerator MoveRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(moveDelay);
            if(atkCount<3)
                RandMoveWolf();
            else
                WolfAttack();
        }
    }
    public void NextPos()
    {
        //x=-1.2 0 1.2
        x = (Random.Range(0, 3) - 1) * 1.2f;
        //z=-1.25~2.5
        z = (Random.Range(0, 4) - 1) * 1.25f;

    }
    private void RandMoveWolf()
    {
        Plane.SetActive(false);
        //x=-1.2 0 1.2
        NextPos();


        rigid.MovePosition(new Vector3(x, 0.5f, z));
        //실행시 점프 모션
        atkCount++;
    }
    private void WolfAttack()
    {
        atkCount = 0;
        //랜덤 무브3회 실행후 1회 공격
        
        //x는 플레이어와 같은 위치
        //z는 플레이어칸 앞으로 일반적으로 -1.25f
        rigid.MovePosition(new Vector3(x, 0, -1.25f));

        anim.SetTrigger("Bite Attack");
        Plane.SetActive(true);

        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 0.3f, 0), Vector3.back * 7f, out hit, Mathf.Infinity,LayerMask.GetMask("Player")))
        {
            IDamagable target = hit.transform.GetComponent<IDamagable>();
            target?.TakeDamage(Wolf.baseDamage);
        }


    }
    public void TakeDamage(int damage)
    {
        curhp-=damage;
        if (curhp <= 0)
        {
            IsDead();
        }
    }
    private void IsDead()
    {
        BattleManager.Instance.MonsCount--;
        gameObject.SetActive(false);
    }
    private void OnDrawGizmosSelected()
    {
        Vector3 dir = AngleToDir(transform.eulerAngles.z );
        Debug.DrawRay(transform.position+new Vector3(0,0.7f,-0.3f),Vector3.down-dir*1.0f, Color.red);

        Debug.DrawRay(transform.position + new Vector3(0, 0.3f, 0), Vector3.back * 7f, Color.green);
    }

    private Vector3 AngleToDir(float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radian), 0, Mathf.Cos(radian));
    }
}



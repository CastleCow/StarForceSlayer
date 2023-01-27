using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonsterMoveBase : MonoBehaviour,IDamagable
{
    public MonData mondata;
    [SerializeField]
    protected Rigidbody rigid;
    [SerializeField]
    protected Animator anim;
    [SerializeField]
    protected float moveDelay;
    protected Coroutine moveRoutine;
    [SerializeField]
    protected TextMeshProUGUI HP;
    protected int curHp;
    private void Start()
    {
        curHp = mondata.curHp;
    }
    protected void Update()
    {
        HP.text =""+ curHp;
    }
   
    public virtual void Move()
    {
        Debug.Log("MonMove");
    }
    public virtual void Attack()
    {

        Debug.Log("MonAttack");
    }
    public virtual void TakeDamage(int damage)
    {
        curHp-=damage;
        if (curHp <= 0)
        {
            IsDead();
        }
    }
    protected void IsDead()
    {
        BattleManager.Instance.MonsCount--;
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

enum PlayerState { Normal, Battle }

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour,IDamagable
{
	private Animator anim;
	private CharacterController controller;
	[SerializeField]
	private Rigidbody rigid;

	public PlayerData pd;
    
	private float moveY;

	[SerializeField]
	private float moveSpeed;
	[SerializeField]
	private float jumpSpeed;

    [Header("Attack")]
    [SerializeField]
    private bool showAttackGizmos;
    [SerializeField]
    private WeaponHolder weaponHolder;
    [SerializeField]
    private float attackRange;
    [SerializeField, Range(0f, 360f)]
    private float attackAngle;

	public UseCardSkill skill;



    [SerializeField]
	private TextMeshProUGUI HP;

	
	private void Awake()
	{
		anim = GetComponentInChildren<Animator>();
		controller = GetComponent<CharacterController>();
		rigid= controller.GetComponent<Rigidbody>();
	}

	private void Start()
	{
		
		Cursor.lockState = CursorLockMode.Locked;
		pd = BattleManager.Instance.player;
	}

	private void Update()
	{
        Move();
        Rotate();
        Jump();
        Attack();
		Skill();

		HP.text = "" + BattleManager.Instance.player.CurHp;
    }

	private void Move()
	{
		//Vector3 fowardVec = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z).normalized;
		//Vector3 rightVec = new Vector3(Camera.main.transform.right.x, 0f, Camera.main.transform.right.z).normalized;
		Vector3 moveInput = Vector3.forward * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal");
		if (moveInput.sqrMagnitude > 1f) moveInput.Normalize();
		//anim.SetFloat("XInput", Input.GetAxis("Horizontal"));
		//anim.SetFloat("YInput", Input.GetAxis("Vertical"));
		//Vector3 moveVec = fowardVec * moveInput.z + rightVec * moveInput.x;
		//controller.Move(moveVec * moveSpeed* Time.deltaTime);
		//anim.SetFloat("MoveSpeed", moveSpeed);
        if(Input.GetButtonDown("Left")&&transform.position!=new Vector3(-1.2f, transform.position.y, transform.position.z))
              rigid.MovePosition(transform.position - Vector3.right *moveSpeed);
        if(Input.GetButtonDown("Right") && transform.position != new Vector3(1.2f, transform.position.y, transform.position.z))
              rigid.MovePosition(transform.position + Vector3.right * moveSpeed);

    }
    

    private void Rotate()
	{
		//transform.forward = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z).normalized;
	}

	private void Jump()
	{
		//moveY += Physics.gravity.y * Time.deltaTime;

		if (Input.GetButtonDown("Jump"))
		{
			moveY = jumpSpeed;
		}
		//else if (controller.isGrounded && moveY < 0)
		{
		//	moveY = 0;
		}

		//controller.Move(Vector3.up * moveY * Time.deltaTime);
	}

	private void Attack()
	{
		if (!Input.GetButtonDown("Fire1")||BattleManager.Instance.CardSelectCanvas.activeSelf==true)
			return;

		// 공격 진행
		anim.SetTrigger("Attack");
        RaycastHit hit;
		if (Physics.Raycast(transform.position + new Vector3(0, 0.3f, 0), Vector3.forward * 7f, out hit, Mathf.Infinity))
		{
			IDamagable target = hit.transform.GetComponent<IDamagable>();
			target?.TakeDamage(BattleManager.Instance.player.BaseDamage);
		}
    }

	private void Skill()
	{
        if (!Input.GetButtonDown("Fire2")|| BattleManager.Instance.CardSelectCanvas.activeSelf == true|| BattleManager.Instance.hands.Count==1)
            return;

		
        //skill.AddComponent<UseCardSkill>();
		skill = BattleManager.Instance.hands[1].thisSkill;
        //skill.thiscard = BattleManager.Instance.hands[1];
        skill.CardAttack(this.gameObject);
		//카드 발동
		/*      switch (BattleManager.Instance.hands[0].attackMethod) 
			  {
				  case CardData.CardAttackTarget.Raycast:
					  useCard.AddComponent<Cannon>();
					  useCard.CardAttack(this.gameObject);
					  break;
				  case CardData.CardAttackTarget.Range:
					  useCard.AddComponent<Sword>();
					  useCard.CardAttack(this.gameObject);
					  break;
				  case CardData.CardAttackTarget.ToMe:
					  useCard.AddComponent<Heal>();
					  useCard.CardAttack(this.gameObject);
					  break;
			  }*/
		BattleManager.Instance.grave.Add(BattleManager.Instance.hands[1]);
		BattleManager.Instance.hands.RemoveAt(1);

	}
	public void TakeDamage(int damage)
    {
		anim.SetTrigger("Hit");
		BattleManager.Instance.player.CurHp -= damage;
		if(BattleManager.Instance.player.CurHp<=0)
		{
			GameManager.Instance.UnloadScene("BattleScene");
		}
	}
    public void OnSkillkHit()
    {
        Debug.Log("공격 타이밍");

        // 1. 범위내에 있는가
        Collider[] colliders = Physics.OverlapSphere(transform.position, attackRange);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject.name != "Cube")
                continue;

            Vector3 dirToTarget = (colliders[i].transform.position - transform.position).normalized;

            // 2. 각도내에 있는가
            if (Vector3.Dot(transform.forward, dirToTarget) < Mathf.Cos(attackAngle * 0.5f * Mathf.Deg2Rad))
                continue;

            
        }

    }
    private void OnDrawGizmosSelected()
    {
        Debug.DrawRay(transform.position+new Vector3(0,0.3f,0),Vector3.forward*7f ,Color.cyan);


        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 2);

        Vector3 rightDir = AngleToDir(transform.eulerAngles.y + 90 * 0.5f);
        Vector3 leftDir = AngleToDir(transform.eulerAngles.y - 90 * 0.5f);
        Debug.DrawRay(transform.position, rightDir * 100, Color.blue);
        Debug.DrawRay(transform.position, leftDir * 100, Color.blue);

    }
    private Vector3 AngleToDir(float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Sin(radian), 0, Mathf.Cos(radian));
    }

}


/*
 기본 공격은 직선
스킬은 범위 기즈모-자신 앞 가로3칸 -자신앞 세로2칸 
소환계는 소환체의 범위뎀
 
 */
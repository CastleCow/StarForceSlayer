using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

enum PlayerState { Normal, Battle }

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour,IDamagable
{
	private Animator anim;
	private CharacterController controller;
	[SerializeField]
	private Rigidbody rigid;

	private PlayerData pd;
    
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

		HP.text = "" + pd.CurHp;
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
		moveY += Physics.gravity.y * Time.deltaTime;

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
		if (!Input.GetButtonDown("Fire1"))
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
        if (!Input.GetButtonDown("Fire2"))
            return;

		//카드 발동

    }
	public void TakeDamage(int damage)
    {
		anim.SetTrigger("Hit");
		pd.CurHp -= damage;
		if(pd.CurHp<=0)
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
    }

}


/*
 기본 공격은 직선
스킬은 범위 기즈모-자신 앞 가로3칸 -자신앞 세로2칸 
소환계는 소환체의 범위뎀
 
 */
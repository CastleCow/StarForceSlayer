using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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

	private PoolManager m_poolManager;

    [SerializeField]
	private TextMeshProUGUI HP;

	[SerializeField]
	private GameObject SkillPos;
	
	private void Awake()
	{
		anim = GetComponentInChildren<Animator>();
		skill = GetComponent<UseCardSkill>();
		controller = GetComponent<CharacterController>();
		rigid= controller.GetComponent<Rigidbody>();
		m_poolManager=FindObjectOfType<PoolManager>();
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
        anim.SetBool("Skill", false);
    }

	private void Move()
	{
		
		Vector3 moveInput = Vector3.forward * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal");
		if (moveInput.sqrMagnitude > 1f) moveInput.Normalize();
		
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
			m_poolManager.NameGet("Hit_NormalAttack", hit.transform.position);
			IDamagable target = hit.transform.GetComponent<IDamagable>();
			target?.TakeDamage(BattleManager.Instance.player.BaseDamage);
			
		}
    }

	private void Skill()
	{
        if (!Input.GetButtonDown("Fire2")|| BattleManager.Instance.CardSelectCanvas.activeSelf == true|| BattleManager.Instance.hands.Count==1)
            return;



		anim.SetBool("Skill",true);
		Debug.Log(gameObject);
		//카드 발동
		skill = BattleManager.Instance.hands[1].thisSkill;
		skill.CardAttack(this.gameObject);
        m_poolManager.NameGet(skill.m_ParticleName, SkillPos.transform.position);
        //anim.SetTrigger(skill.animTrigger);
        Debug.Log("스킬사용");
		anim.SetTrigger(skill.animTrigger);
		BattleManager.Instance.grave.Add(BattleManager.Instance.hands[1]);
		BattleManager.Instance.hands.RemoveAt(1);

       

    }
	public void TakeDamage(int damage)
    {
		anim.SetTrigger("Hit");
		BattleManager.Instance.player.CurHp -= damage;
		if(BattleManager.Instance.player.CurHp<=0)
		{
			IsDead();
		}
	}
	public void IsDead()
	{
        Cursor.lockState = CursorLockMode.None;
		Destroy(BattleManager.Instance);
		Destroy(GameManager.Instance);
		Destroy(DataBaseManager.Instance);
		Destroy(PlayerManager.Instance);
		
        SceneManager.LoadScene("GameOver");
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
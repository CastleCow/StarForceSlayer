using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerState { Normal, Battle }

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
	private Animator anim;
	private CharacterController controller;
	[SerializeField]
	private Rigidbody rigid;

    private PlayerState state;
	private float moveY;

	[SerializeField]
	private float moveSpeed;
	[SerializeField]
	private float jumpSpeed;

	[SerializeField]
	private WeaponHolder weaponHolder;

	private void Awake()
	{
		anim = GetComponentInChildren<Animator>();
		controller = GetComponent<CharacterController>();
		rigid= controller.GetComponent<Rigidbody>();
	}

	private void Start()
	{
		state = PlayerState.Normal;
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void Update()
	{
		switch (state)
		{
			case PlayerState.Normal:
				Move();
				Rotate();
				Jump();
				ChangeForm();
				break;
			case PlayerState.Battle:
				Move();
				Rotate();
				Jump();
				Attack();
				ChangeForm();
				break;
		}
	}

	private void Move()
	{
		Vector3 fowardVec = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z).normalized;
		Vector3 rightVec = new Vector3(Camera.main.transform.right.x, 0f, Camera.main.transform.right.z).normalized;
		Vector3 moveInput = Vector3.forward * Input.GetAxis("Vertical") + Vector3.right * Input.GetAxis("Horizontal");
		if (moveInput.sqrMagnitude > 1f) moveInput.Normalize();
		anim.SetFloat("XInput", Input.GetAxis("Horizontal"));
		anim.SetFloat("YInput", Input.GetAxis("Vertical"));
		Vector3 moveVec = fowardVec * moveInput.z + rightVec * moveInput.x;
		//controller.Move(moveVec * moveSpeed* Time.deltaTime);
		anim.SetFloat("MoveSpeed", moveSpeed);
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
		else if (controller.isGrounded && moveY < 0)
		{
			moveY = 0;
		}

		controller.Move(Vector3.up * moveY * Time.deltaTime);
	}

	private void Attack()
	{
		if (!Input.GetButtonDown("Fire1"))
			return;

		// 공격 진행
	}

	private void ChangeForm()
	{
		if (!Input.GetButtonDown("Fire2"))
			return;

		if (state == PlayerState.Normal)
		{
			state = PlayerState.Battle;
			weaponHolder.ShowWeapon();
			anim.SetTrigger("ChangeForm");
			anim.SetLayerWeight(1, 1);
		}
		else if (state == PlayerState.Battle)
		{
			state = PlayerState.Normal;
			weaponHolder.HideWeapon();
			anim.SetTrigger("ChangeForm");
			anim.SetLayerWeight(1, 0);
		}
	}

    private void OnDrawGizmosSelected()
    {
        Debug.DrawRay(transform.position+new Vector3(0,0.3f,0),Vector3.forward*7f ,Color.cyan);
    }
}

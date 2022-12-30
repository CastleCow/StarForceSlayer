using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
	[SerializeField]
	private Weapon curWeapon;

	public void ChangeWeapon(Weapon weapon)
	{
		curWeapon = weapon;
	}

	public void ShowWeapon()
	{
		curWeapon.gameObject.SetActive(true);
	}

	public void HideWeapon()
	{
		curWeapon.gameObject.SetActive(false);
	}
}

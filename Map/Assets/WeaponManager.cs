using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WeaponManager : NetworkBehaviour {
	[SerializeField]
	private Transform weaponHolder;

	[SerializeField]
	private PlayerWeapon primaryWeapon;

	private PlayerWeapon currentWeapon;

	public WeaponGraphics currentGraphics;

	public bool isReloading = false;

	void Start () 
	{
		EquipWeapon (primaryWeapon);
	}

	void EquipWeapon (PlayerWeapon _weapon)
	{
		currentWeapon = _weapon;

	
		if (currentGraphics == null) {
			Debug.Log ("No WeaponGraphics component on the weapon object : ");
		}



	}

	public PlayerWeapon GetCurrentWeapon()
	{
		return currentWeapon;
	}

	public WeaponGraphics GetCurrentGraphics()
	{

		return currentGraphics;
	}

	public void Reload ()
	{
		if (isReloading) {
			return;
		}

		StartCoroutine(Reload_Coroutine ());
	}

	private IEnumerator Reload_Coroutine()
	{
		isReloading = true;

		yield return new WaitForSeconds(currentWeapon.reloadTime);

		currentWeapon.bullets = currentWeapon.maxBullets;

		isReloading = false;
	}


}

using UnityEngine.Networking;
using UnityEngine;
using System.Collections;

[RequireComponent (typeof(WeaponManager))]
public class PlayerShoot : NetworkBehaviour {

	private const string PLAYER_TAG = "Player";
	private const string MONSTER_TAG = "Monster";
	public float WaitImeBetweenShots = 1f;

	private PlayerWeapon currentweapon;

	[SerializeField]
	private Camera cam;

	[SerializeField]
	private LayerMask mask;

	private WeaponManager weaponManager;

	void Start()
	{
		if (cam == null) 
		{
			Debug.LogError ("No Camera Renferenced! ");		
		}

		weaponManager = GetComponent<WeaponManager> ();
	}

	void Update()
	{

		currentweapon = weaponManager.GetCurrentWeapon ();

		if (currentweapon.firerate <= 0f) {
			
		
			if (Input.GetButtonDown ("Fire1")) {
			
				Shoot ();
				StartCoroutine (Coroutine_WaitShots ());
			}
		}
	}
	// called on server
	[Command]
	void CmdOnShoot ()
	{

		RpcdoShootEffect();

	}

	// called on all clients
	[ClientRpc]
	void RpcdoShootEffect()
	{
		weaponManager.GetCurrentGraphics ().muzzleFlash.Play ();
	}

	[Command]
	void CmdOnHit(Vector3 _pos, Vector3 _normal)
	{
		RpcdohitEffect (_pos, _normal);
	}

	[ClientRpc]
	void RpcdohitEffect(Vector3 _pos, Vector3 _normal)
	{
		
		GameObject _hitEffect = Instantiate (weaponManager.GetCurrentGraphics ().hitEffectPrefab, _pos, Quaternion.LookRotation (_normal));
		Destroy (_hitEffect, 2f);
	}

	[Client]
	void Shoot ()
	{
		if (!isLocalPlayer || weaponManager.isReloading) {
			return;
		}

		if (currentweapon.bullets <= 0) {
			weaponManager.Reload ();
			weaponManager.GetCurrentGraphics ().Reload.Play ();
			return;
		}

		currentweapon.bullets--;
		// We are shooting here 

		CmdOnShoot ();
		RaycastHit _hit;
		weaponManager.GetCurrentGraphics ().Fire.Play ();
		if (Physics.Raycast (cam.transform.position, cam.transform.forward, out _hit, currentweapon.range, mask)) 
		{
			
			if ((_hit.collider.tag == PLAYER_TAG || _hit.collider.tag == MONSTER_TAG) && this.tag != _hit.collider.tag) 
			{
				
				CmdPlayerShot (_hit.collider.name, currentweapon.damage);
			}



			CmdOnHit (_hit.point, _hit.normal);


		}
		if (currentweapon.bullets <= 0) {
			weaponManager.Reload ();
			weaponManager.GetCurrentGraphics ().Reload.Play ();
			return;
		}

	}

	[Command]
	void CmdPlayerShot (string _playerID, int damage)
	{
		Debug.Log (_playerID + " has been shot.");

		Player _player = GameManager.GetPlayer (_playerID);
		_player.RpcTakeDamage (damage);
	}

	private IEnumerator Coroutine_WaitShots()
	{
		yield return new WaitForSeconds (WaitImeBetweenShots);
	}

}
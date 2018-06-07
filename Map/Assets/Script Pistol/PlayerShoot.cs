using UnityEngine.Networking;
using UnityEngine;

[RequireComponent (typeof(WeaponManager))]
public class PlayerShoot : NetworkBehaviour {

	private const string PLAYER_TAG = "Player";


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
	[Client]
	void Shoot ()
	{
		if (!isLocalPlayer) {
			return;
		}

		// We are shooting here 

		CmdOnShoot ();
		RaycastHit _hit;
		if (Physics.Raycast (cam.transform.position, cam.transform.forward, out _hit, currentweapon.range, mask)) 
		{
			
			if (_hit.collider.tag == PLAYER_TAG) 
			{
				
				CmdPlayerShot (_hit.collider.name, currentweapon.damage);
			}
		}

	}

	[Command]
	void CmdPlayerShot (string _playerID, int damage)
	{
		Debug.Log (_playerID + " has been shot.");

		Player _player = GameManager.GetPlayer (_playerID);
		_player.RpcTakeDamage (damage);
	}

}
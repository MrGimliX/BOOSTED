using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

	[SerializeField]
	RectTransform healthBarFill;

	[SerializeField]
	Text ammoText;

	private Player player;

	private WeaponManager weaponManager;

	void SetHealthAmount (float _amount)
	{

		healthBarFill.localScale = new Vector3 (1f, _amount, 1f);
	}

	public void SetPlayer (Player _player)
	{
		player = _player;
		weaponManager = player.GetComponent<WeaponManager>();
	}
	void Update ()
	{
		SetHealthAmount (player.GetHealthPct());
		SetAmmoAmount (weaponManager.GetCurrentWeapon().bullets);
	}

	void SetAmmoAmount (int _amount)
	{
		ammoText.text = _amount.ToString ();
	}
}

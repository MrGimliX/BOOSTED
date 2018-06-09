using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

	[SerializeField]
	RectTransform healthBarFill;

	[SerializeField]
	Text ammoText;

	[SerializeField]
	Text KeysText;

	[SerializeField]
	Image KeysImage;

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
		SetKey (GameVariables.keycount);
	}

	void SetAmmoAmount (int _amount)
	{
		ammoText.text = _amount.ToString ();
	}

	public void SetKey(int keycount)
	{
		if (keycount == 5) 
		{
			KeysText.text = keycount.ToString ();
			KeysImage.color = new Color (9, 255, 0, 203);
		}
		else
			KeysText.text = keycount.ToString ();
	}
}

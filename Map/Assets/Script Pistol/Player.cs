using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {
	[SyncVar]
	private bool _isdead = false;
	public bool isDead
	{
		get{return _isdead;}
		protected set { _isdead = value;}
	}

	[SerializeField]
	private int maxHealth = 100;

	[SyncVar]
	private int currentHealth;

	public float GetHealthPct()
	{
		
		return (float)currentHealth / maxHealth;
	}


	[SerializeField]
	private Behaviour[] disableOnDeath;

	[SerializeField]
	private GameObject[] disableGameObjectOnDeath;

	private bool[] wasEnabled;


	public void Setup ()
	{
		wasEnabled = new bool[disableOnDeath.Length];
		for (int i = 0; i < wasEnabled.Length; i++) 
		{
			wasEnabled [i] = disableOnDeath [i].enabled;
		}

		SetDefaults ();
	}


	[ClientRpc]
	public void RpcTakeDamage (int _amount)
	{

		if (isDead)
			return;
		currentHealth = currentHealth - _amount;


		Debug.Log (transform.name + " now has " + currentHealth + " health.");
		if (currentHealth <= 0) 
		{
			currentHealth = 0;
			Die ();
		}
		if (currentHealth > maxHealth)
			currentHealth = maxHealth;
	}

	private void Die()
	{
		isDead = true;

		for (int i = 0; i < disableOnDeath.Length; i++) 
		{
			disableOnDeath [i].enabled = false;
		}

		for (int i = 0; i < disableGameObjectOnDeath.Length; i++) 
		{
			disableGameObjectOnDeath [i].SetActive( false);
		}

		if (this.transform.tag == "Player")
			GameVariables.playersdead++;
		if (this.transform.tag == "Monster")
			GameVariables.MonsterDead = true;
		// DISABLE COMPONENTS

		Debug.Log (transform.name + "is dead!");
	}
	public void SetDefaults()
	{
		isDead = false;

		currentHealth = maxHealth;

		for (int i = 0; i < disableOnDeath.Length; i++) 
		{
			disableOnDeath [i].enabled = wasEnabled [i];
		}

		for (int i = 0; i < disableGameObjectOnDeath.Length; i++) 
		{
			disableGameObjectOnDeath [i].SetActive(true);
		}

		Collider _col = GetComponent<Collider>();
		if (_col != null) {
			_col.enabled = true;
		}
	}





}

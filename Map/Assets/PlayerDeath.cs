using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {
	public GameWinningManager gameManager;

	void OnTriggerEnter(Collider collider)
	{
		if(collider.gameObject.name == "SoloMonste")
		{
			gameManager.WinGameMonster();
		}
	}
}

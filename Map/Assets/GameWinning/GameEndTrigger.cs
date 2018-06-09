using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndTrigger : MonoBehaviour {

	public GameWinningManager gameManager;
	void OnTriggerEnter(Collider collider)
	{
		if(collider.tag == "Player" && GameVariables.keycount == 5)
		{
			gameManager.WinGameHuntersEscape();

		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndTrigger : MonoBehaviour {

	public GameWinningManager gameManager;
	void OnTriggerEnter()
	{
		gameManager.WinGameHuntersEscape();
	}
}

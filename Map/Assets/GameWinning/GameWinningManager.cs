using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameWinningManager : MonoBehaviour {

	public GameObject CompleteLevelUI;

	public GameObject MonsterKilled;

	public GameObject MonsterWin;

	public void WinGameHuntersEscape()
	{
		CompleteLevelUI.SetActive(true);
	}


	public void WinGameHunterMonsterKilled()
	{
		MonsterKilled.SetActive (true);
	}

	public void WinGameMonster()
	{
		MonsterWin.SetActive (true);
	}

	void Update ()
	{
		if (GameVariables.allplayers == GameVariables.playersdead && GameVariables.allplayers != 0 && GameVariables.playersdead != 0)
			WinGameMonster ();
			return;
		if (GameVariables.MonsterDead) {
			WinGameHunterMonsterKilled ();
		}
	}
}

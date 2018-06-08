using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameWinningManager : MonoBehaviour {

	public GameObject CompleteLevelUI;


	public void WinGameHuntersEscape()
	{
		CompleteLevelUI.SetActive(true);
	}
	/*bool GameEnded = false;

	public float RestartDelay = 3f;

	public void EndGame()
	{
		if (GameEnded == false)
		{
			GameEnded = true;
			Debug.Log("Hunters Win")
			Invoke("Restart", RestartDelay)
		}
	}

	void Restart()
	{
		SceneManager.LoadScene("Lobby")
	}*/
}

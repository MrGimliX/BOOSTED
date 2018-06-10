using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelCompleteSolo : MonoBehaviour {

	public void LoadNextLevel()
	{
		SceneManager.LoadScene("Menu");
	}
}

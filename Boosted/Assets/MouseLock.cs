using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

	}
	
	void OnApplicationFocus(bool ApplicationIsBack)
	{
		if (ApplicationIsBack == true)
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
			
	}

}

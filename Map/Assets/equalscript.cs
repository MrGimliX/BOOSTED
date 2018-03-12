using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equalscript : MonoBehaviour {
	public Light Lighttocopy;
	Light testLight;
	// Use this for initialization
	void Start () {
		testLight = GetComponent<Light> ();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		testLight.enabled = Lighttocopy.enabled;		
	}
}

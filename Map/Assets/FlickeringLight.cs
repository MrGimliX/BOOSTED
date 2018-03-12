using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour {
	public float minWaitTime;
	public float maxWaitTime;
	Light testLight;
	// Use this for initialization
	void Start () {
		testLight = GetComponent<Light> ();
		StartCoroutine (Flashing ());
		
	}
	
	// Update is called once per frame
	IEnumerator Flashing() 
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
			testLight.enabled = !testLight.enabled;
		}
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour {


	void OnTriggerEnter (Collider collider){
		if (collider.tag == "Player")
		 {
			 GameVariables.keycount += 1;
			 Destroy(gameObject);
		 }
	}
}

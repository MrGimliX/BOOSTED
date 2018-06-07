using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

	void OnTriggerEnter (Collider collider){
		if (collider.tag == "Player" && GameVariables.keycount == 5)
		 {

			 Destroy(gameObject);
		 }
	}
}

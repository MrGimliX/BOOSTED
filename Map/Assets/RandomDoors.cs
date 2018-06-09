using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RandomDoors : MonoBehaviour {
     public List<BoxCollider> colliders;

     void Start ()
     {
         Spawn();
     }


     void Spawn ()
     {
         int spawnpointIndex = Random.Range(0, colliders.Count);
				 colliders[spawnpointIndex].enabled = true;

		 }
 }

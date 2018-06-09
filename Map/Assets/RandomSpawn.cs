using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class RandomSpawn : MonoBehaviour {
		 public GameObject Keys;
     public List<Transform> spawnPoints;
		 private int keynum = 5;

     void Start ()
     {
         Spawn();
     }


     void Spawn ()
     {
			 while (keynum > 0)
			 {
         int spawnpointIndex = Random.Range(0, spawnPoints.Count);
         Instantiate(Keys, spawnPoints[spawnpointIndex].position, spawnPoints[spawnpointIndex].rotation);
				 spawnPoints.RemoveAt (spawnpointIndex);
				 keynum--;
			 }
		 }
 }

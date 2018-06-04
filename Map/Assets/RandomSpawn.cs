using UnityEngine;
using System.Collections;
public class RandomSpawn : MonoBehaviour {
		 public GameObject Hunter;
     public Transform[] spawnPoints;

     void Start ()
     {
         Spawn();
     }


     void Spawn ()
     {
         int spawnpointIndex = Random.Range(0, spawnPoints.Length);
         Instantiate(Hunter, spawnPoints[spawnpointIndex].position, spawnPoints[spawnpointIndex].rotation);
		 }
 }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Characteranimator : MonoBehaviour{
	const float locomotionAnimationSmoothTime = 0.1f;
	Animator animator;
	NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		animator = GetComponentInChildren<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		float SpeedPercent = agent.velocity.magnitude / agent.speed;
		animator.SetFloat ("SpeedPercent", SpeedPercent, locomotionAnimationSmoothTime, Time.deltaTime);
	}
}
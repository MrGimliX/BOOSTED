using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(PlayerController))]
public class RunnerAb : MonoBehaviour {

	[SerializeField]
	private float speedBoost;

	[SerializeField]
	private float timeOfBoost = 1;

	private PlayerController _playerController;

	private bool IsRunning = false;

	[SerializeField]
	private float timeForReload = 10f;

	private bool usingboost = false;

	private bool Relaoding = false;

	void Start ()
	{

		_playerController = GetComponent<PlayerController> ();

	}

	void Update ()
	{

		if (Input.GetButtonDown("Run"))
			{

				ChangeValue();
				
			}

	}

	void ChangeValue()
	{
		if (IsRunning) {
			return;	
		}
		
		StartCoroutine (Coroutine_Speed ());

	}


	private IEnumerator Coroutine_Speed()
	{
		IsRunning = true;

		usingboost = true;

		float previous_speed = _playerController.GetSpeed;

		_playerController.GetSpeed = speedBoost;

		yield return new WaitForSeconds(timeOfBoost);

		_playerController.GetSpeed = previous_speed;


		usingboost = false;

		Relaoding = true;
		yield return new WaitForSeconds (timeForReload);

		Relaoding = false;

		IsRunning = false;
	}

	public bool GetUsingBoost
	{
		get {return usingboost;}
	}

	public bool GetReloading
	{
		get {return Relaoding;}
	}

		



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed = 10f;
	[SerializeField]
	private float CameraSensitivity = 5f;

	private PlayerMotor motor;

	void Start ()
	{
		motor = GetComponent<PlayerMotor> ();
	}

	void Update()
	{
		float _xMov = Input.GetAxisRaw ("Horizontal");
		float _zMov = Input.GetAxisRaw ("Vertical");

		Vector3 movHorizontal = transform.right * _xMov;
		Vector3 movVertical = transform.forward * _zMov;

		Vector3 _velocity = (movVertical + movHorizontal).normalized * speed;

		motor.Move (_velocity);

		float _yRot = Input.GetAxisRaw ("Mouse X");

		Vector3 _rotation = new Vector3 (0f, _yRot, 0f) * CameraSensitivity;

		motor.Rotate (_rotation);

		float _xRot = Input.GetAxisRaw ("Mouse Y");

		Vector3 _CameraRotation = new Vector3 (_xRot, 0f, 0f) * CameraSensitivity;

		motor.RotateCam (_CameraRotation);

	}

}

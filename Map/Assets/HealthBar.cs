using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
	public Image currentHealth;
	private float hitpoint = 300;
	private float maxhitpoint = 300;

	private void Start()
	{
		UpdateHealth();
	}

	private void UpdateHealth()
	{
		float ratio = hitpoint / maxhitpoint;
		currentHealth.rectTransform.localScale = new Vector3(ratio,1,1);
	}

	private void TakeDamage(float damage)
	{
		hitpoint -= damage;
		if (hitpoint < 0)
			{
				hitpoint = 0;
				Debug.Log("You dead noob!");
			}
		UpdateHealth();
	}


}

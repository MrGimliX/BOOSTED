using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunnerAbUI : MonoBehaviour {


	[SerializeField]
	RectTransform RunnerBarFill;

	[SerializeField]
	Image RunnerImage;

	private bool Usingboost = false;

	public RunnerAb _runnerAb;

	private bool Reload = false;

	void Start()
	{
		RunnerBarFill.localScale = new Vector3 (1f, 1f, 1f);
		RunnerImage.color = new Color32 (0, 202, 255, 227);
	}
	// Update is called once per frame
	void Update () 
	{
		Reload = _runnerAb.GetReloading;
		Usingboost = _runnerAb.GetUsingBoost;
		if (!Usingboost && !Reload)
			RunnerBarFill.localScale = new Vector3 (1f, 1f, 1f);
		if (Usingboost)
			RunnerImage.color = new Color32 (9, 255, 0, 227);
		if (!Usingboost)
			RunnerImage.color = new Color32 (0, 202, 255, 227);
		if (Reload)
			RunnerBarFill.localScale = new Vector3 (1f, 0f, 1f);
		if (!Reload) {
			RunnerBarFill.localScale = new Vector3 (1f, 1f, 1f);
		}
	}


}

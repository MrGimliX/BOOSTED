using UnityEngine;
using System.Collections;

public class GunGlock : MonoBehaviour {

	public float damage = 10f;
	public float range = 100f;
	public float impforce = 30f;
	public float fireRate = 2f;

	public int maxAmmo = 10;
	public int currentAmmo;
	public float reloadTime = 2f;
	private bool isReloading = false;

	public Camera fpsCam;
	public ParticleSystem muzzleFlash;
	public GameObject impactEffect;

	private float nextTimeToFire = 0f;

	public Animator animator;

	void Start()
	{
		currentAmmo = maxAmmo;
	}

	void Update () {

		if (isReloading)
			return;

		if (currentAmmo <= 0)
		{
			StartCoroutine(Reload());
			return;
		}
		if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
		{
			nextTimeToFire = Time.time + 1f/fireRate;
			Shoot();
		}
	}

	IEnumerator Reload ()
	{
		isReloading = true;
		animator.SetBool("Reloading", true);
		yield return new WaitForSeconds(reloadTime - 0.25f);
		animator.SetBool("Reloading", false);
		yield return new WaitForSeconds(0.25f);
		currentAmmo = maxAmmo;
		isReloading = false;
	}

	void Shoot()
	{
		muzzleFlash.Play();
		RaycastHit hit;
		if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
		{
			Target target = hit.transform.GetComponent<Target>();
			if (target != null)
			{
				target.TakeDamage(damage);
			}

			if (hit.rigidbody != null)
			{
				hit.rigidbody.AddForce(-hit.normal * impforce);
			}
			GameObject impactGO =Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
			Destroy(impactGO, 2f);
		}
	}
}
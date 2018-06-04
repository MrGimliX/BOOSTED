using UnityEngine;
using System.Collections;

public class Arbalette : MonoBehaviour {

	public float damage = 35f;
	public float range = 100f;
	public float impforce = 30f;
	public float fireRate = 1.2f;
	public AudioSource Shot;
	public AudioSource ReloadSound;
	public int maxAmmo = 8;
	public int currentAmmo;
	public float reloadTime = 2.5f;
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
			ReloadSound.Play ();
			if (currentAmmo <= 0)
			{

				StartCoroutine (Reload ());

				return;
			}
		}
		if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
		{
			nextTimeToFire = Time.time + 1f/fireRate;
			Shot.Play();
			Shoot();
			currentAmmo--;
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

using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour {
	public enum weapon{basicPistol, basicShotGun};
	public weapon myWeapon;
	weapon oldWeapon;

	float time2Fire = 0f;

	float currWeaponTime = 0.2f;
	float currWeaponDamage = 20f;

	private float basePistolTime = 0.1f;
	private float basePistolDamage = 20f;
	[SerializeField] private GameObject basePistol;

	private float baseShotgunTime = 0.5f;
	private float baseShotgunDamage = 70f;
	[SerializeField] private GameObject baseShotgun;
	[SerializeField] private PlayerCam pCam;
	private float low = 0.05f;
	private float high = 0.25f;

	// Use this for initialization
	void Start () {
		ChangeGun ();
	}
	
	// Update is called once per frame
	void Update () {
		if (time2Fire > 0f)
			time2Fire -= Time.deltaTime;
		if (Input.GetButton ("Fire") && time2Fire <= 0f) {
			FireGun ();
		}
		if (myWeapon != oldWeapon) {
			oldWeapon = myWeapon;
			ChangeGun ();
		}
	}

	void ChangeGun () {
		if (myWeapon == weapon.basicPistol) {
			Debug.Log ("Changed to BasicPistol");
			baseShotgun.SetActive (false);
			basePistol.SetActive (true);
			currWeaponDamage = basePistolDamage;
			currWeaponTime = basePistolTime;
		}
		if (myWeapon == weapon.basicShotGun) {
			baseShotgun.SetActive (true);
			basePistol.SetActive (false);
			Debug.Log ("Changed to BasicShotgun");
			currWeaponDamage = baseShotgunDamage;
			currWeaponTime = baseShotgunTime;
		}
	}

	void FireGun () {
		pCam.RandomCamShake (Random.Range (low, high));
		//AudioSource.PlayClipAtPoint (); //Sound based on gun

		//Animation based on gun called through his animator

		//Call screen shake based on gun

		//Show GunFlare

		//Shoot Projectile or raycast

		//Set time till next fire based on gun
		time2Fire = currWeaponTime;
		Debug.Log ("Bang");
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRecoil : MonoBehaviour {

	public Transform recoilMod;
	public GameObject weapon;
	public float maxRecoil_x = -2f;
	public float recoilSpeed = 2f;
	public float maxRecoil_y = 2f;
	public float recoil = 0.0f;

	public void StartRecoil (float recoilParam, float maxRecoil_xParam, float recoilSpeedParam)
	{
		// in seconds
		recoil = recoilParam;
		maxRecoil_x = maxRecoil_xParam;
		recoilSpeed = recoilSpeedParam;
		maxRecoil_y = Random.Range(-maxRecoil_xParam, maxRecoil_xParam);
	}

	void recoiling ()
	{
		if (recoil > 0f) {
			Quaternion maxRecoil = Quaternion.Euler (maxRecoil_x, maxRecoil_y, 0f);
			// Dampen towards the target rotation
			transform.localRotation = Quaternion.Slerp (transform.localRotation, maxRecoil, Time.deltaTime * recoilSpeed);
			recoil -= Time.deltaTime;
		} else {
			recoil = 0f;
			// Dampen towards the target rotation
			transform.localRotation = Quaternion.Slerp (transform.localRotation, Quaternion.identity, Time.deltaTime * recoilSpeed / 2);
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButton (0)) {
			StartRecoil (0.3f, maxRecoil_x, maxRecoil_y);
		}
		Recoiling ();
	}


	void Recoiling() {
		if (recoil > 0) {

			var maxRecoil = Quaternion.Euler (maxRecoil_x, 0, 0);

			// Dampen towards the target rotation

			recoilMod.rotation = Quaternion.Slerp (recoilMod.rotation, maxRecoil, Time.deltaTime * recoilSpeed);

			weapon.transform.localEulerAngles = new Vector3(recoilMod.localEulerAngles.x , weapon.transform.localEulerAngles.y,  weapon.transform.localEulerAngles.z);

			recoil -= Time.deltaTime ;

		} else {
			recoil = 0;
			var minRecoil = Quaternion.Euler (0, 0, 0);
			// Dampen towards the target rotation
			recoilMod.rotation = Quaternion.Slerp (recoilMod.rotation, minRecoil, Time.deltaTime * recoilSpeed / 2);
			weapon.transform.localEulerAngles = new Vector3(recoilMod.localEulerAngles.x , weapon.transform.localEulerAngles.y,  weapon.transform.localEulerAngles.z);

		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSm16Controller : MonoBehaviour {
	private Animator anim;
	public bool isreloading = false;
	public Transform ParentForGunData;
	int zoom = 0;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	public void Plyyyy(){
		isreloading = true;
		anim.Play ("Reload");
		Invoke ("SetIsReloadingToFalse", 4f);
		if (Input.GetKeyDown (KeyCode.R)) {
			if (ParentForGunData.GetComponent<GunData> ().Bullets != 30 && !(ParentForGunData.GetComponent<GunData> ().ExtraAmmo <= 0)) {
				ParentForGunData.GetComponent<GunData> ().ReloadGun();
			}
		}
	}

	void SetIsReloadingToFalse(){
		isreloading = false;
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown (0)) {
			anim.SetTrigger ("ShootFire");
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			
			if (ParentForGunData.GetComponent<GunData> ().Bullets == 30 || (ParentForGunData.GetComponent<GunData>().ExtraAmmo == 0)){
				
				return;
			}
			else {
				Plyyyy ();
			}
		}

		if (Input.GetKey (KeyCode.W)) {
			anim.SetFloat ("Walk",Input.GetAxis("Vertical"));
		}

		if (Input.GetKeyDown (KeyCode.I)) {
			anim.Play ("inspect");
		}

		else if (!isreloading) {
			anim.SetFloat ("Run", 0);
			anim.SetFloat ("Walk", Input.GetAxis ("Vertical"));
		}


	}
}

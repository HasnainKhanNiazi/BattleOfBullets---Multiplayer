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

		if (Input.GetKey (KeyCode.LeftShift) && Input.GetKey (KeyCode.W)) {
			anim.SetFloat ("Run",0.2f);
		}

		if (Input.GetMouseButtonDown (1)) {
			if (zoom == 0) {
				zoom++;
				anim.SetBool ("Zoom", true);
			} else if (zoom != 0) {
				zoom--;
				anim.SetBool ("Zoom", false);
			}
		}

//		if ((Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.LeftShift))) {
//			anim.SetFloat ("Walk",Input.GetAxis("Vertical"));
//			anim.SetFloat ("Run", 1);
//		}

		else if (!isreloading) {
			anim.SetFloat ("Run", 0);
			anim.SetFloat ("Walk", Input.GetAxis ("Vertical"));
		}


	}
}
